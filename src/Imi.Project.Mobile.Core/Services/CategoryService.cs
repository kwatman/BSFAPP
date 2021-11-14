using Akavache;
using Imi.Project.Common;
using Imi.Project.Mobile.Core.Interfaces.IRepositories;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services
{
    public class CategoryService: BaseService<Category>, ICategoryService
    {
        protected readonly IBaseRepository _baseRepository;
        public CategoryService(IBaseRepository baseRepository, IBlobCache cache = null) : base(null, cache)
        {
            _baseRepository = baseRepository;
        }

        public override async Task<IList<Category>> GetAll()
        {
            string cacheIdentifier = $"AllCategories";

            List<Category> dataFromCache = await ReadFromCache<List<Category>>(cacheIdentifier);

            if (dataFromCache != null)
            {
                return dataFromCache;
            }
            else
            {
                UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
                {
                    Path = $"api/Categories"
                };

                var data = await _baseRepository.GetAllAsync<List<Category>>(uriBuilder.ToString());

                await _cache.InsertObject(cacheIdentifier, data, DateTimeOffset.Now.AddSeconds(20));

                return data;
            }
        }

        public override async Task<Category> GetById(Guid id)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/Categories/{id}"
            };

            var category = await _baseRepository.GetAllAsync<Category>(uriBuilder.ToString());

            return category;
        }

        public override async Task<Category> Add(Category category)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/Categories"
            };

            var request = await _baseRepository.AddAsync<Category>(uriBuilder.ToString(), category);

            return request;
        }

        public override async Task<Category> Update(Category category)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/Categories"
            };

            var request = await _baseRepository.UpdateAsync(uriBuilder.ToString(), category);

            return request;
        }

        public override async Task<Category> Delete(Guid id)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/Categories/{id}"
            };

            await _baseRepository.DeleteAsync(uriBuilder.ToString());

            return default(Category);
        }
    }
}
