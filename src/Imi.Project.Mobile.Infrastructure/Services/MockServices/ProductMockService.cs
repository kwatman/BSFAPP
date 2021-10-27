
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Mocking
{
    public class ProductMockService: BaseMockService<Product>, IProductService
    {
        public async Task<IQueryable<Product>> GetByCategoryId(Guid id)
        {
            var products = ProductMockData.productData.Where(p => p.CategoryId.Equals(id)).AsQueryable();
            return await Task.FromResult(products);
        }

        public async Task<IQueryable<Product>> GetByDietaryRequirementId(Guid id)
        {
            var products = ProductMockData.productData.Where(p => p.DietaryRequirements.Any(dr => dr.Id == id)).AsQueryable();
            return await Task.FromResult(products);
        }
    }
}
