using EcommerceApp.Models;
using EcommerceApp.Services;
using Plugin.Connectivity;
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
        #region Attributes
        private DateService dateService;
        private ApiService apiService;
        private DialogService dialogService;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
       
        public LoginViewModel Newlogin { get; set; }
        public UserViewModel UserLoget { get; set; }
        public ProductItemViewModel NewProductos { get; set; }

        #endregion

        #region constructor
        public MainViewModel()
        {   //singleton
            instance = this;
            Menu = new ObservableCollection<MenuItemViewModel>();          
            Newlogin = new LoginViewModel();
            UserLoget = new UserViewModel();
            //services
            dateService = new DateService();
            apiService = new ApiService();
            dialogService = new DialogService();

            LoadMenu();
          
           
        }

       


        #endregion

        #region Methos
        public void LoadUser(User user)
        {
           UserLoget.FullName = user.FullName;
           UserLoget.Photo = user.PhotoFullPath;         
           
        }
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
                Title = "Cerrar sesion",
            });
        }
             
        #endregion

        #region Singleton

        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion


    }
}
