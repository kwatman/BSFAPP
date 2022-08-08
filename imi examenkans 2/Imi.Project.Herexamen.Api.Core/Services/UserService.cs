using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Imi.Project.Herexamen.Api.Core.DTO_S.User;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<UserResponseDTO>>> GetAllUsers()
        {
            ServiceResponse<IEnumerable<UserResponseDTO>>
                response = new ServiceResponse<IEnumerable<UserResponseDTO>>();
            var users = await _userRepository.ListAllAsync();
            response.Data = _mapper.Map<IEnumerable<UserResponseDTO>>(users);

            return response;
        }

        public async Task<ServiceResponse<UserResponseDTO>> GetUserById(Guid userId)
        {
            ServiceResponse<UserResponseDTO> response = new ServiceResponse<UserResponseDTO>();
            var user = await _userRepository.GetByIdAsync(userId);
            response.Data = _mapper.Map<UserResponseDTO>(user);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<UserResponseDTO>>> GetUserByCombatRole(Guid combatRoleId)
        {
            ServiceResponse<IEnumerable<UserResponseDTO>>
                response = new ServiceResponse<IEnumerable<UserResponseDTO>>();
            var users = await _userRepository.GetByCombatRoleIdAsync(combatRoleId);
            response.Data = _mapper.Map<IEnumerable<UserResponseDTO>>(users);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<UserResponseDTO>>> SearchUser(string searchString)
        {
            ServiceResponse<IEnumerable<UserResponseDTO>>
                response = new ServiceResponse<IEnumerable<UserResponseDTO>>();
            var users = await _userRepository.SearchAsync(searchString);
            response.Data = _mapper.Map<IEnumerable<UserResponseDTO>>(users);

            return response;
        }

        public async Task<ServiceResponse<UserResponseDTO>> CreateUser(UserRequestDTO request)
        {
            ServiceResponse<UserResponseDTO> response = new ServiceResponse<UserResponseDTO>();
            var user = _mapper.Map<User>(request);
            var newUser = await _userRepository.CreateAsync(user);
            response.Data = _mapper.Map<UserResponseDTO>(newUser);

            return response;
        }

        public async Task<ServiceResponse<UserResponseDTO>> UpdateUser(UserRequestDTO request)
        {
            ServiceResponse<UserResponseDTO> response = new ServiceResponse<UserResponseDTO>();

            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);
                user.Username = request.UserName;
                user.SquadLeader = request.SquadLeader;
                user.CombatRoleId = request.CombatRoleId;
                var updatedUser = await _userRepository.UpdateAsync(user);
                response.Data = _mapper.Map<UserResponseDTO>(updatedUser);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<UserResponseDTO>> DeleteUser(Guid userId)
        {
            ServiceResponse<UserResponseDTO> response = new ServiceResponse<UserResponseDTO>();

            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                var deletedUser = await _userRepository.DeleteAsync(user);
                response.Data = _mapper.Map<UserResponseDTO>(deletedUser);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}