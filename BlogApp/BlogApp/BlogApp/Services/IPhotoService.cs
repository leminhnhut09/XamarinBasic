using BlogApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Services
{
    public interface IPhotoService
    {
        [Get("/photos?_start=30&_limit=50")]
        Task<List<Photo>> GetPhotos();
    }
}
