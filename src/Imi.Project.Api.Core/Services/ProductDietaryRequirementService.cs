using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ProductDietaryRequirementService: IProductDietaryRequirementService
    {
        protected readonly IBaseRepository<ProductDietaryRequirement> _productDietaryRequirementRepository;

        public ProductDietaryRequirementService(IBaseRepository<ProductDietaryRequirement> productDietaryRequirementRepository)
        {
            _productDietaryRequirementRepository = productDietaryRequirementRepository;
        }
        public async Task<ProductDietaryRequirement> AddProductDietaryRequirement(ProductDietaryRequirement productDietaryRequirement)
        {
            return await _productDietaryRequirementRepository.AddAsync(productDietaryRequirement);
        }
    }
}
