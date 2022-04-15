

using ExamProject.Domain.Entities;
using System.Threading.Tasks;

namespace ExamProject.Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<bool> AnybyHeaderandAuthor(string header, string author);
    }
}
