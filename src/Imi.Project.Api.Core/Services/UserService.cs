using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService: IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<UserResponseDTO> RegisterAsync(UserRegisterRequestDTO request)
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

        public async Task<UserResponseDTO> LoginAsync(UserLoginRequestDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new UserResponseDTO
                {
                    Message = "Er bestaat geen gebruiker met dit Email-adress!",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (result == false)
            {
                return new UserResponseDTO
                {
                    Message = "Wachtwoord incorrect!",
                    IsSuccess = false,
                };
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Key"]));
            var expirationDays = _configuration.GetValue<double>("AuthConfig:TokenExpirationDays");

            var token = new JwtSecurityToken
                (
                issuer: _configuration["AuthConfig:Issuer"],
                audience: _configuration["AuthConfig:"],
                claims: claims,
                expires: DateTime.Now.AddDays(expirationDays),
                signingCredentials: new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256)
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserResponseDTO
            {
                Message = tokenString,
                IsSuccess = true,
                ExpirationDate = token.ValidTo
            };
        }
    }
}
