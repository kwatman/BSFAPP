using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services;
using Imi.Project.Mobile.Infrastructure.Services.MockData;
using Imi.Project.Mobile.Infrastructure.Services.Mocking;
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
    public partial class AdminProductCUPage : ContentPage
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private Product selectedProduct;
        private bool newProduct = true;
        public AdminProductCUPage(Product product)
        {
            InitializeComponent();

            productService = new ProductMockService();
            categoryService = new CategoryMockService();

            if (product == null)
            {
                selectedProduct = new Product();
            }
            else
            {
                newProduct = false;
                selectedProduct = product;
            }
        }

        protected override void OnAppearing()
        {
            LoadCategories();
            LoadProductState();
            base.OnAppearing();
        }

        private void LoadCategories()
        {
            var categories = categoryService.GetAll(CategoryMockData.categoryData).ToList();

            pckCategory.ItemsSource = categories;
        }

        private void LoadProductState()
        {
            txtName.Text = selectedProduct.Name;
            edtDescription.Text = selectedProduct.Description;
            txtPrice.Text = selectedProduct.Price.ToString();
            pckCategory.SelectedItem = CategoryMockData.categoryData.Where(c => c.Id == selectedProduct.CategoryId);
        }

        private void SaveProductState()
        {
            Category selectedCategory = (Category)pckCategory.SelectedItem;

            selectedProduct.Name = txtName.Text;
            selectedProduct.Description = edtDescription.Text;
            selectedProduct.Price = Convert.ToDecimal(txtPrice.Text);
            selectedProduct.CategoryId = selectedCategory.Id;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            SaveProductState();

            if (newProduct)
            {
                selectedProduct.Id = Guid.NewGuid();
                selectedProduct.DietaryRequirements = null;

                await productService.Add(ProductMockData.productData, selectedProduct);
            }
            else
            {
                await productService.Update(ProductMockData.productData, selectedProduct);
            }

            await DisplayAlert("Opgeslagen", $"Product met naam {selectedProduct.Name} opgeslagen", "Ok");
        }
    }
}