using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;
using ExamProject.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamProject.Infrustracture.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> dataSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dataSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dataSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dataSet.AnyAsync(filter);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetbyIdAsync(id);
            entity.IsActive = false;
            await UpdateAsync(entity);
        }

        public async Task<List<TEntity>> GetAllActiveAsync()
        {
            return await dataSet.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dataSet.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllInActiveAsync()
        {
            return await dataSet.Where(x => x.IsActive == false).ToListAsync();
        }

        public async Task<List<TEntity>> GetbyFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dataSet.Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetbyIdAsync(Guid id)
        {
            var entity = await dataSet.SingleOrDefaultAsync(x => x.Id == id && x.IsActive == true);
            return entity;
        }

        public async Task RemoveFromDbAsync(Guid id)
        {
            var entity = await GetbyIdAsync(id);
            dataSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dataSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
