using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSFAPP.Api.Core.Models
{
    [Table("Operation")]
    public class Operation: Base
    {
        public string CodeName { get; set; }
        public string Sitrep { get; set; }
        public DateTime ZeroHour { get; set; }
        public Map? Map { get; set; }
        public ICollection<Participation> Participations { get; set; }
    }
}