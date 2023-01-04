using System;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.CombatRole;
using BSFAPP.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSFAPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombatRolesController : ControllerBase
    {
        protected readonly ICombatRoleService _combatRoleService;

        public CombatRolesController(ICombatRoleService combatRoleService)
        {
            _combatRoleService = combatRoleService;
        }

        [Authorize(Policy = "CanRead")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _combatRoleService.GetAllCombatRoles();

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
            var response = await _combatRoleService.GetCombatRoleById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanCreate")]
        [HttpPost]
        public async Task<IActionResult> Create(CombatRoleRequestDTO request)
        {
            var response = await _combatRoleService.CreateCombatRole(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Policy = "CanEdit")]
        [HttpPut]
        public async Task<IActionResult> Update(CombatRoleRequestDTO request)
        {
            var response = await _combatRoleService.UpdateCombatRole(request);

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
            var response = await _combatRoleService.DeleteCombatRole(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}