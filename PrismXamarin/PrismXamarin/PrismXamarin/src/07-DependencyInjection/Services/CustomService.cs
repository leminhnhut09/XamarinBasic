using PrismXamarin.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismXamarin.src._07_DependencyInjection.Services
{
    //public class CustomService : ICustomService
    //{
    //    public int NumberValue { get; set; }

    //    public CustomService() => NumberValue = new Random().Next(1, 1000);
    //}
    public class CustomService : ICustomService
    {
        public List<int> ListCustomer { get; set; }
        public CustomService()
        {
            ListCustomer = GetListCustomer();
        }
        public List<int> GetListCustomer()
        {
            List<int> listNumber = new List<int>();
            Random rd = new Random();
            for (int i = 0; i < 5; i++)
            {
                listNumber.Add(rd.Next(1, 100));
            }
            return listNumber;
        }
    }
}
