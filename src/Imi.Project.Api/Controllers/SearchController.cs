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

        public SearchController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IDietaryRequirementRepository dietaryRequirementRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _dietaryRequirementRepository = dietaryRequirementRepository;
        }
    }
}
