using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public interface ILoginFacebookService
    {
        Task Login(Action<Account, string> onLoginComplete);
        void Logout();
    }
}
