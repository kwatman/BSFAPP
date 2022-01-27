using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Infrastructure.MockData;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages
{
    public partial class ProductsDetail
    {

        ProductMockData productMockData;
        CategoryMockData categoryMockData;

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }

        [Parameter]
        public Guid ProductId { get; set; }

        protected override Task OnInitializedAsync()
        {
            productMockData = new ProductMockData();
            categoryMockData = new CategoryMockData();

            Products = ProductMockData.productData;
            Categories = CategoryMockData.categoryData;

            Product = Products.FirstOrDefault(p => p.Id == ProductId);
            Category = categoryMockData.GetCategoryById(Product.CategoryId);

            return base.OnInitializedAsync();
        }
    }
}
