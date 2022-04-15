

using ExamProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Application.ServiceInterfaces
{
    public interface IPostService
    {
        Task AddAsync(PostDto entity);
        Task DeleteAsync(Guid id);
        Task RemoveFromDbAsync(Guid id);
        Task UpdateAsync(PostDto entity);
        Task<List<PostDto>> GetAllAsync();
        Task<List<PostDto>> GetAllInActiveAsync();
        Task<List<PostDto>> GetAllActiveAsync();
        Task<PostDto> GetbyIdAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        Task<bool> AnybyHeaderandAuthor(string header, string author);
    }
}
