using System;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.Auth;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
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
            ServiceResponse<Guid> response =
                await _authRepository.Register(new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        HasAcceptedTermsAndConditions = request.HasAcceptedTermsAndConditions

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