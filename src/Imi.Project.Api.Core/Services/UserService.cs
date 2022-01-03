using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService: IUserService
    {
        private UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserResponseDTO> RegisterAsync(UserRequestDTO request)
        {
            if (request == null)
            {
                throw new NullReferenceException("Register request bestaat niet");
            }
            else
            {
                if (request.Password != request.ConfirmPassword)
                {
                    return new UserResponseDTO
                    {
                        Message = "Wachtwoorden zijn niet gelijk!",
                        IsSuccess = false,
                    };
                }
                else
                {
                    var identityUser = new IdentityUser
                    {
                        UserName = request.Surname + request.Name,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                    };

                    var result = await _userManager.CreateAsync(identityUser, request.Password);

                    if (result.Succeeded)
                    {
                        return new UserResponseDTO
                        {
                            Message = "Gebruiker geregistreerd!",
                            IsSuccess = true,
                        };
                    }
                    else
                    {
                        return new UserResponseDTO
                        {
                            Message = "Registratie mislukt!",
                            IsSuccess = false,
                            Errors = result.Errors.Select(e => e.Description)
                        };
                    }
                }
            }
        }
    }
}
