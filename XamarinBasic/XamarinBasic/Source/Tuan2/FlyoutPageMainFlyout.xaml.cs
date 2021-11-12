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

namespace XamarinBasic.Source.Tuan2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPageMainFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPageMainFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPageMainFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutPageMainFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPageMainFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutPageMainFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPageMainFlyoutMenuItem>(new[]
                {
                    new FlyoutPageMainFlyoutMenuItem { Id = 0, Title = "Controls", TargetType=typeof(LoginPage), Icon="control.png" },
                    new FlyoutPageMainFlyoutMenuItem { Id = 1, Title = "Layouts", TargetType=typeof(TabbedPageLayouts), Icon="layout.png" },
                    new FlyoutPageMainFlyoutMenuItem { Id = 2, Title = "Behaviors", TargetType=typeof(BehaviorsPage), Icon="check.png" },
                    new FlyoutPageMainFlyoutMenuItem { Id = 3, Title = "ListView", TargetType=typeof(ListViewSelectedItemBehavior), Icon="check.png" },
                    new FlyoutPageMainFlyoutMenuItem { Id = 4, Title = "Animations", TargetType=typeof(AnimationsPage), Icon="check.png" }
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