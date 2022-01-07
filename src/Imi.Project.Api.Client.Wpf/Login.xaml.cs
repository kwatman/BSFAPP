using Imi.Project.Api.Core.DTO_S.Users;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            var request = new UserLoginRequestDTO
            {
                Email = txtEmail.Text,
                Password = txtPassword.Password,
            };

            var jsonData = JsonConvert.SerializeObject(request);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5001/api/users/login", content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<UserResponseDTO>(responseBody);

            if (responseObject.IsSuccess)
            {
                NavigationService.Navigate(typeof(ProductsOverview), responseObject.Message);
            }
            else
            {
                lblMessage.Content = responseObject.Message.ToString();
            }
        }
    }
}
