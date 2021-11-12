using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic.Source.Tuan1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailLoginPage : ContentPage
    {
        public DetailLoginPage(string user, string pass)
        {
            InitializeComponent();
            userNameLabel.Text = user;
            passwordLabel.Text = pass;
        }
    }
}