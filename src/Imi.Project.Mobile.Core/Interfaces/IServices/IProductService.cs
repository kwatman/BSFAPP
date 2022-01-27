using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces.IServices
{
    public interface IProductService: IBaseService<Product>
    {
        Task<IList<Product>> GetByCategoryId(Guid categoryId);
        Task<IList<Product>> GetByDietaryRequirementId(Guid dietaryRequirementId);
    }
}
