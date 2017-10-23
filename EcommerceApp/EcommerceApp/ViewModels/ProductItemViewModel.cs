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
            
        }
        
        #endregion

        #region Methos
  
        #endregion

        #region Commands
    //   public ICommand RefreshProduct { get { return new RelayCommand(LoadProducts); } }
        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
}
