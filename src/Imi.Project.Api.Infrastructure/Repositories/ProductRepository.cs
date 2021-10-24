using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public override IQueryable<Product> GetAll()
        {
            return _appDbContext.Products.Include(p => p.Category).Include(p => p.ProductDietaryRequirements).ThenInclude(pdr => pdr.DietaryRequirement);
        }

        public async override Task<IEnumerable<Product>> ListAllAsync()
        {
            var products = await GetAll().ToListAsync();
            return products;
        }

        public async override Task<Product> GetByIdAsync(Guid id)
        {
            var product = await GetAll().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return product;
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.CategoryId.Equals(id)).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetByDietaryRequirementIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.ProductDietaryRequirements.Any(dr => dr.DietaryRequirementId == id)).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string searchString)
        {
            var products = await GetAll().Where(p => p.Name.Contains(searchString.Trim().ToUpper())
            || p.Name.Contains(searchString.Trim().ToUpper())
            || p.ProductDietaryRequirements.Any(dr => dr.DietaryRequirement.Name.Contains(searchString.Trim().ToUpper())))
                .ToListAsync();

            return products;
        }
    }
}
