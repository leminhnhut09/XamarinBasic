﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._07_DependencyInjection.Interfaces
{
    //public interface ISecondService
    //{
    //    int NumberValue { get; set; }
    //}

    public interface ISecondService
    {
        List<int> ListCustomer { get; set; }
    }
}
