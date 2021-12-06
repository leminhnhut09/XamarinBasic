using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinPrism.src._11_Api.Models;

namespace XamarinPrism.src._11_Api.Services
{
    public interface IMakeUp
    {
        //[Get("/api/v1/products.json?brand={brand}&product_type={productType}")]
        //Task<List<MakeUp>> GetMakeUps(string brand, string productType);

        [Get("/api/v1/products.json?brand={brand}")]
        Task<List<MakeUp>> GetMakeUps(string brand);
    }
}
