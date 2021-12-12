using BlogApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public interface IAlbumService
    {
        //[Get("/albums")]
        //Task<List<Album>> GetAlbums();
        [Get("/albums")]
        Task<List<Album>> GetAlbums();
    }
}
