using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IProductRepository: IBaseRepository
    {
        Task<IQueryable<Product>> GetByCategoryId(string uri,);
        Task<IQueryable<Product>> GetByDietaryRequirementId(Guid id);
    }
}
