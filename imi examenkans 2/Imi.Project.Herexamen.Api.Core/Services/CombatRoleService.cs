using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Imi.Project.Herexamen.Api.Core.DTO_S.CombatRole;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Services
{
    public class CombatRoleService : ICombatRoleService
    {
        private readonly ICombatRoleRepository _combatRoleRepository;
        private readonly Mapper _mapper;

        public CombatRoleService(ICombatRoleRepository combatRoleRepository, Mapper mapper)
        {
            _combatRoleRepository = combatRoleRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<CombatRoleResponseDTO>>> GetAllCombatRoles()
        {
            ServiceResponse<IEnumerable<CombatRoleResponseDTO>> response =
                new ServiceResponse<IEnumerable<CombatRoleResponseDTO>>();
            var combatRoles = await _combatRoleRepository.ListAllAsync();
            response.Data = _mapper.Map<IEnumerable<CombatRoleResponseDTO>>(combatRoles);

            return response;
        }

        public async Task<ServiceResponse<CombatRoleResponseDTO>> GetCombatRoleById(Guid combatRoleId)
        {
            ServiceResponse<CombatRoleResponseDTO> response = new ServiceResponse<CombatRoleResponseDTO>();
            var combatRole = await _combatRoleRepository.GetByIdAsync(combatRoleId);
            response.Data = _mapper.Map<CombatRoleResponseDTO>(combatRole);

            return response;
        }

        public async Task<ServiceResponse<CombatRoleResponseDTO>> CreateCombatRole(CombatRoleRequestDTO request)
        {
            ServiceResponse<CombatRoleResponseDTO> response = new ServiceResponse<CombatRoleResponseDTO>();
            var combatRole = _mapper.Map<CombatRole>(request);
            var newCombatRole = await _combatRoleRepository.CreateAsync(combatRole);
            response.Data = _mapper.Map<CombatRoleResponseDTO>(newCombatRole);

            return response;
        }
    }
}