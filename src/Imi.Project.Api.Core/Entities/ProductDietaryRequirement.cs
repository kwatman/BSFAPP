using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class ProductDietaryRequirement
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DietaryRequirementId { get; set; }
        public DietaryRequirement DietaryRequirement { get; set; }
    }
}
