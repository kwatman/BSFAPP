using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public interface IProductService: IBaseService<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> GetByDietaryRequirementIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string searchString);
    }
}
