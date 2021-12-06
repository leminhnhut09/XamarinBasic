using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._04_NavigationService.Models
{
    public class Character : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }

        public Character(string name, int age, DateTime birthDay)
        {
            Name = name;
            Age = age;
            BirthDay = birthDay;
        }
    }
}
