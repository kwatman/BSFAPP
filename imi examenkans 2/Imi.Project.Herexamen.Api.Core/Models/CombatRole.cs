using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    [Table("CombatRole")]
    public class CombatRole: Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}