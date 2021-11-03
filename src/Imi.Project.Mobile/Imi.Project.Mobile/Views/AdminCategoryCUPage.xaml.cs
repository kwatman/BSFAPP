using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services;
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
        public AdminCategoryCUPage()
        {
            InitializeComponent();
        }
    }
}