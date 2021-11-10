using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinBasic
{
    public class Product : INotifyPropertyChanged
    {
        private string _idProduct;
        private string _nameProduct;
        public string IdProduct
        {
            get
            {
                return _idProduct;
            }
            set
            {
                _idProduct = value;
            }
        }

        public string NameProduct
        {
            get
            {
                return _nameProduct;
            }
            set
            {
                _nameProduct = value;
                OnPropertyChanged(nameof(NameProduct));
            }
        }
        public double Price { get; set; }

        public string PriceFormat => Price.ToString("D3");
        public Product()
        {

        }

        public Product(string id, string name, double price)
        {
            IdProduct = id;
            NameProduct = name;
            Price = price;
        }

        public static List<Product> GetListProduct()
        {
            List<Product> listProduct = new List<Product>();
            listProduct.Add(new Product("1", "Iphone 13 Promax", 35000000));
            listProduct.Add(new Product("2", "Samsung S7", 4500000));
            listProduct.Add(new Product("3", "Samsung S9", 5550000));
            listProduct.Add(new Product("4", "Xiaomi", 9000000));
            return listProduct;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
