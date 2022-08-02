using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.Operation;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Interfaces.Services
{
    public interface IOperationService
    {
        Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> GetAllOperations();
        Task<ServiceResponse<OperationResponseDTO>> GetOperationById(Guid operationId);
        Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> GetOperationByMapId(Guid combatRoleId);
        Task<ServiceResponse<IEnumerable<OperationResponseDTO>>> SearchOperation(string searchString);
        Task<ServiceResponse<OperationResponseDTO>> CreateOperation(OperationRequestDTO request);
        Task<ServiceResponse<OperationResponseDTO>> UpdateOperation(OperationRequestDTO request);
        Task<ServiceResponse<OperationResponseDTO>> DeleteOperation(Guid operationId);
    }
}