using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBasic.Themes;

namespace XamarinBasic.Source.Tuan2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BehaviorsPage : ContentPage
    {
        public BehaviorsPage()
        {
            InitializeComponent();
            List<string> listTheme = new List<string>()
            {
                "Dark", "Light"
            };
            themePicker.ItemsSource = listTheme;

        }

        private void OnPickerSelectedChange(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string theme = (string)picker.SelectedItem;

            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case "Dark":
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case "Light":
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
    }
}