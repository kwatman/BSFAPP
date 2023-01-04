using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.Map;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Services
{
    public interface IMapService
    {
        Task<ServiceResponse<IEnumerable<MapResponseDTO>>> GetAllMaps();
        Task<ServiceResponse<MapResponseDTO>> GetMapById(Guid mapId);
        Task<ServiceResponse<MapResponseDTO>> CreateMap(MapRequestDTO request);
        Task<ServiceResponse<MapResponseDTO>> UpdateMap(MapRequestDTO mapRequestDto);
        Task<ServiceResponse<MapResponseDTO>> DeleteMap(Guid id);
    }
}