using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Infrastructure.MockData
{
    public class ProductMockData
    {
        public static List<Product> productData = new List<Product>()
        {
            new Product
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Clafoutis van kersen",
                Description = "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven.",
                Price = 8.50m,
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                DietaryRequirements = new List<DietaryRequirement>
                {
                    DietaryRequirementMockData.dietaryRequirementData[1]
                }
            },
            new Product
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Marble Cake",
                Description = "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake.",
                Price = 6m,
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                DietaryRequirements = new List<DietaryRequirement>
                {
                    DietaryRequirementMockData.dietaryRequirementData[2],
                    DietaryRequirementMockData.dietaryRequirementData[3]
                }
            },
            new Product
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "6 Vegan Pumpkin Cookies",
                Description = "Vanille vegan koekjes met pompoenglazuur",
                Price = 5m,
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                DietaryRequirements = new List<DietaryRequirement>
                {
                    DietaryRequirementMockData.dietaryRequirementData[0],
                    DietaryRequirementMockData.dietaryRequirementData[1],
                    DietaryRequirementMockData.dietaryRequirementData[2],
                    DietaryRequirementMockData.dietaryRequirementData[3]
                }
            },
            new Product
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "6 Cannelés de Bordeaux",
                Description = "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux",
                Price = 4.50m,
                CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                DietaryRequirements = new List<DietaryRequirement>
                {
                    DietaryRequirementMockData.dietaryRequirementData[2]
                }
            }
        };
    }
}
