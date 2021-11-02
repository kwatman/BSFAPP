using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models
{
    public class Category : Base
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
