using Imi.Project.Api.Core.DTO_S.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Imi.Project.Api.Client.Wpf
{
    /// <summary>
    /// Interaction logic for ProductsOverview.xaml
    /// </summary>
    public partial class ProductsOverview : Page
    {
        public ProductsOverview()
        {
            InitializeComponent();
            ShowProducts();
        }

        protected async void ShowProducts()
        {
            // string token = e.ToString();

            HttpClient client = new HttpClient();

            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            var response = await client.GetAsync("https://localhost:5001/api/products");

            var responseBody = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<ProductResponseDTO>>(responseBody);

            lstProducts.ItemsSource = products;
        }
    }
}
