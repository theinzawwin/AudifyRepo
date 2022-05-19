using AudifyProject.Models;
using AudifyProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserService> _logger;
        public UserService(UserManager<ApplicationUser> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<UserTokenInfo> FindByName(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            UserTokenInfo userToken=null;
            if(user != null)
            {
                userToken = new UserTokenInfo()
                {
                    UserName = user.UserName,

                };
            }
            return userToken;
        }

        public async Task<bool> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                var appUser = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,

                };
                var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    _userManager.AddToRoleAsync(appUser, "User").Wait();
                }
                return true;

            }catch(Exception e)
            {
                throw e;
            }


        }
       }
}
