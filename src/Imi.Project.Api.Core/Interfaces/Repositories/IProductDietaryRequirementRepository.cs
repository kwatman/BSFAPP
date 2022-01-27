using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repositories
{
    public interface IProductDietaryRequirementRepository
    {
        IQueryable<ProductDietaryRequirement> GetAll();

        Task<IEnumerable<ProductDietaryRequirement>> ListAllAsync();

        Task<ProductDietaryRequirement> UpdateAsync(ProductDietaryRequirement pdr);

        Task<ProductDietaryRequirement> AddAsync(ProductDietaryRequirement pdr);

        Task<ProductDietaryRequirement> DeleteAsync(ProductDietaryRequirement pdr);
    }
}
