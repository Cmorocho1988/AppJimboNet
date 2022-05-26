using AppXamarin.Models;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        public List<Product> Products = new List<Product>();

        public HomePageDetail()
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
            var role = Preferences.Get("UserRol", "");

            this.Products = new List<Product>();

            foreach(Product p in App.Database.GetProductsAsync(categoryName).Result)
            {
                if (role.Equals("Admin"))
                    p.haveAccess = true;
                else
                    p.haveAccess = false;

                Products.Add(p);
            }

            this.products.ItemsSource = Products;

            foreach (Product p in Products)
            {
                Console.WriteLine($"Nombre: { p.Name }, HaveAccess: { p.haveAccess }");
            }
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

