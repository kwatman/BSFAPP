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
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IProductRepository _productRepository;

        public CategoriesController(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.ListAllAsync();
            var categoriesDTO = categories.Select(c => new CategoryResponseDTO
            {
                Id = c.Id,
                Name = c.Name
            });
            return Ok(categoriesDTO);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Geen categorie met id {id} gevonden");
            }
            else
            {
                var categoryDTO = new CategoryResponseDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return Ok(categoryDTO);
            }
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByCategory(Guid id)
        {
            var products = await _productRepository.GetByCategoryIdAsync(id);

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
        public async Task<IActionResult> Add(CategoryRequestDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var newCategory = new Category
            {
                Name = categoryDTO.Name
            };

            await _categoryRepository.AddAsync(newCategory);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryRequestDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var newCategory = await _categoryRepository.GetByIdAsync(categoryDTO.Id);

            if(newCategory == null)
            {
                return NotFound($"Geen categorie met Id {categoryDTO.Id} gevonden");
            }
            else
            {
                newCategory.Name = categoryDTO.Name;

                await _categoryRepository.UpdateAsync(newCategory);

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(id);

            if(categoryToDelete == null)
            {
                return NotFound($"Geen categorie met Id {id} gevonden");
            }
            else
            {
                await _categoryRepository.DeleteAsync(categoryToDelete);

                return Ok();
            }
        }
    }
}
