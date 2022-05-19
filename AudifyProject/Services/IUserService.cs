using AudifyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public interface IUserService
    {
        public Task<bool> Register(RegisterViewModel registerViewModel);
        public Task<UserTokenInfo> FindByName(string UserName);
    }
}
