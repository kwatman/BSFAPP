using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Imi.Project.Herexamen.Api.Core.DTO_S.Map;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IMapper _mapper;

        public MapService(IMapRepository mapRepository, IMapper mapper)
        {
            _mapRepository = mapRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<MapResponseDTO>>> GetAllMaps()
        {
            ServiceResponse<IEnumerable<MapResponseDTO>> response = new ServiceResponse<IEnumerable<MapResponseDTO>>();
            var maps = await _mapRepository.ListAllAsync();
            response.Data = _mapper.Map<IEnumerable<MapResponseDTO>>(maps);

            return response;
        }

        public async Task<ServiceResponse<MapResponseDTO>> GetMapById(Guid mapId)
        {
            ServiceResponse<MapResponseDTO> response = new ServiceResponse<MapResponseDTO>();
            var map = await _mapRepository.GetByIdAsync(mapId);
            response.Data = _mapper.Map<MapResponseDTO>(map);

            return response;
        }

        public async Task<ServiceResponse<MapResponseDTO>> CreateMap(MapRequestDTO request)
        {
            ServiceResponse<MapResponseDTO> response = new ServiceResponse<MapResponseDTO>();
            var map = _mapper.Map<Map>(request);
            var newMap = await _mapRepository.CreateAsync(map);
            response.Data = _mapper.Map<MapResponseDTO>(newMap);

            return response;
        }

        public async Task<ServiceResponse<MapResponseDTO>> UpdateMap(MapRequestDTO request)
        {
            ServiceResponse<MapResponseDTO> response = new ServiceResponse<MapResponseDTO>();

            try
            {
                var map = await _mapRepository.GetByIdAsync(request.Id);
                map.Name = request.Name;
                var updatedMap = await _mapRepository.UpdateAsync(map);
                response.Data = _mapper.Map<MapResponseDTO>(updatedMap);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<MapResponseDTO>> DeleteMap(Guid id)
        {
            ServiceResponse<MapResponseDTO> response = new ServiceResponse<MapResponseDTO>();

            try
            {
                var map = await _mapRepository.GetByIdAsync(id);
                var deletedMap = await _mapRepository.DeleteAsync(map);
                response.Data = _mapper.Map<MapResponseDTO>(deletedMap);
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