using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.ListAllAsync();
            var usersDTO = users.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            });

            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                return NotFound($"Geen gebruiker met id {id} gevonden");
            }
            else
            {
                var userDTO = new UserResponseDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };

                return Ok(userDTO);
            }
        }
    }
}
