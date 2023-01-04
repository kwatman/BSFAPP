using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BSFAPP.Api.Core.DTO_S.Operation;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Interfaces.Services;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Services
{
    public class OperationService: IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public OperationService(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> GetAllOperations()
        {
            ServiceResponse<IEnumerable<OperationResponseDTO>>
                response = new ServiceResponse<IEnumerable<OperationResponseDTO>>();
            var operations = await _operationRepository.ListAllAsync();
            response.Data = _mapper.Map<IEnumerable<OperationResponseDTO>>(operations);

            return response;
        }

        public async Task<ServiceResponse<OperationResponseDTO>> GetOperationById(Guid operationId)
        {
            ServiceResponse<OperationResponseDTO> response = new ServiceResponse<OperationResponseDTO>();
            var operation = await _operationRepository.GetByIdAsync(operationId);
            response.Data = _mapper.Map<OperationResponseDTO>(operation);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> GetOperationByMapId(Guid mapId)
        {
            ServiceResponse<IEnumerable<OperationResponseDTO>>
                response = new ServiceResponse<IEnumerable<OperationResponseDTO>>();
            var operations = await _operationRepository.GetByMapIdAsync(mapId);
            response.Data = _mapper.Map<IEnumerable<OperationResponseDTO>>(operations);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> SearchOperation(string searchString)
        {
            ServiceResponse<IEnumerable<OperationResponseDTO>>
                response = new ServiceResponse<IEnumerable<OperationResponseDTO>>();
            var operations = await _operationRepository.SearchAsync(searchString);
            response.Data = _mapper.Map<IEnumerable<OperationResponseDTO>>(operations);

            return response;
        }

        public async Task<ServiceResponse<OperationResponseDTO>> CreateOperation(OperationRequestDTO request)
        {
            ServiceResponse<OperationResponseDTO> response = new ServiceResponse<OperationResponseDTO>();
            var operation = _mapper.Map<Operation>(request);
            var newOperation = await _operationRepository.CreateAsync(operation);
            response.Data = _mapper.Map<OperationResponseDTO>(newOperation);

            return response;
        }

        public async Task<ServiceResponse<OperationResponseDTO>> UpdateOperation(OperationRequestDTO request)
        {
            ServiceResponse<OperationResponseDTO> response = new ServiceResponse<OperationResponseDTO>();

            try
            {
                var operation = await _operationRepository.GetByIdAsync(request.Id);
                operation.CodeName = request.CodeName;
                operation.Sitrep = request.Sitrep;
                operation.ZeroHour = request.ZeroHour;
                operation.MapId = request.MapId;
                // TODO: participations

                var updatedOperation = await _operationRepository.UpdateAsync(operation);
                response.Data = _mapper.Map<OperationResponseDTO>(updatedOperation);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<OperationResponseDTO>> DeleteOperation(Guid operationId)
        {
            ServiceResponse<OperationResponseDTO> response = new ServiceResponse<OperationResponseDTO>();

            try
            {
                var operation = await _operationRepository.GetByIdAsync(operationId);
                var deletedOperation = await _operationRepository.DeleteAsync(operation);
                response.Data = _mapper.Map<OperationResponseDTO>(deletedOperation);
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