using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class DietaryRequirement
    {
        public Guid DietaryRequirementId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDietaryRequirement> ProductDietaryRequirements { get; set; }
    }
}
