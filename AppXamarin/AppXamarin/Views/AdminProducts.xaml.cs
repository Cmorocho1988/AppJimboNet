using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProducts : ContentPage
    { 
        public AdminProducts()
        {
            InitializeComponent();
            InitProduct("Todos");
            FilterPerCategory();
            PickerFilter();
        }

        void PickerFilter()
        {
            filter.SelectedIndexChanged += async (sender, e) =>
            {
                string category = filter.Items[filter.SelectedIndex];

                InitProduct(category);
            };
        }

        void InitProduct(string categoryName)
        {
            this.products.ItemsSource = App.Database.GetProductsAsync(categoryName).Result;
        }

        public async void DeleteProduct(object sender, EventArgs args)
        {
            var data = (Button)sender;

            await App.Database.DeleteProductAsync(int.Parse(data.BindingContext.ToString()));

            await DisplayAlert("Producto Eliminado", "El producto ha sido eliminado", "OK");

            InitProduct("Todos");
            FilterPerCategory();
        }

        void FilterPerCategory() => filter.ItemsSource = App.Database.GetCategoryNames().Result;
    }
}