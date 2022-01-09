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
        Random random = new Random();
        ProductMockData productMockData;

        public List<Product> Products { get; set; }

        protected override Task OnInitializedAsync()
        {
            productMockData = new ProductMockData();
            Products = ProductMockData.productData;

            return base.OnInitializedAsync();
        }

        public string GetRandomImageUrl()
        {
            int randomizer = random.Next(8);
            string url = string.Empty;

            switch (randomizer)
            {
                case 1:
                    url = "Assets/cake.png";
                    break;
                case 2:
                    url = "Assets/cookie.png";
                    break;
                case 3:
                    url = "Assets/cupcake.png";
                    break;
                case 4:
                    url = "Assets/donut.png";
                    break;
                case 5:
                    url = "Assets/macaron.png";
                    break;
                case 6:
                    url = "Assets/pie.png";
                    break;
                case 7:
                    url = "Assets/puff_pastry.png";
                    break;
                case 8:
                    url = "Assets/roll.png";
                    break;
            }

            return url;
        }
    }
}
