using XamarinPrism.src._07_DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._07_DependencyInjection.Services
{
    //public class SecondService : ISecondService
    //{
    //    public int NumberValue { get; set; }

    //    public SecondService() => NumberValue = new Random().Next(1, 1000);
    //}

    public class SecondService : ISecondService
    {
        public List<int> ListCustomer { get; set; }
        public SecondService()
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
