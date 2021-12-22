using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ProductService: IProductService
    {
        protected readonly IBaseRepository<Product> _productRepository;

        public ProductService(IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll().Include(p => p.Category)
                                              .Include(p => p.ProductDietaryRequirements).ThenInclude(p => p.DietaryRequirement);
        }

        public async Task<IEnumerable<Product>> ListAllAsync()
        {
            return await _productRepository.GetAll().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id)
        {
            return await GetAll().Where(p => p.CategoryId.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByDietaryRequirementIdAsync(Guid id)
        {
            return await GetAll().Where(p => p.ProductDietaryRequirements.Any(dr => dr.DietaryRequirementId == id)).ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<Product> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            return await _productRepository.DeleteAsync(product);
        }
    }
}
