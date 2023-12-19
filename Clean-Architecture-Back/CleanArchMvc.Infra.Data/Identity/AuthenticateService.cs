﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticateService(SignInManager<IdentityUser> signInManager, UserManager<AplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }
        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new AplicationUser
            {
                UserName = email,
                Email = email,
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return result.Succeeded;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}