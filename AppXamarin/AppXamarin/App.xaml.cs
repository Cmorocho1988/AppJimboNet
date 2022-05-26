using AppXamarin.Services;
using AppXamarin.Views;
using AppXamarin.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using AppXamarin.Models;

namespace AppXamarin
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        
        public App()
        {
            InitializeComponent();
      
            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new HomePage();
        }
        
        public static SQLiteHelper Database
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ecomerce.db3"));
                }
                return db;
            }
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
