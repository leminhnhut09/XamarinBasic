using BlogApp.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public class AlbumService : IAlbumService
    {
        public async Task<List<Album>> GetAlbums()
        {
            try
            {
                var responseUser = RestService.For<IAlbumService>("http://jsonplaceholder.typicode.com");
                var albums = await responseUser.GetAlbums();
                return albums;
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
