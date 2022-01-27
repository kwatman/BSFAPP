using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;

namespace Imi.Project.Mobile.Infrastructure.Services.MockData
{
    public class BlogPostMockData
    {
        public static List<BlogPost> blogPostData = new List<BlogPost>
        {
            new BlogPost
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Title = "Recept: Eclairs",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut fermentum condimentum lacus. Cras id libero pellentesque eros tristique mattis. Nam tempus eros ut ipsum sodales accumsan. Sed in sapien mollis, sodales ipsum a, egestas lorem. Nam porta gravida tellus, at venenatis ligula aliquam a. Vestibulum ac bibendum dolor. Integer a felis ac est dapibus lacinia. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed sed ipsum ac elit scelerisque sodales. Aliquam erat volutpat.",
                PostDate = DateTime.ParseExact("23-07-2021 14:15", "dd-MM-yyyy HH:mm", null)
            },
            new BlogPost
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Title = "Nieuw product: Vegan Apple Crumble",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut fermentum condimentum lacus. Cras id libero pellentesque eros tristique mattis. Nam tempus eros ut ipsum sodales accumsan. Sed in sapien mollis, sodales ipsum a, egestas lorem. Nam porta gravida tellus, at venenatis ligula aliquam a. Vestibulum ac bibendum dolor. Integer a felis ac est dapibus lacinia. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed sed ipsum ac elit scelerisque sodales. Aliquam erat volutpat.",
                PostDate = DateTime.ParseExact("18-09-2021 17:49", "dd-MM-yyyy HH:mm", null)
            },
            new BlogPost
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Title = "Glazed in de Krant van West-Vlaanderen",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut fermentum condimentum lacus. Cras id libero pellentesque eros tristique mattis. Nam tempus eros ut ipsum sodales accumsan. Sed in sapien mollis, sodales ipsum a, egestas lorem. Nam porta gravida tellus, at venenatis ligula aliquam a. Vestibulum ac bibendum dolor. Integer a felis ac est dapibus lacinia. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed sed ipsum ac elit scelerisque sodales. Aliquam erat volutpat.",
                PostDate = DateTime.ParseExact("13-10-2021 08:30", "dd-MM-yyyy HH:mm", null)
            }
        };
    }
}