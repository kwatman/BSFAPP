using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
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
        protected readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.ListAllAsync();
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
            var user = await _userService.GetByIdAsync(id);

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

                await _userService.AddAsync(userToAdd);

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
                var userToUpdate = await _userService.GetByIdAsync(userDTO.Id);

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

                    await _userService.UpdateAsync(userToUpdate);

                    return Ok();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userToDelete = await _userService.GetByIdAsync(id);

            if (userToDelete == null)
            {
                return NotFound($"Geen gebruiker met id {id} gevonden");
            }
            else
            {
                await _userService.DeleteAsync(userToDelete);

                return Ok();
            }
        }
    }
}
