﻿using Async_Inn_2.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Async_Inn_2.Models.Interfaces
{
    
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);
        public Task<UserDTO> GetUser(ClaimsPrincipal user);
    }
}

