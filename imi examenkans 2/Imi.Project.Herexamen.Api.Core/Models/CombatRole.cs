using System.Collections.Generic;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class CombatRole: Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}