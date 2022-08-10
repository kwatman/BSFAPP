using System;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.User;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Imi.Project.Herexamen.Api.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllUsers();

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
            var response = await _userService.GetUserById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestDTO request)
        {
            var response = await _userService.CreateUser(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserRequestDTO request)
        {
            var response = await _userService.UpdateUser(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _userService.DeleteUser(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}