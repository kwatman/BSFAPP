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
    public partial class AdminCategoriesPage : ContentPage
    {
        private readonly ICategoryService categoryService;
        public AdminCategoriesPage()
        {
            InitializeComponent();

            categoryService = new CategoryMockService();
        }
        private void ShowCategories()
        {
            var categories = categoryService.GetAll(context: CategoryMockData.categoryData);
            lvCategories.ItemsSource = categories;
        }

        protected override void OnAppearing()
        {
            ShowCategories();
            base.OnAppearing();
        }
        private async void CategoryUpdate_Clicked(object sender, EventArgs e)
        {
            var selectedCategory = ((MenuItem)sender).CommandParameter as Category;
            await DisplayAlert("Edit", $"Editing {selectedCategory.Name}", "OK");
            await Navigation.PushAsync(new AdminCategoryCUPage(selectedCategory));

        }

        private async void CategoryDelete_Clicked(object sender, EventArgs e)
        {
            var selectedCategory = ((MenuItem)sender).CommandParameter as Category;
            await categoryService.Delete(CategoryMockData.categoryData, selectedCategory.Id);
            ShowCategories();
        }

        private async void btnAddCategory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminCategoryCUPage(null));
        }
    }
}