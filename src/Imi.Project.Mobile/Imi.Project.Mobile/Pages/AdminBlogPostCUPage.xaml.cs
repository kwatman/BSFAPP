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

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminBlogPostCUPage : ContentPage
    {
        IBlogPostService blogPostService;
        private BlogPost selectedBlogPost;
        private bool newBlogPost = true;
        public AdminBlogPostCUPage(BlogPost blogPost)
        {
            InitializeComponent();
            blogPostService = new BlogPostMockService();

            if (blogPost == null)
            {
                selectedBlogPost = new BlogPost();
                Title = "Nieuwe post";
            }
            else
            {
                newBlogPost = false;
                selectedBlogPost = blogPost;
                Title = selectedBlogPost.Title;
            }
        }

        protected override void OnAppearing()
        {
            LoadBlogPostState();
            base.OnAppearing();
        }

        private void LoadBlogPostState()
        {
            txtTitle.Text = selectedBlogPost.Title;
            edtContent.Text = selectedBlogPost.Content;
        }

        private void SaveBlogPostState()
        {
            selectedBlogPost.Title = txtTitle.Text;
            selectedBlogPost.Content = edtContent.Text;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            SaveBlogPostState();
            if (newBlogPost)
            {
                selectedBlogPost.Id = Guid.NewGuid();
                selectedBlogPost.PostDate = DateTime.Now;

                await blogPostService.Add(BlogPostMockData.blogPostData, selectedBlogPost);
            }
            else
            {
                await blogPostService.Update(BlogPostMockData.blogPostData, selectedBlogPost);
            }
            await DisplayAlert("Opgeslagen", $"Nieuwe blogpost '{selectedBlogPost.Title}' is opgeslagen", "Ok");
        }
    }
}