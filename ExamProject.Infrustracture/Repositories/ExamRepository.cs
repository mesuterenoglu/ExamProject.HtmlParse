

using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;

namespace ExamProject.Infrustracture.Repositories
{
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext context):base(context)
        {

        }
    }
}
