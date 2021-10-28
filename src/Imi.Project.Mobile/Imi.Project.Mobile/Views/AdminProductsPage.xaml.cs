using Imi.Project.Mobile.Infrastructure.Services;
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

namespace Imi.Project.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProductsPage : ContentPage
    {
        private readonly IProductService productService;
        public AdminProductsPage()
        {
            InitializeComponent();

            productService = new ProductMockService();
        }

        private void ShowProducts()
        {
            var products = productService.GetAll(context: ProductMockData.productData);
            lvProducts.ItemsSource = products;
        }

        protected override void OnAppearing()
        {
            ShowProducts();
            base.OnAppearing();
        }
    }
}