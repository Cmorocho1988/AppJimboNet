using AppXamarin.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            CreateAdminAccount();
            InitializeComponent();
        }

        async void CreateAdminAccount()
        {
            var result = await App.Database.AdminAccount("admin@admin.com");

            if (result == null)
            {
                User user = new User
                {
                    Name = "Administrador",
                    Email = "admin@admin.com",
                    Password = "admin",
                    Role = "Admin"
                };

                await App.Database.SaveUserAsync(user);
            }
        }
        
        async void LoginClick(object obj, EventArgs args)
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Error", "Por favor ingrese nombre de usuario y contraseña", "OK");
            }
            else
            {
                var user = new User() { Email = email.Text, Password = password.Text };

                var result = await App.Database.Login(user);
                
                if (result != null)
                {
                    await DisplayAlert("Exitoso", $"Bienvenido {result.Name}", "OK");

                    Preferences.Set("UserRol", result.Role);
                    
                    var homePage = new HomePage();
                    homePage.BindingContext = new HomePage();
                    Application.Current.MainPage = homePage;
                }
                else
                {
                    await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos", "OK");
                }
            }
        }

        async void RegisterClick(object obj, EventArgs args)
        {
            await Navigation.PushAsync(new RegisterPage());                
        }
    }
}