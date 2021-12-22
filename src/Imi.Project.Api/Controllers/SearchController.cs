using Imi.Project.Api.Core.DTO_S.Categories;
using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Interfaces.Services;
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
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IDietaryRequirementService _dietaryRequirementService;
        private readonly IBlogPostService _blogPostService;
        private readonly IUserService _userService;

        public SearchController(IProductService productService, 
            ICategoryService categoryService,
            IDietaryRequirementService dietaryRequirementService,
            IBlogPostService blogPostService,
            IUserService userService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _dietaryRequirementService = dietaryRequirementService;
            _blogPostService = blogPostService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchString)
        {
            var results = await _productService.SearchAsync(searchString);

            var searchResultsDTO = results.Select(s => new ProductResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Category = new CategoryResponseDTO
                {
                    Id = s.Category.Id,
                    Name = s.Category.Name
                }
            });

            return Ok(searchResultsDTO);
        }
    }
}
