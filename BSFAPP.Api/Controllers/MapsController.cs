using System;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.Map;
using BSFAPP.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSFAPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        protected readonly IMapService _mapService;

        public MapsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [Authorize(Policy = "CanRead")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mapService.GetAllMaps();

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanRead")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mapService.GetMapById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanCreate")]
        [HttpPost]
        public async Task<IActionResult> Create(MapRequestDTO request)
        {
            var response = await _mapService.CreateMap(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Update(MapRequestDTO request)
        {
            var response = await _mapService.UpdateMap(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanDelete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mapService.DeleteMap(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}