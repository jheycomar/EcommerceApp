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
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
      
        #region constructor
        public MainViewModel()
        {
            LoadMenu();
        }
        #endregion

        #region Methos
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "producto.png",
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
                Icon = "AddTag.png",
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
