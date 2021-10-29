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
    public class ProductsController : ControllerBase
    {
        protected readonly IProductRepository _productRepository;
        protected readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.ListAllAsync();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Geen product met id {id} gevonden");
            }
            else
            {
                var productDTO = new ProductResponseDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = new CategoryResponseDTO
                    {
                        Id = product.Category.Id,
                        Name = product.Category.Name
                    },
                    DietaryRequirements = product.ProductDietaryRequirements.Select(pdr => new DietaryRequirementResponseDTO
                    {
                        Id = pdr.DietaryRequirementId,
                        Name = pdr.DietaryRequirement.Name
                    }).ToList()
                };

                return Ok(productDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var category = await _categoryRepository.GetByIdAsync(productDTO.CategoryId);

            if(category == null)
            {
                return BadRequest($"Categorie met id {productDTO.CategoryId} bestaat niet");
            }
            else
            {
                var newProduct = new Product
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    CategoryId = productDTO.CategoryId
                };

                await _productRepository.AddAsync(newProduct);

                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            var category = await _categoryRepository.GetByIdAsync(productDTO.CategoryId);

            if (category == null)
            {
                return BadRequest($"Aanpassen niet mogelijk omdat categorie met id {productDTO.CategoryId} niet bestaat");
            }
            else
            {
                var newProduct = await _productRepository.GetByIdAsync(productDTO.Id);

                if(newProduct == null)
                {
                    return NotFound($"Geen product met Id {productDTO.Id} gevonden");
                }
                else
                {
                    newProduct.Name = productDTO.Name;
                    newProduct.Description = productDTO.Description;
                    newProduct.Price = productDTO.Price;
                    newProduct.CategoryId = productDTO.CategoryId;

                    await _productRepository.UpdateAsync(newProduct);

                    return Ok();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productToDelete = await _productRepository.GetByIdAsync(id);

            if (productToDelete == null)
            {
                return NotFound($"Geen product met Id {id} gevonden");
            }
            else
            {
                await _productRepository.DeleteAsync(productToDelete);

                return Ok();
            }
        }
    }
}
