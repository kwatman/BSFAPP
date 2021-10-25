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
                }
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
                    Category = new CategoryResponseDTO
                    {
                        Id = product.Category.Id,
                        Name = product.Category.Name
                    }
                };

                return Ok(productDTO);
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
                Category = new CategoryResponseDTO
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            });

            return Ok(productsDTO);
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
                    CategoryId = productDTO.CategoryId,
                    Name = productDTO.Name
                };

                await _productRepository.AddAsync(newProduct);

                return Ok();
            }
        }
    }
}
