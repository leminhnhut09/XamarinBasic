using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinBasic.Source.Tuan3.GesturesRegconizer
{
    public class FoodViewModel
    {
        public ObservableCollection<FoodItem> FoodItems { get; set; }
        public FoodViewModel()
        {
            FoodItems = new ObservableCollection<FoodItem>(FoodItem.GetListFood());
        }
    }
    public class FoodItem
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        public static List<FoodItem> GetListFood()
        {
            return new List<FoodItem>()
            {
                new FoodItem()
                {
                    Title = "Pizza",
                    ImageUrl = "sabo.png",
                    Price = 3
                },
                new FoodItem()
                {
                    Title = "Burget",
                    ImageUrl = "sabo.png",
                    Price = 8
                },
                new FoodItem()
                {
                    Title = "Cocacola",
                    ImageUrl = "chopper.png",
                    Price = 3
                }
            };
        }
    }
}
