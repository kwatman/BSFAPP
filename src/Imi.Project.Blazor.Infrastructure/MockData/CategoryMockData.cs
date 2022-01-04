using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Infrastructure.MockData
{
    public class CategoryMockData
    {
        public static List<Category> categoryData = new List<Category>
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

        public Category GetCategoryById(Guid id)
        {
            var category = categoryData.FirstOrDefault(c => c.Id == id);

            return category;
        }
    }
}
