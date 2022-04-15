
using ExamProject.Application.DTOs;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace ExamProject.Application.ServiceInterfaces
{
    public interface IQuestionService
    {
        Task AddAsync(QuestionDto entity);
        Task DeleteAsync(Guid id);
        Task RemoveFromDbAsync(Guid id);
        Task UpdateAsync(QuestionDto entity);
        Task<List<QuestionDto>> GetAllAsync();
        Task<List<QuestionDto>> GetAllInActiveAsync();
        Task<List<QuestionDto>> GetAllActiveAsync();
        Task<QuestionDto> GetbyIdAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
    }
}
