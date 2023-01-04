using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSFAPP.Api.Core.Models
{
    [Table("User")]
    public class User: Base
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }
        public bool HasAcceptedTermsAndConditions { get; set; }
        public bool SquadLeader { get; set; }

        [ForeignKey("CombatRole")]
        public Guid CombatRoleId { get; set; }
        public CombatRole CombatRole  { get; set; }
        public ICollection<Participation> Participations { get; set; } // Navigation Property Participations
    }
}