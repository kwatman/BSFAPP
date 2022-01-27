using Imi.Project.Blazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Infrastructure.MockData
{
    public class DietaryRequirementMockData
    {
        public static List<DietaryRequirement> dietaryRequirementData = new List<DietaryRequirement>
        {
            new DietaryRequirement
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Name = "Vegan"
            },
            new DietaryRequirement
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                Name = "Glutenvrij"
            },
            new DietaryRequirement
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                Name = "Notenvrij"
            },
            new DietaryRequirement
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                Name = "Lactosevrij"
            }
        };
    }
}
