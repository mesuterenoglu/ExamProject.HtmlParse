
using ExamProject.Application.Mapping;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.Application.Services;
using ExamProject.Domain.Entities;
using ExamProject.Domain.Interfaces;
using ExamProject.Infrustracture.Context;
using ExamProject.Infrustracture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExamProject.Application.DIContainer
{
    public static class DIContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => 
                x.UseLazyLoadingProxies()
                .UseSqlite(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly("ExamProject.Infrustracture")));

            services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedEmail = false;

                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<AppDbContext>();


            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/Home/Login");
                x.AccessDeniedPath = new PathString("/Home/Denied");
                x.Cookie = new CookieBuilder
                {
                    Name = "dotnetAuthCookie"
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();

            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionOptionService, QuestionOptionService>();
            services.AddScoped<IUserService, UserService>();


            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
