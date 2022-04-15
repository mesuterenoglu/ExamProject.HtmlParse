using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.MVC.GetPosts;
using ExamProject.MVC.Models;
using ExamProject.MVC.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ExamProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public HomeController(ILogger<HomeController> logger,IUserService userService, IPostService postService)
        {
            _logger = logger;
            _userService = userService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUserDto appUserDto = new AppUserDto();
                appUserDto.Id = Guid.NewGuid();
                appUserDto.FirstName = registerVM.FirstName;
                appUserDto.LastName = registerVM.LastName;
                appUserDto.Email = registerVM.Email;
                var result = await _userService.RegisterAsync(appUserDto, registerVM.Password);
                if (result)
                {
                    await _userService.LoginAsync(registerVM.Email,registerVM.Password,false);
                    return RedirectToAction("Index","Home");
                }
                return View(registerVM);
            }
            
            return View(registerVM);
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe);
                if (result)
                {
                    // Todo: If user role is admin
                    GetPostsFromWired getPostsFromWired = new GetPostsFromWired(_postService);
                    getPostsFromWired.GetPosts();
                    return RedirectToAction("Index", "Home");
                }
                return View(loginVM);
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult HeaderPartial()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
