using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Infrastructure.Services.MockData;
using Imi.Project.Mobile.Infrastructure.Services.Mocking;
using Imi.Project.Mobile.Infrastructure.Services.MockServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProductsPage : ContentPage
    {
        private readonly IProductService _productService;
        public AdminProductsPage()
        {
            InitializeComponent();
        }

        public AdminProductsPage(IProductService productService)
        {
            _productService = productService;
        }

        private void ShowProducts()
        {
            var products = _productService.GetAll();
            lvProducts.ItemsSource = (System.Collections.IEnumerable)products;
        }

        protected override void OnAppearing()
        {
            ShowProducts();
            base.OnAppearing();
        }

        private async void ProductUpdate_Clicked(object sender, EventArgs e)
        {
            var selectedProduct = ((MenuItem)sender).CommandParameter as Product;
            await DisplayAlert("Edit", $"Editing {selectedProduct.Name}", "OK");
            await Navigation.PushAsync(new AdminProductCUPage(selectedProduct));

        }

        private async void ProductDelete_Clicked(object sender, EventArgs e)
        {
            var selectedProduct = ((MenuItem)sender).CommandParameter as Product;
            await _productService.Delete(selectedProduct.Id);
            ShowProducts();
        }

        private async void btnAddProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminProductCUPage(null));
        }
    }
}