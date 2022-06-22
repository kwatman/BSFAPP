using System;
using System.Collections.Generic;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class Operation: Base
    {
        public string CodeName { get; set; }
        public string Sitrep { get; set; }
        public DateTime ZeroHour { get; set; }
        public Guid MapId { get; set; }
        public Map Map { get; set; }
        public ICollection<Participation> Participations { get; set; }
    }
}