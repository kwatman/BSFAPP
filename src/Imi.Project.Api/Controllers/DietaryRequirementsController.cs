using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
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
    public class DietaryRequirementsController : ControllerBase
    {
        protected readonly IDietaryRequirementRepository _dietaryRequirementRepository;

        public DietaryRequirementsController(IDietaryRequirementRepository dietaryRequirementRepository)
        {
            _dietaryRequirementRepository = dietaryRequirementRepository;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dietaryRequirement = await _dietaryRequirementRepository.GetByIdAsync(id);
            if (dietaryRequirement == null)
            {
                return NotFound($"Geen Dieetvereiste met id {id} gevonden");
            }
            else
            {
                var dietaryRequirementDTO = new DietaryRequirementResponseDTO
                {
                    Id = dietaryRequirement.Id,
                    Name = dietaryRequirement.Name
                };

                return Ok(dietaryRequirementDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(DietaryRequirementRequestDTO dietaryRequirementDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var newDietaryRequirement = new DietaryRequirement
            {
                Name = dietaryRequirementDTO.Name
            };

            await _dietaryRequirementRepository.AddAsync(newDietaryRequirement);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(DietaryRequirementRequestDTO dietaryRequirementDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var newDietaryRequirement = await _dietaryRequirementRepository.GetByIdAsync(dietaryRequirementDTO.Id);

            if (newDietaryRequirement == null)
            {
                return NotFound($"Geen dieetvereiste met Id {dietaryRequirementDTO.Id} gevonden");
            }
            else
            {
                newDietaryRequirement.Name = dietaryRequirementDTO.Name;

                await _dietaryRequirementRepository.UpdateAsync(newDietaryRequirement);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dietaryRequirementToDelete = await _dietaryRequirementRepository.GetByIdAsync(id);

            if(dietaryRequirementToDelete == null)
            {
                return NotFound($"Geen dieetvereiste met Id {id} gevonden");
            }
            else
            {
                await _dietaryRequirementRepository.DeleteAsync(dietaryRequirementToDelete);

                return Ok();
            }
        }
    }
}
