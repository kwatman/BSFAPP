using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Imi.Project.Herexamen.Api.Core.Enums;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class User: Base
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        public CombatRole CombatRole  { get; set; }
        public ICollection<Participation> Participations { get; set; } // Navigation Property Participations
    }
}