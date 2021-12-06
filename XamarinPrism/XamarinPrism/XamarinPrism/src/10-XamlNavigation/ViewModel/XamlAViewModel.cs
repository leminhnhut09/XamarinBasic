using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPrism.src._10_XamlNavigation.ViewModel
{
    public class XamlAViewModel : BindableBase, INavigationAware
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Message"))
            {
                Text = parameters.GetValue<string>("Message");
            }

            if (parameters.ContainsKey("More"))
            {
                Text += " " + parameters.GetValue<string>("More");
            }
        }
    }
}
