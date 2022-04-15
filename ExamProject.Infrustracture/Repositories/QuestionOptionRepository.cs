using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProject.Infrustracture.Repositories
{
    public class QuestionOptionRepository: BaseRepository<QuestionOption>,IQuestionOptionRepository
    {
        public QuestionOptionRepository(AppDbContext context): base(context)
        {

        }

        public async Task<List<string>> GetCorrectOptionsbyExamId(Guid examId)
        {
            List<string> options = new List<string>();
            var questions = await _context.Questions.Where(x => x.ExamId == examId).ToListAsync();
            foreach (var question in questions)
            {
                foreach (var option in question.Options)
                {
                    if (option.IsCorrect)
                    {
                        options.Add(option.Option);
                    }
                }
            }
            return options;
        }
    }
}
