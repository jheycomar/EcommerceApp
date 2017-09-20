using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public LoginViewModel Newlogin { get; set; } 

        #endregion

        #region constructor
        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            Newlogin = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Methos
        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Icon = "shoping.png",
                PageName = "ProductsPage",
                Title = "Productos",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "user.png",
                PageName = "CustomersPage",
                Title = "Clientes",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "pedidos.png",
                PageName = "OrdersPage",
                Title = "Pedidos",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "entrega.png",
                PageName = "DeliveriesPage",
                Title = "Entregas",
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "Update.png",
                PageName = "SyncPage",
                Title = "Sincronisar",
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "configurar.png",
                PageName = "SetupPage",
                Title = "Configuracion",
            });
            Menu.Add(new MenuItemViewModel
            {
                Icon = "Salir.png",
                PageName = "LogutPage",
                Title = "Salir",
            });
        } 
        #endregion

    }
}
