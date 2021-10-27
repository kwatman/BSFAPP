using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public interface IProductService: IBaseService<Product>
    {
        Task<IQueryable<Product>> GetByCategoryId(Guid id);
        Task<IQueryable<Product>> GetByDietaryRequirementId(Guid id);
    }
}
