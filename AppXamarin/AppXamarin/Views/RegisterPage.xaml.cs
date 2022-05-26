using AppXamarin.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void RegisterClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Error", "Se requieren todos los datos", "OK");
                return;
            }
            else
            {
                User user = new User
                {
                    Name = name.Text,
                    Email = email.Text,
                    Password = password.Text,
                    Role = "Cliente"
                };

                await App.Database.SaveUserAsync(user);

                await DisplayAlert("OK", $"Registro exitoso", "OK");
                await Navigation.PushAsync(new LoginPage());
                await Navigation.PopAsync();
            }
        }
    }
}