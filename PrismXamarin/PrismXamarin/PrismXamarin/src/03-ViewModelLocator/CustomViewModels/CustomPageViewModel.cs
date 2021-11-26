using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismXamarin.src._03_ViewModelLocator.CustomViewModels
{
    public class CustomPageViewModel : BindableBase
    {
        private string _title = "Custom Model";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
