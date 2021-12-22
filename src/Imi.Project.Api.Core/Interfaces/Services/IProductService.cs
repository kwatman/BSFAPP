using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();

        Task<IEnumerable<Product>> ListAllAsync();

        Task<Product> GetByIdAsync(Guid id);

        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);

        Task<IEnumerable<Product>> GetByDietaryRequirementIdAsync(Guid id);

        Task<Product> UpdateAsync(Product product);

        Task<Product> AddAsync(Product product);

        Task<Product> DeleteAsync(Product product);
    }
}
