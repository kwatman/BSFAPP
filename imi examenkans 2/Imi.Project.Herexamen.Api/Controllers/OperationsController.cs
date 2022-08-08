using System;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.Operation;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        protected readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _operationService.GetAllOperations();

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _operationService.GetOperationById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperationRequestDTO request)
        {
            var response = await _operationService.CreateOperation(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperationRequestDTO request)
        {
            var response = await _operationService.UpdateOperation(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _operationService.DeleteOperation(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}