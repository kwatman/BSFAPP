using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.MockData;
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
    public partial class AdminBlogPostPage : ContentPage
    {
        private readonly IBlogPostService blogPostService;
        public AdminBlogPostPage()
        {
            InitializeComponent();
            blogPostService = new BlogPostMockService();
        }

        private void ShowBlogPosts()
        {
            var blogPosts = blogPostService.GetAll(context: BlogPostMockData.blogPostData);
            lvBlogPost.ItemsSource = blogPosts;
        }

        protected override void OnAppearing()
        {
            ShowBlogPosts();
            base.OnAppearing();
        }

        private async void BlogPostUpdate_Clicked(object sender, EventArgs e)
        {
            var selectedBlogPost = ((MenuItem)sender).CommandParameter as BlogPost;
            await DisplayAlert("Edit", $"Editing {selectedBlogPost.Title}", "OK");
            await Navigation.PushAsync(new AdminBlogPostUpdatePage());
        }

        private async void BlogPostDelete_Clicked(object sender, EventArgs e)
        {
            var selectedBlogPost = ((MenuItem)sender).CommandParameter as BlogPost;
            await blogPostService.Delete(BlogPostMockData.blogPostData, selectedBlogPost.Id);
            ShowBlogPosts();
        }
    }
}