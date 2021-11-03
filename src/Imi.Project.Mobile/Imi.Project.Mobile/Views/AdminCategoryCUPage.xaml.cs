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

namespace Imi.Project.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminCategoryCUPage : ContentPage
    {
        private readonly ICategoryService categoryService;
        private Category selectedCategory;
        private bool newCategory = true;
        public AdminCategoryCUPage(Category category)
        {
            InitializeComponent();

            categoryService = new CategoryMockService();

            if (category == null)
            {
                selectedCategory = new Category();
            }
            else
            {
                newCategory = false;
                selectedCategory = category;
            }
        }

        protected override void OnAppearing()
        {
            txtName.Text = selectedCategory.Name;
            base.OnAppearing();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            selectedCategory.Name = txtName.Text;
            
            if (newCategory)
            {
                selectedCategory.Id = Guid.NewGuid();
                selectedCategory.Products = null;

                await categoryService.Add(CategoryMockData.categoryData, selectedCategory);
            }
            else
            {
                await categoryService.Update(CategoryMockData.categoryData, selectedCategory);
            }

            await DisplayAlert("Opgeslagen", $"Category met naam {selectedCategory.Name} opgeslagen", "Ok");
        }
    }
}