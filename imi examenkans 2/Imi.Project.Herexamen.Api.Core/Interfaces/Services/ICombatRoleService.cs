using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.CombatRole;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Interfaces.Services
{
    public interface ICombatRoleService
    {
        Task<ServiceResponse<IEnumerable<CombatRoleResponseDTO>>> GetAllCombatRoles();
        Task<ServiceResponse<CombatRoleResponseDTO>> GetCombatRoleById(Guid combatRoleId);
        Task<ServiceResponse<CombatRoleResponseDTO>> CreateCombatRole(CombatRoleRequestDTO request);
        Task<ServiceResponse<CombatRoleResponseDTO>> UpdateCombatRole(CombatRoleRequestDTO request);
        Task<ServiceResponse<CombatRoleResponseDTO>> DeleteCombatRole(Guid id);
    }
}