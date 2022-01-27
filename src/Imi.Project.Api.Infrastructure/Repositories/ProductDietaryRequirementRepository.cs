using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class ProductDietaryRequirementRepository: IProductDietaryRequirementRepository
    {
        protected readonly AppDbContext _appDbContext;

        public ProductDietaryRequirementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<ProductDietaryRequirement> GetAll()
        {
            return _appDbContext.Set<ProductDietaryRequirement>().AsNoTracking();
        }

        public virtual async Task<IEnumerable<ProductDietaryRequirement>> ListAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<ProductDietaryRequirement> UpdateAsync(ProductDietaryRequirement pdr)
        {
            _appDbContext.Set<ProductDietaryRequirement>().Update(pdr);
            await _appDbContext.SaveChangesAsync();
            return pdr;
        }

        public async Task<ProductDietaryRequirement> AddAsync(ProductDietaryRequirement pdr)
        {
            await _appDbContext.Set<ProductDietaryRequirement>().AddAsync(pdr);
            await _appDbContext.SaveChangesAsync();
            return pdr;
        }

        public async Task<ProductDietaryRequirement> DeleteAsync(ProductDietaryRequirement pdr)
        {
            _appDbContext.Set<ProductDietaryRequirement>().Remove(pdr);
            await _appDbContext.SaveChangesAsync();
            return pdr;
        }
    }
}
