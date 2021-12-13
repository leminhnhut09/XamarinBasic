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
        [Get("/photos?_start={start}&_limit={limit}")]
        Task<List<Photo>> GetPhotos(int start, int limit);
    }
}
