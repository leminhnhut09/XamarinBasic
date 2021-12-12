using BlogApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class UserService : IUserService
    {
        public async Task<List<User>> GetUsers()
        {
            try
            {
                var responseUser = RestService.For<IUserService>("http://jsonplaceholder.typicode.com");
                var users = await responseUser.GetUsers();
                return users;
            }
            catch (ValidationApiException validationException)
            {
            }
            catch (ApiException ex)
            {
                //exception handling
            }
            return null;
        }
    }
}
