using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ProductService: IProductService
    {
        protected readonly IBaseRepository<Product> _baseRepository;

        public ProductService(IBaseRepository<Product> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<Product> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public virtual async Task<IEnumerable<Product>> ListAllAsync()
        {
            return await _baseRepository.ListAllAsync();
        }

        public virtual async Task<Product> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _baseRepository.UpdateAsync(product);
        }

        public async Task<Product> AddAsync(Product product)
        {
            return await _baseRepository.AddAsync(product);
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            return await _baseRepository.DeleteAsync(product);
        }
    }
}
