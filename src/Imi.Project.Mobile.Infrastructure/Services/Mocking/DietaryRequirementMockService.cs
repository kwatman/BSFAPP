using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;

namespace Imi.Project.Mobile.Infrastructure.Services.Mocking
{
    public class DietaryRequirementMockService : BaseMockService<DietaryRequirement>, IDietaryRequirementService
    {
        private static List<DietaryRequirement> dietaryRequirements = new List<DietaryRequirement>
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
