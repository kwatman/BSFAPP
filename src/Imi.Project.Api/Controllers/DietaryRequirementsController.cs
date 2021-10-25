using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
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
    public class DietaryRequirementsController : ControllerBase
    {
        protected readonly IDietaryRequirementRepository _dietaryRequirementRepository;

        public DietaryRequirementsController(IDietaryRequirementRepository dietaryRequirementRepository)
        {
            _dietaryRequirementRepository = dietaryRequirementRepository;
        }

        public async Task<IActionResult> Get()
        {
            var dietaryRequirements = await _dietaryRequirementRepository.ListAllAsync();
            var dietaryRequirementsDTO = dietaryRequirements.Select(dr => new DietaryRequirementResponseDTO
            {
                Id = dr.Id,
                Name = dr.Name
            });

            return Ok(dietaryRequirementsDTO);
        }
    }
}
