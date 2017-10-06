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
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
          
        }
        protected override void OnAppearing()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.NewProductos.RefreshProduct.Execute(this);
            base.OnAppearing();
        }

    }
}