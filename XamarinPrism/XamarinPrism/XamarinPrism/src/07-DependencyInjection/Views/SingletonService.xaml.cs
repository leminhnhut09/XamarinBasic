using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPrism.src._07_DependencyInjection.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingletonService : ContentPage
    {
        public SingletonService()
        {
            InitializeComponent();
        }
    }
}