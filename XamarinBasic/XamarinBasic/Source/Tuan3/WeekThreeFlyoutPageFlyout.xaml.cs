using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Source.Tuan3.BindableProperty;
using XamarinBasic.Source.Tuan3.Converter;
using XamarinBasic.Source.Tuan3.CustomRenderer;
using XamarinBasic.Source.Tuan3.Databinding;
using XamarinBasic.Source.Tuan3.Effects;
using XamarinBasic.Source.Tuan3.GesturesRegconizer;

namespace XamarinBasic.Source.Tuan3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekThreeFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public WeekThreeFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new WeekThreeFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class WeekThreeFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<WeekThreeFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public WeekThreeFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<WeekThreeFlyoutPageFlyoutMenuItem>(new[]
                {
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 0, Title = "Effect", TargetType= typeof(EffectPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 1, Title = "CustomRenderer", TargetType= typeof(CustomRendererPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 2, Title = "Databinding", TargetType= typeof(DataBindingTabbedPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 3, Title = "Converter", TargetType= typeof(ConverterTabbedPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 4, Title = "Binable Property", TargetType= typeof(BindablePropertyPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 5, Title = "Command", TargetType= typeof(XamarinBasic.Source.Tuan3.CommandDelegate.Views.CommandTabbedPage), Icon="check.png" },
                    new WeekThreeFlyoutPageFlyoutMenuItem { Id = 6, Title = "GesturesRecognizer", TargetType= typeof(GesturesTabbedPage), Icon="check.png" }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}