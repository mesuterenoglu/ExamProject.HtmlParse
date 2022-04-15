

using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProject.Infrustracture.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context):base(context)
        {

        }

        public async Task<bool> AnybyHeaderandAuthor(string header, string author)
        {
            var result = await _context.Posts.AnyAsync(x => x.Header == header && x.AuthorName == author && x.IsActive == true);
            return result;
        }
    }
}
