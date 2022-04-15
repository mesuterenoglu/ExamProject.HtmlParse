
using ExamProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Application.ServiceInterfaces
{
    public interface IExamService
    {
        Task AddAsync(ExamDto entity);
        Task DeleteAsync(Guid id);
        Task RemoveFromDbAsync(Guid id);
        Task UpdateAsync(ExamDto entity);
        Task<List<ExamDto>> GetAllAsync();
        Task<List<ExamDto>> GetAllInActiveAsync();
        Task<List<ExamDto>> GetAllActiveAsync();
        Task<ExamDto> GetbyIdAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
            
    }
}
