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
    public class UserViewModel:INotifyPropertyChanged
    {

        #region Attributes
        private ApiService apiService;
       
        private DialogService dialogService = new DialogService();
       
        #endregion

        #region Properties
        public string FullName { get; set; }
        public string Photo { get; set; }       

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
        

        public UserViewModel()
        {
            apiService = new ApiService();
          
        }
        #region Methos

        #endregion

        #region Commands
        
        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

    }
}
