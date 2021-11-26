using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismXamarin.src._02_PageLifeCycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailLifecyclePage : ContentPage
    {
        public DetailLifecyclePage()
        {
            InitializeComponent();
        }
    }
}