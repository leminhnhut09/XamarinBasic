using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Models
{
    public class Post
    {
        public string UserName { get; set; }
        public string TitleAlbum { get; set; }
        public string TitlePhoto { get; set; }
        public string ThumbnailUrl { get; set; }
        public Post()
        {

        }
        public Post(string userName, string titleAlbum, string titlePhoto, string thumbUrl)
        {
            UserName = userName;
            TitleAlbum = titleAlbum;
            TitlePhoto = titlePhoto;
            ThumbnailUrl = thumbUrl;
        }
    }
}
