

using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamProject.Domain.Interfaces
{
    public interface IQuestionOptionRepository : IRepository<QuestionOption>
    {
        Task<List<string>> GetCorrectOptionsbyExamId(Guid examId);
    }
}
