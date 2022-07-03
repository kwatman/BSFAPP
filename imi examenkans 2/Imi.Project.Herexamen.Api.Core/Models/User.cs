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
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        public CombatRole CombatRole  { get; set; }
        public ICollection<Participation> Participations { get; set; }
        private int numberOfParticipations;
        private ParticipationRank participationRank;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int NumberOfParticipations
        {
            get { return Participations.Count(); }
            private set { numberOfParticipations = value; }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public ParticipationRank ParticipationRank
        {
            get { return GetParticipationRank(); }
            set { participationRank = value; }
        }

        private ParticipationRank GetParticipationRank()
        {
            ParticipationRank value = ParticipationRank.Inactive;

            switch (NumberOfParticipations)
            {
                case int i when i == 0:
                    value = ParticipationRank.Inactive;
                    break;
                case int i when i >= 1 && i <= 5:
                    value = ParticipationRank.Recruit;
                    break;
                case int i when i >= 6 && i <= 20:
                    value = ParticipationRank.Private;
                    break;
                case int i when i >= 21 && i <= 30:
                    value = ParticipationRank.Corporal;
                    break;
                case int i when i >= 31 && i <= 40:
                    value = ParticipationRank.Sergeant;
                    break;
                case int i when i >= 41 && i <= 50:
                    value = ParticipationRank.Lieutenant;
                    break;
                case int i when i >= 51 && i <= 60:
                    value =  ParticipationRank.Captain;
                    break;
                case int i when i >= 61 && i <= 80:
                    value = ParticipationRank.Major;
                    break;
                case int i when i >= 81 && i <= 99:
                    value = ParticipationRank.Colonel;
                    break;
                case int i when i >= 100:
                    value = ParticipationRank.Elite;
                    break;
            }

            return value;
        }
    }
}