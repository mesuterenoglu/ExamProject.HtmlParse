using ExamProject.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamProject.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost]
        public async Task<JsonResult> GetbyId([FromBody]Guid id)
        {
            var post = await _postService.GetbyIdAsync(id);
            if (post != null)
            {
                return Json(post.Content);
            }
            throw new InvalidOperationException("Bu id ile post bulunamadı!");
            
        }
    }
}
