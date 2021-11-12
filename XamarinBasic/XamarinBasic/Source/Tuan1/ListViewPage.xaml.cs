using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBasic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductViewModel();
        }
        public class ProductViewModel
        {
            public ObservableCollection<Product> Collection { get; set; }
            public ProductViewModel()
            {
                Collection = new ObservableCollection<Product>(Product.GetListProduct());
            }
        }

        private void OnRemoveButtonClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as ProductViewModel;
            if (viewModel != null && viewModel.Collection.Any())
            {
                viewModel.Collection.Remove(viewModel.Collection.Last());
            }
        }

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectProduct = e.SelectedItem as Product;
            DisplayAlert("Detail", $"Id: {selectProduct.IdProduct}\nName: {selectProduct.NameProduct}\nPrice: {selectProduct.Price}", "Close");
        }
    }
}