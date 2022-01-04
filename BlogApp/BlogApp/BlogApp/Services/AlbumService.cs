using BlogApp.Helpers;
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
                var responseUser = RestService.For<IAlbumService>(ContainsKey.HostKey);
                var albums = await responseUser.GetAlbums();
                return albums;
            }
            catch (ValidationApiException validationException)
            {
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.RequestMessage);
            }
            return null;
        }
    }
}
