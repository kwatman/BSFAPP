using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IProductDietaryRequirementService
    {
        Task<ProductDietaryRequirement> AddProductDietaryRequirement(ProductDietaryRequirement productDietaryRequirement);
    }
}
