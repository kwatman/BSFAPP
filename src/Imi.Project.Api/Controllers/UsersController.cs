using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Entities;
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

        [HttpPost]
        public async Task<IActionResult> Add(UserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            else
            {
                var userToAdd = new User
                {
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Email = userDTO.Email,
                    PhoneNumber = userDTO.PhoneNumber,
                    Password = userDTO.Password
                };

                await _userRepository.AddAsync(userToAdd);

                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserRequestDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            else
            {
                var userToUpdate = await _userRepository.GetByIdAsync(userDTO.Id);

                if (userToUpdate == null)
                {
                    return NotFound($"Geen gebruiker met id {userDTO.Id} gevonden");
                }
                else
                {
                    userToUpdate.Name = userDTO.Name;
                    userToUpdate.Surname = userDTO.Surname;
                    userToUpdate.Email = userDTO.Email;
                    userToUpdate.PhoneNumber = userDTO.PhoneNumber;
                    userToUpdate.Password = userDTO.Password;

                    await _userRepository.UpdateAsync(userToUpdate);

                    return Ok();
                }
            }
        }
    }
}
