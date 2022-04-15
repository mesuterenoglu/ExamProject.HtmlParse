
using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;

namespace ExamProject.Infrustracture.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context):base(context)
        {

        }
    }
}
