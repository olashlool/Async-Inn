using Async_Inn.Models.DTOs;
using Async_Inn.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    UserDto userDto = new UserDto
                    {
                        Id = user.Id,
                        Username = user.UserName,
                    };
                    return userDto;
                }
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
                UserDto userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
                return userDto;
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

        public Task<ApplicationUser> Register(RegisterUserDto data)
        {
            throw new NotImplementedException();
        }
    }
}
