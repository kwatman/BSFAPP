using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Infrastructure.Services.Mocking
{
    public class CategoryMockService
    {
        private static List<Category> categories = new List<Category>
        {
            new Category
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Taart"
            },
            new Category
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Gebak"
            },
            new Category
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Koekjes met glazuur"
            },
            new Category
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Koekjes met rolfondant"
            }
        };
    }
}
