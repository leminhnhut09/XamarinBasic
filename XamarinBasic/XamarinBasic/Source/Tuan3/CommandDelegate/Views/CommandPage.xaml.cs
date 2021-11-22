using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Source.Tuan3.CommandDelegate.ViewModels;

namespace XamarinBasic.Source.Tuan3.CommandDelegate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommandPage : ContentPage
    {
        public CommandPage()
        {
            InitializeComponent();
            MessagingCenter.Unsubscribe<string, string>("this", "mess");
            MessagingCenter.Subscribe<string, string>("this", "mess", (sender, message) => {
                string data = message.ToString();
                resultLabel.Text = data;
            });
            BindingContext = new PushCommandViewModel(Navigation);
        }
    }
}