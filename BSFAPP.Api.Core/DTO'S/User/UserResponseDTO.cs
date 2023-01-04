using BSFAPP.Api.Core.DTO_S.Base;
using BSFAPP.Api.Core.DTO_S.CombatRole;

namespace BSFAPP.Api.Core.DTO_S.User
{
    public class UserResponseDTO : BaseDTO
    {
        public string UserName { get; set; }
        public bool SquadLeader { get; set; }
        public CombatRoleResponseDTO CombatRole { get; set; }
    }
}