using EcommerceApp.Models;
using EcommerceApp.Services;
using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceApp.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
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
        public ObservableCollection<Product> MenuProductos { get; set; }
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsRefreshing"));
                    }
                }
            }
            get { return isRefreshing; }
        }

        #endregion

        #region constructor
        public MainViewModel()
        {   //singleton
            instance = this;
            Menu = new ObservableCollection<MenuItemViewModel>();
            MenuProductos = new ObservableCollection<Product>();
            Newlogin = new LoginViewModel();
            UserLoget = new UserViewModel();
            //services
            dateService = new DateService();
            apiService = new ApiService();
            dialogService = new DialogService();
            LoadProducts();
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

        public async void LoadProducts()
        {
            IsRefreshing = true;
            if (!CrossConnectivity.Current.IsConnected)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", "Verifica tu Coneccion a internet");
                return;
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                IsRefreshing = false;

                await dialogService.ShowMessage("Error", "Verifica tu Coneccion a internet");
                return;
            }

            var response = await apiService.Get<Product>("http://ecomerce.somee.com", "/api", "/Products");
            if (!response.IsSucces)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }
          
            ReloadProducto((List<Product>)response.Result);
            IsRefreshing = false;
        }
        private void ReloadProducto(List<Product> productos)
        {
            MenuProductos.Clear();

            foreach (var producto in productos)
            {
                MenuProductos.Add(new Product
                {
                    BarCode = producto.BarCode,
                    Category = producto.Category,
                    CategoryId = producto.CategoryId,
                    CompanyId = producto.CompanyId,
                    Company = producto.Company,
                    Description = producto.Description,
                    Image = producto.Image,
                    Inventories = producto.Inventories,
                    Price = producto.Price,
                    ProductId = producto.ProductId,
                    Remarks = producto.Remarks,
                    Stock = producto.Stock,
                    Tax = producto.Tax,
                    TaxId = producto.TaxId,
                    OrderDetailTmps = producto.OrderDetailTmps,
                    OrderDetails = producto.OrderDetails,
                });
            }
        }

        #endregion

        #region Singleton

        static MainViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Command
       
        public ICommand RefreshProductCommand  { get {return new RelayCommand(LoadProducts); } }
        #endregion
    }
}
