using System;
using Imi.Project.Herexamen.Api.Core.DTO_S.Base;

namespace Imi.Project.Herexamen.Api.Core.DTO_S.User
{
    public class UserRequestDTO : BaseDTO
    {
        public string UserName { get; set; }
        public bool SquadLeader { get; set; }
        public Guid CombatRoleId { get; set; }
        // Participants
    }
}