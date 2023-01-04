using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.User;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserResponseDTO>>> GetAllUsers();
        Task<ServiceResponse<UserResponseDTO>> GetUserById(Guid userId);
        Task<ServiceResponse<IEnumerable<UserResponseDTO>>> GetUserByCombatRole(Guid combatRoleId);
        Task<ServiceResponse<IEnumerable<UserResponseDTO>>> SearchUser(string searchString);
        Task<ServiceResponse<UserResponseDTO>> CreateUser(UserRequestDTO request);
        Task<ServiceResponse<UserResponseDTO>> UpdateUser(UserRequestDTO request);
        Task<ServiceResponse<UserResponseDTO>> DeleteUser(Guid userId);
    }
}