using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetUser(ClaimsPrincipal user);


    }
}
