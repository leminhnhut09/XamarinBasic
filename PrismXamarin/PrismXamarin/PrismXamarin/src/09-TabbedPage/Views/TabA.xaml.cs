using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismXamarin.src._09_TabbedPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabA : ContentPage
    {
        public TabA()
        {
            InitializeComponent();
            ListView listView = new ListView()
            {
                ItemsSource = new List<string>()
                {
                    "A", "B", "C", "D"
                },
                //SelectionMode = ListViewSelectionMode.None,
                SeparatorVisibility = SeparatorVisibility.None,
                //SelectedItem="F"
                RowHeight = 100,
                Opacity = 0.5,
                IsPullToRefreshEnabled = true,
                Header="Header",
                Footer="Footer"
            };
            layout.Children.Add(listView);
        }
    }
}