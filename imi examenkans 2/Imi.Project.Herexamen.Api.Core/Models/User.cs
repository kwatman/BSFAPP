using System;
using System.Collections.Generic;
using System.Linq;
using Imi.Project.Herexamen.Api.Core.Enums;

namespace Imi.Project.Herexamen.Api.Core.Models
{
    public class User: Base
    {
        public string Username { get; set; }
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        public CombatRole CombatRole  { get; set; }
        public ICollection<Participation> Participations { get; set; }
        public int NumberOfParticipations { get; private set; }
        public ParticipationRank ParticipationRank { get; private set; }
    }
}