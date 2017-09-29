using EcommerceApp.Pages;
using EcommerceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using EcommerceApp.Models;
using EcommerceApp.ViewModels;

namespace EcommerceApp
{
    public partial class App : Application
    {
        #region Attributes
        private DateService dateService=new DateService();
        #endregion

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        public static User CurrentUser { get; internal set; }
        #endregion


        public App()
        {
            InitializeComponent();
            var user = dateService.GetUser();
            if (user!=null && user.IsRemembered)
            {
                var mainViewmodel = MainViewModel.GetInstance();
                mainViewmodel.LoadUser(user);
                App.CurrentUser = user;
                MainPage = new MasterPage();
            }
            else { MainPage = new LoginPage(); }

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
