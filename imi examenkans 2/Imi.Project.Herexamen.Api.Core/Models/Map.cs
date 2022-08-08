using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    [Table("Map")]
    public class Map: Base
    {
        public string Name { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}