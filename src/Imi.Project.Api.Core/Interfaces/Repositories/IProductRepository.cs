using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> GetByDietaryRequirementIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string searchString);
    }
}
