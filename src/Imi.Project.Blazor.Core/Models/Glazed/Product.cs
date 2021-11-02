using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<DietaryRequirement> DietaryRequirements { get; set; }
    }
}
