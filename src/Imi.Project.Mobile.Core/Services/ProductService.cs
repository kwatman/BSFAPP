using Akavache;
using Imi.Project.Common;
using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        protected readonly IBaseRepository _baseRepository;
        public ProductService(IBaseRepository baseRepository, IBlobCache cache = null) : base(null, cache)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IList<Product>> GetByCategoryId(Guid categoryId)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/Categories/{categoryId}/Products"
            };

            var products = await _baseRepository.GetAllAsync<List<Product>>(uriBuilder.ToString());

            return products;
        }

        public async Task<IList<Product>> GetByDietaryRequirementId(Guid dietaryRequirementId)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/DietaryRequirements/{dietaryRequirementId}/Products"
            };

            var products = await _baseRepository.GetAllAsync<List<Product>>(uriBuilder.ToString());

            return products; ;
        }
    }
}
