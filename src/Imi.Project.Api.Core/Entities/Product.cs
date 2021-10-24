using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductDietaryRequirement> ProductDietaryRequirements { get; set; }
    }
}
