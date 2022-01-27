using Imi.Project.Api.Core.DTO_S.Categories;
using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
using Imi.Project.Api.Core.DTO_S.ProductDietaryRequirements;
using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
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
        protected readonly IProductService _productService;
        protected readonly ICategoryService _categoryService;
        protected readonly IDietaryRequirementService _dietaryRequirementService;
        protected readonly IProductDietaryRequirementService _productDietaryRequirementService;
        public ProductsController(IProductService productService,
                                  ICategoryService categoryService,
                                  IDietaryRequirementService dietaryRequirementService
,                                 IProductDietaryRequirementService productDietaryRequirementService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _dietaryRequirementService = dietaryRequirementService;
            _productDietaryRequirementService = productDietaryRequirementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.ListAllAsync();
            var productsDTO = products.Select(p => new ProductResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                ShortDescription = p.ShortDescription,
                LongDescription = p.LongDescription,
                Price = p.Price,
                ImageURI = p.ImageURI,
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
            var product = await _productService.GetByIdAsync(id);
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
                    ShortDescription = product.ShortDescription,
                    LongDescription = product.LongDescription,
                    Price = product.Price,
                    ImageURI= product.ImageURI,
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

            var category = await _categoryService.GetByIdAsync(productDTO.CategoryId);

            if(category == null)
            {
                return BadRequest($"Categorie met id {productDTO.CategoryId} bestaat niet");
            }

            else
            {
                var newProduct = new Product
                {
                    Name = productDTO.Name,
                    ShortDescription = productDTO.ShortDescription,
                    LongDescription = productDTO.LongDescription,
                    Price = productDTO.Price,
                    CategoryId = productDTO.CategoryId,
                    ImageURI = "product_placeholder.jpg"
                };

                await _productService.AddAsync(newProduct);

                List<ProductDietaryRequirement> productDietaryRequirements = new List<ProductDietaryRequirement>();

                foreach(Guid dietaryRequirementId in productDTO.DietaryRequirementIds)
                {
                    productDietaryRequirements.Add(await _productDietaryRequirementService.AddProductDietaryRequirement(new ProductDietaryRequirement
                    {
                        ProductId = newProduct.Id,
                        DietaryRequirementId = dietaryRequirementId
                    }));
                }

                newProduct.ProductDietaryRequirements = productDietaryRequirements;

                await _productService.UpdateAsync(newProduct);

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

            var category = await _categoryService.GetByIdAsync(productDTO.CategoryId);

            if (category == null)
            {
                return BadRequest($"Aanpassen niet mogelijk omdat categorie met id {productDTO.CategoryId} niet bestaat");
            }
            else
            {
                var newProduct = await _productService.GetByIdAsync(productDTO.Id);

                if(newProduct == null)
                {
                    return NotFound($"Geen product met Id {productDTO.Id} gevonden");
                }
                else
                {
                    newProduct.Name = productDTO.Name;
                    newProduct.ShortDescription = productDTO.ShortDescription;
                    newProduct.LongDescription = productDTO.LongDescription;
                    newProduct.Price = productDTO.Price;
                    newProduct.ImageURI = "product_placeholder.jpg";
                    newProduct.CategoryId = productDTO.CategoryId;

                    await _productService.UpdateAsync(newProduct);

                    return Ok();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productToDelete = await _productService.GetByIdAsync(id);

            if (productToDelete == null)
            {
                return NotFound($"Geen product met Id {id} gevonden");
            }
            else
            {
                await _productService.DeleteAsync(productToDelete);

                return Ok();
            }
        }
    }
}
