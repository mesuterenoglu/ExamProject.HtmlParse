

using ExamProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamProject.Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(AppUserDto entity,string password);
        Task<bool> LoginAsync(string userName, string password, bool isPersistent);
        Task LogoutAsync();
        Task NewPasswordAsync();
        Task UpdateAsync(AppUserDto entity);
        Task<AppUserDto> GetbyIdAsync(Guid id);
        Task<AppUserDto> GetbyEmailAsync(string email);
        Task<bool> AnybyEmailAsync(string email);
        Task<bool> AnybyIdAsync(Guid id);
        List<AppUserDto> GetAllActive();
        bool IsSignIn(ClaimsPrincipal principal);
        Task CreateRoleAsync(string role);
        Task<bool> AssignRoleAsync(string email, string role);
        Task<bool> RoleExistAsync(string role);
        Task<bool> IsInRole(string email, string role);
    }
}
