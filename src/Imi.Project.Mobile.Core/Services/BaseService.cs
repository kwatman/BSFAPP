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
    public class BaseService<T> : IBaseService<T> where T : Base
    {
        private readonly IBaseRepository _baseRepository;

        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IList<T>> GetAll()
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/{nameof(T)}s"
            };

            var data = await _baseRepository.GetAll<List<T>>(uriBuilder.ToString());

            return data;
        }

        public async Task<T> GetById(Guid id)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.ApiBase)
            {
                Path = $"api/{nameof(T)}s/{id}"
            };

            var data = await _baseRepository.GetById<T>(uriBuilder.ToString());

            return data;
        }

        public Task<T> Add()
        {
            throw new NotImplementedException();
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
