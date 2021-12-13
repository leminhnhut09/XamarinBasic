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
        public async Task<List<Photo>> GetPhotos(int start, int limit)
        {
            try
            {
                var responseUser = RestService.For<IPhotoService>("http://jsonplaceholder.typicode.com");
                var photos = await responseUser.GetPhotos(start, limit);
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
