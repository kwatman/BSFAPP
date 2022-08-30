using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.Participation;
using Imi.Project.Herexamen.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Herexamen.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipationsController : ControllerBase
    {
        private readonly IParticipationService _participationService;

        public ParticipationsController(IParticipationService participationService)
        {
            _participationService = participationService;
        }

        [Authorize(Policy = "CanCreate")]
        [HttpPost]
        public async Task<IActionResult> AddParticipation(ParticipationRequestDTO request)
        {
            var response = await _participationService.AddParticipation(request);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}