using System;
using System.Collections.Generic;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class User: Base
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        public CombatRole CombatRole  { get; set; }
        public ICollection<Participation> Participations { get; set; }
        public int NumberOfParticipations { get; set; }
        public ParticipationRank ParticipationRank { get; set; }
    }
}