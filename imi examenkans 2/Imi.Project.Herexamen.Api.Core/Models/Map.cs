using System.Collections.Generic;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class Map: Base
    {
        public string Name { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}