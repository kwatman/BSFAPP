using Imi.Project.Api.Core.DTO_S.Categories;
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

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
    }
}
