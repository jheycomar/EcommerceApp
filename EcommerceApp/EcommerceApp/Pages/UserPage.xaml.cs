using EcommerceApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcommerceApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            var mainViewModel = MainViewModel.GetInstance();
            base.Appearing += (object sender, EventArgs e) =>
            {
                mainViewModel.RefreshProductCommand.Execute(this);
            };
            InitializeComponent();

           
        }
       

    }
}