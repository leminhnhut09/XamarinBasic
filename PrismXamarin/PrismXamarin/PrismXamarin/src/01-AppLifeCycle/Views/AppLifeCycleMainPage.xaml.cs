using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismXamarin.src._01_AppLifeCycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLifeCycleMainPage : ContentPage
    {
        public AppLifeCycleMainPage()
        {
            InitializeComponent();
        }
    }
}