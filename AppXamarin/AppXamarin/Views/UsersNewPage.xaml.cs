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
    public partial class UsersNewPage : ContentPage
    {
        public UsersNewPage()
        {
            InitializeComponent();
        }

        public void CreateUser(object sender, EventArgs args)
        {
            string role = "";

            if(ValidarFormulario())
            {
                if (filter.Items[filter.SelectedIndex] == "Administrador")
                {
                    role = "Admin";
                }
                else
                {
                    role = "Cliente";
                }
                
                var user = new Models.User
                {
                    Name = name.Text,
                    Email = email.Text,
                    Password = password.Text,
                    Role = role
                };

                App.Database.SaveUserAsync(user);

                DisplayAlert("Confirmación", "Usuario creado correctamente", "Aceptar");
            }
        }

        bool ValidarFormulario()
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                DisplayAlert("Error", "El campo nombre es obligatorio", "Aceptar");
                name.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(email.Text))
            {
                DisplayAlert("Error", "El campo email es obligatorio", "Aceptar");
                email.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                DisplayAlert("Error", "El campo password es obligatorio", "Aceptar");
                password.Focus();
                return false;
            }

            if (filter.SelectedIndex != null && filter.SelectedIndex >= 0)
            {
                return true;
            }
            else
            {
                DisplayAlert("Error", "El campo role es obligatorio", "Aceptar");
                filter.Focus();
                return false;
            }

            return true;
        }
    }
}