using Imi.Project.Api.Core.DTO_S.ProductDietaryRequirements;
using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces
{
    public interface IProductDietaryRequirementRepository
    {
        Task<ProductDietaryRequirement> AddProductDietaryRequirement(ProductDietaryRequirementRequestDTO newProductDietaryRequirment);
    }
}
