using System;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.CombatRole;
using Imi.Project.Herexamen.Api.Core.DTO_S.Map;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CombatRoleController : ControllerBase
    {
        protected readonly ICombatRoleService _combatRoleService;

        public CombatRoleController(ICombatRoleService combatRoleService)
        {
            _combatRoleService = combatRoleService;
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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