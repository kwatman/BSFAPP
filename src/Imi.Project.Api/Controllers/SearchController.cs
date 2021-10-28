﻿using Imi.Project.Api.Core.DTO_S.Categories;
using Imi.Project.Api.Core.DTO_S.Products;
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
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDietaryRequirementRepository _dietaryRequirementRepository;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IUserRepository _userRepository;

        public SearchController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IDietaryRequirementRepository dietaryRequirementRepository,
            IBlogPostRepository blogPostRepository,
            IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _dietaryRequirementRepository = dietaryRequirementRepository;
            _blogPostRepository = blogPostRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchString)
        {
            var results = await _productRepository.SearchAsync(searchString);

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
