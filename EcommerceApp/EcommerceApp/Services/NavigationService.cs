using EcommerceApp.Models;
using EcommerceApp.Pages;
using EcommerceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Services
{
    public class NavigationService
    {
        private DateService dateService;
        public NavigationService()
        {
            dateService = new DateService();
        }
        public async Task Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            
            switch (pageName)
            {
                case "CustomersPage":
                    await App.Navigator.PushAsync(new CustomersPage());
                    break;
                case "DeliveriesPage":
                    await App.Navigator.PushAsync(new DeliveriesPage());
                    break;
                case "OrdersPage":
                    await App.Navigator.PushAsync(new OrdersPage());
                    break;
                case "ProductsPage":
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.NewProductos = new ProductItemViewModel();
                    await App.Navigator.PushAsync(new ProductsPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "SyncPage":
                    await App.Navigator.PushAsync(new SyncPage());
                    break;
                case "UserPage":
                    await App.Navigator.PushAsync(new UserPage());
                    break;
                case "LogutPage":
                    logaut();

                    break;
                default:
                    break;
            }
        }

      public User GetCurrentUser()
        {
            return App.CurrentUser;
        }

        private void logaut()
        {
            App.CurrentUser.IsRemembered = false;
            dateService.UpdateUser(App.CurrentUser);
            App.Current.MainPage = new LoginPage();
        }

        internal void SetMainPage(User user)
        {
            var mainViewmodel = MainViewModel.GetInstance();
            mainViewmodel.LoadUser(user);
            App.CurrentUser = user;
            App.Current.MainPage = new MasterPage();
        }
    }
}
