using AppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsNewPage : ContentPage
    {
        public ProductsNewPage()
        {
            InitializeComponent();
        }

        async void RegisterProduct(object sneder, EventArgs eventArgs)
        {
            if(ValidarCampos())
            {
                var product = new Product()
                {
                    Name = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    Description = txtDescription.Text,
                    Image = txtImage.Text,
                    Category = txtCategory.Text,
                    Stock = int.Parse(txtStock.Text)
                };

                await App.Database.SaveProductAsync(product);

                await DisplayAlert("Producto Registrado", "El producto se ha registrado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar todos los campos", "Aceptar");
            }
        }

        bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                txtPrice.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtStock.Text))
            {
                txtStock.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtImage.Text))
            {
                txtImage.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                txtCategory.Focus();
                return false;
            }
            return true;
        }
    }
}