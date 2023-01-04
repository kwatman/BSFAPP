using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BSFAPP.Api.Core.DTO_S.CombatRole;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Interfaces.Services;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Services
{
    public class CombatRoleService : ICombatRoleService
    {
        private readonly ICombatRoleRepository _combatRoleRepository;
        private readonly IMapper _mapper;

        public CombatRoleService(ICombatRoleRepository combatRoleRepository, IMapper mapper)
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

        public async Task<ServiceResponse<CombatRoleResponseDTO>> UpdateCombatRole(CombatRoleRequestDTO request)
        {
            ServiceResponse<CombatRoleResponseDTO> response = new ServiceResponse<CombatRoleResponseDTO>();

            try
            {
                var combatRole = await _combatRoleRepository.GetByIdAsync(request.Id);
                combatRole.Name = request.Name;
                combatRole.Description = request.Description;
                var updatedCombatRole = await _combatRoleRepository.UpdateAsync(combatRole);
                response.Data = _mapper.Map<CombatRoleResponseDTO>(updatedCombatRole);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<CombatRoleResponseDTO>> DeleteCombatRole(Guid id)
        {
            ServiceResponse<CombatRoleResponseDTO> response = new ServiceResponse<CombatRoleResponseDTO>();

            try
            {
                var combatRole = await _combatRoleRepository.GetByIdAsync(id);
                var deletedCombatRole = await _combatRoleRepository.DeleteAsync(combatRole);
                response.Data = _mapper.Map<CombatRoleResponseDTO>(deletedCombatRole);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}