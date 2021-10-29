using Imi.Project.Api.Core.DTO_S.Categories;
using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
using Imi.Project.Api.Core.DTO_S.Products;
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
        protected readonly IProductRepository _productRepository;

        public DietaryRequirementsController(IDietaryRequirementRepository dietaryRequirementRepository,
            IProductRepository productRepository)
        {
            _dietaryRequirementRepository = dietaryRequirementRepository;
            _productRepository = productRepository;
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

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByDietaryRequirement(Guid id)
        {
            var products = await _productRepository.GetByDietaryRequirementIdAsync(id);

            var productsDTO = products.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = new CategoryResponseDTO
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                },
                DietaryRequirements = p.ProductDietaryRequirements.Select(pdr => new DietaryRequirementResponseDTO
                {
                    Id = pdr.DietaryRequirementId,
                    Name = pdr.DietaryRequirement.Name
                }).ToList()
            });

            return Ok(productsDTO);
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
