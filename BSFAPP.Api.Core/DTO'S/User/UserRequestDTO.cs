using System;
using BSFAPP.Api.Core.DTO_S.Base;

namespace BSFAPP.Api.Core.DTO_S.User
{
    public class UserRequestDTO : BaseDTO
    {
        public string UserName { get; set; }
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        // Participants
    }
}