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
    public class BaseService<T> : CacheService, IBaseService<T> where T : Base
    {
        private readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository baseRepository, IBlobCache cache = null) : base(cache)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IList<T>> GetAll()
        {
            string cacheIdentifier = $"All{nameof(T)}s";

            List<T> dataFromCache = await ReadFromCache<List<T>>(cacheIdentifier);

            if (dataFromCache != null)
            {
                return dataFromCache;
            }
            else
            {
                UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
                {
                    Path = $"api/{nameof(T)}s"
                };

                var data = await _baseRepository.GetAllAsync<List<T>>(uriBuilder.ToString());

                await _cache.InsertObject(cacheIdentifier, data, DateTimeOffset.Now.AddSeconds(20));

                return data;
            }
        }

        public async Task<T> GetById(Guid id)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/{nameof(T)}s/{id}"
            };

            var data = await _baseRepository.GetAllAsync<T>(uriBuilder.ToString());

            return data;
        }

        public async Task<T> Add(T data)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/{nameof(T)}s"
            };

            var request = await _baseRepository.AddAsync<T>(uriBuilder.ToString(), data);

            return request;
        }
        public Task<T> Update()
        {
            throw new NotImplementedException();
        }
        public Task<T> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
