using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._05_ListView.Models
{
    public class Product
    {
        public string NameProduct { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public Product(string name, string image, int price)
        {
            NameProduct = name;
            Image = image;
            Price = price;
        }

        public static List<Product> GetListProduct()
        {
            return new List<Product>()
            {
                new Product("Iphone 6", "image.png", 5000000),
                new Product("Iphone 7", "image.png", 5500000),
                new Product("Iphone 8", "image.png", 7000000),
                new Product("Iphone 10", "image.png",7500000),
                new Product("Iphone 11", "image.png", 13000000)
            };
        }
    }

    public class ProductGroup : List<Product>
    {
        public string GroupName { get; set; }
        public ProductGroup(string groupName, List<Product> products) : base(products)
        {
            GroupName = groupName;
        }
    }
}
