using EcommerceApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcommerceApp.ViewModels
{
    public class LoginViewModel
    {
        #region Attributes
        private NavigationService navigationService;

        private DialogService dialogService;

        #endregion

        #region Properties
        public string User { get; set; }
        public string PassWord { get; set; }
        public bool IsRemembered { get; set; }
        #endregion

        #region Constructors
        public LoginViewModel()
        { 
            navigationService = new NavigationService();
            dialogService = new DialogService();
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

            navigationService.SetMainPage();
        } 
        #endregion
    }
}
