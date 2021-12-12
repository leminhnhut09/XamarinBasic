using BlogApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class PhotoService : IPhotoService
    {
        public async Task<List<Photo>> GetPhotos()
        {
            try
            {
                var responseUser = RestService.For<IPhotoService>("http://jsonplaceholder.typicode.com");
                var photos = await responseUser.GetPhotos();
                return photos;
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
