using System.Collections.Generic;
using Imi.Project.Herexamen.Api.Core.DTO_S.Base;
using Imi.Project.Herexamen.Api.Core.DTO_S.CombatRole;
using Imi.Project.Herexamen.Api.Core.DTO_S.Operation;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Imi.Project.Herexamen.Api.Core.DTO_S.User
{
    public class UserResponseDTO : BaseDTO
    {
        public string UserName { get; set; }
        public bool SquadLeader { get; set; }
        public CombatRoleResponseDTO CombatRole { get; set; }
        public List<OperationResponseDTO> Operation { get; set; }
    }
}