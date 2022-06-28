using Async_Inn.Models.DTOs;
using Async_Inn.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            tokenService = jwtTokenService;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (await _userManager.CheckPasswordAsync(user, password))
            {
                return await GetUserDtoAsync(user);
            }

            if (user != null)
            {
                await _userManager.AccessFailedAsync(user);
            }
            return null;
        }

        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                if (data.Roles?.Any() == true)
                {
                    await _userManager.AddToRolesAsync(user, data.Roles);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "guest");
                }

                return await GetUserDtoAsync(user);
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                  error.Code.Contains("Password") ? nameof(data.Password) :
                  error.Code.Contains("Email") ? nameof(data.Email) :
                  error.Code.Contains("UserName") ? nameof(data.Username) :
                  "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        // Use a "claim" to get a user
        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return await GetUserDtoAsync(user);

        }

        private async Task<UserDto> GetUserDtoAsync(ApplicationUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, TimeSpan.FromMinutes(5)),
                Roles = await _userManager.GetRolesAsync(user),
            };
        }


        public Task<ApplicationUser> Register(RegisterUserDto data)
        {
            throw new NotImplementedException();
        }
    }
}
