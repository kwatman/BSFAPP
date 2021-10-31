using Imi.Project.Blazor.Core.Models;
using Imi.Project.Blazor.Infrastructure.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages
{
    public partial class ProductsOverview
    {
        ProductMockData productMockData;

        public List<Product> Products { get; set; }

        protected override Task OnInitializedAsync()
        {
            productMockData = new ProductMockData();
            Products = ProductMockData.productData;

            return base.OnInitializedAsync();
        }
    }
}
