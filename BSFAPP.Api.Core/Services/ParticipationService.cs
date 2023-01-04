using System;
using System.Threading.Tasks;
using AutoMapper;
using BSFAPP.Api.Core.DTO_S.Participation;
using BSFAPP.Api.Core.DTO_S.User;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Interfaces.Services;
using BSFAPP.Api.Core.Models;
using Microsoft.AspNetCore.Http;

namespace BSFAPP.Api.Core.Services
{
    public class ParticipationService : IParticipationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationRepository _operationRepository;
        private readonly IParticipationRepository _participationRepository;
        private readonly IHttpContextAccessor _httpCtx;
        private readonly IMapper _mapper;

        public ParticipationService(IUserRepository userRepository, IOperationRepository operationRepository,
            IParticipationRepository participationRepository, IHttpContextAccessor httpCtx, IMapper mapper)
        {
            _userRepository = userRepository;
            _operationRepository = operationRepository;
            _participationRepository = participationRepository;
            _httpCtx = httpCtx;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserResponseDTO>> AddParticipation(ParticipationRequestDTO request)
        {
            ServiceResponse<UserResponseDTO> response = new ServiceResponse<UserResponseDTO>();

            try
            {
                User user = await _userRepository.GetByIdAsync(request.UserId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }

                Operation operation = await _operationRepository.GetByIdAsync(request.OperationId);

                if (operation == null)
                {
                    response.Success = false;
                    response.Message = "Operation not found";
                    return response;
                }

                Participation participation = new Participation
                {
                    User = user,
                    Operation = operation
                };

                await _participationRepository.CreateAsync(participation);

                response.Data = _mapper.Map<UserResponseDTO>(user);
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