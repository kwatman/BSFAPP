using System;
using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.Auth;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSFAPP.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO request)
        {
            ServiceResponse<int> response =
                await _authRepository.Register(new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        HasAcceptedTermsAndConditions = request.HasAcceptedTermsAndConditions,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")

                    }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO request)
        {
            ServiceResponse<string> response = await _authRepository.Login(request.Username, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}