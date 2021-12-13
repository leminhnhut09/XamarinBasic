using BlogApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class AlbumService : IAlbumService
    {
        public async Task<List<Album>> GetAlbums()
        {
            try
            {
                //var nullTask = Task.FromResult<Exception>(null);
                //var setting = new RefitSettings
                //{
                //    ExceptionFactory = httpResponse => nullTask
                //};

                //var settings = new RefitSettings
                //{
                //    ContentSerializer = new NewtonsoftJsonContentSerializer()
                //};


                var responseUser = RestService.For<IAlbumService>("http://jsonplaceholder.typicode.com");
                var albums = await responseUser.GetAlbums();
                return albums;
            }
            catch (ValidationApiException validationException)
            {
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.RequestMessage);
                //exception handling
            }
            return null;
        }
    }
}
