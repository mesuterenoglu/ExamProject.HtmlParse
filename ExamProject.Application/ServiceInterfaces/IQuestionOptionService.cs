

using ExamProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Application.ServiceInterfaces
{
    public interface IQuestionOptionService
    {
        Task AddAsync(QuestionOptionDto entity);
        Task DeleteAsync(Guid id);
        Task RemoveFromDbAsync(Guid id);
        Task UpdateAsync(QuestionOptionDto entity);
        Task<List<QuestionOptionDto>> GetAllAsync();
        Task<List<QuestionOptionDto>> GetAllInActiveAsync();
        Task<List<QuestionOptionDto>> GetAllActiveAsync();
        Task<QuestionOptionDto> GetbyIdAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        Task<List<string>> GetCorrectOptionsbyExamId(Guid examId);
    }
}
