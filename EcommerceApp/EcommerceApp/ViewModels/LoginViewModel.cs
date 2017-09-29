using EcommerceApp.Models;
using EcommerceApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceApp.ViewModels
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        #region Attributes
        private NavigationService navigationService;

        private DialogService dialogService;

        private ApiService apiService;

        private DateService dateService;

        #endregion

        #region Properties
        public string User { get; set; }
        public string PassWord { get; set; }
        public bool IsRemembered { get; set; }
   
        private bool isRunning;

        public bool IsRunning
        {
          set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
            get { return isRunning; }
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        { 
            navigationService = new NavigationService();
            dialogService = new DialogService();
            apiService = new ApiService();
            dateService = new DateService();
            IsRemembered = true;
        } 
        #endregion

        #region Commands
        public ICommand LoginCommand { get { return new RelayCommand(login); } }

        private async void login()
        {
            if (string.IsNullOrEmpty(User))
            {
               await dialogService.ShowMessage("Error","Debes ingresar un usuario");
                return;
            }
            if (string.IsNullOrEmpty(PassWord))
            {
                await dialogService.ShowMessage("Error", "Debes ingresar una contraseña");
                return;
            }
            IsRunning = true;
            var response = await apiService.Login(User,PassWord);
            IsRunning = false;
            if (!response.IsSucces)
            {
                await dialogService.ShowMessage("Error", response.Message);
                return;

            }
            var user = (User)response.Result;
            user.IsRemembered = IsRemembered;
            user.Password = PassWord;
            dateService.InsertUser(user);

            navigationService.SetMainPage(user);
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
}
