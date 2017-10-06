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
    public class ProductItemViewModel:  INotifyPropertyChanged
    {
        #region Attributes
        private ApiService apiService;
        private bool isRefreshing = false;
        private DialogService dialogService = new DialogService();
        
        #endregion

        #region Properties
        public ObservableCollection<Product> MenuProductos { get; set; }
        
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

        #region Constructor
        public ProductItemViewModel()
        {
            isRefreshing = false;
            apiService = new ApiService();
            MenuProductos = new ObservableCollection<Product>();
            
        }
        
        #endregion

        #region Methos
        public async void LoadProducts()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {  IsRefreshing = false;
                //int millis = 1000;
                await dialogService.ShowMessage("Error", "Verifica tu Coneccion a internet");
                return;
            }
            var isreachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isreachable)
            {
                isRefreshing = false;
                await dialogService.ShowMessage("error", "verifica tu coneccion a internet");
                return;
            }
            var response = await apiService.Get<Product>("http://ecomerce.somee.com", "/api", "/Products");
            if (!response.IsSucces)
            {
                IsRefreshing = false;
                await dialogService.ShowMessage("Error", response.Message);
                return;
            }
            IsRefreshing = false;
            ReloadProducto((List<Product>)response.Result);
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

        #region Commands
       public ICommand RefreshProduct { get { return new RelayCommand(LoadProducts); } }
        #endregion

#region Events

public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
}
