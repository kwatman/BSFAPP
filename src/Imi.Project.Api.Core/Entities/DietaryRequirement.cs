using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class DietaryRequirement: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductDietaryRequirement> ProductDietaryRequirements { get; set; }
    }
}
