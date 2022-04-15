using AutoMapper;
using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using ExamProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager,RoleManager<IdentityRole<Guid>> roleManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public async Task<bool> AnybyEmailAsync(string email)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AnybyIdAsync(Guid id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(id.ToString());
                if (appUser == null)
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> AssignRoleAsync(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _roleManager.RoleExistsAsync(role);

            if (user!= null && result)
            {
                var response = await _userManager.AddToRoleAsync(user, role);
                if (response.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task CreateRoleAsync(string role)
        {
            var result = await _roleManager.RoleExistsAsync(role);
            if (!result)
            {
                await _roleManager.CreateAsync(new IdentityRole<Guid> {
                     Id = Guid.NewGuid(),
                     Name = role
                });
            }
        }

        public List<AppUserDto> GetAllActive()
        {
            try
            {
                var users = _userManager.Users.Where(x => x.IsActive == true).ToList();
                var list = _mapper.Map<List<AppUserDto>>(users);
                return list;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AppUserDto> GetbyEmailAsync(string email)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                var appUserDto = _mapper.Map<AppUserDto>(appUser);

                return appUserDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<AppUserDto> GetbyIdAsync(Guid id)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(id.ToString());
                if (appUser == null)
                {
                    throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı!");
                }
                var appUserDto = _mapper.Map<AppUserDto>(appUser);

                return appUserDto;

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> IsInRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
               return await _userManager.IsInRoleAsync(user, "Admin");
            }
            return false;
        }

        public bool IsSignIn(ClaimsPrincipal principal)
        {
            var result =  _signInManager.IsSignedIn(principal);
            return result;
        }

        public async Task<bool> LoginAsync(string userName, string password,bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, true);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }


        public async Task LogoutAsync()
        {
           await _signInManager.SignOutAsync();
        }

        public Task NewPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(AppUserDto entity, string password)
        {
            try
            {
                var appUser = _mapper.Map<AppUser>(entity);
                appUser.Id = Guid.NewGuid();
                appUser.IsActive = true;
                appUser.UserName = entity.Email;
                var result = await _userManager.CreateAsync(appUser, password);
                if (result.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> RoleExistAsync(string role)
        {
            return await _roleManager.RoleExistsAsync(role);
        }

        public Task UpdateAsync(AppUserDto entity)
        {
            
            throw new NotImplementedException();
        }
    }
}
