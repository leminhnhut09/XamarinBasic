using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._07_DependencyInjection.Interfaces
{
    //public interface ICustomService
    //{
    //    int NumberValue { get; set; }
    //}
    public interface ICustomService
    {
        List<int> ListCustomer { get; set; }
    }
}
