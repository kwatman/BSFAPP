using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.CombatRole;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Services
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