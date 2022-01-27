using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces.IRepositories
{
    public interface IBaseRepository
    {
        Task<T> GetAllAsync<T>(string uri, string authToken = "");
        Task<T> UpdateAsync<T>(string uri, T model, string authToken = "");
        Task<T> AddAsync<T>(string uri, T model, string authToken = "");
        Task DeleteAsync(string uri, string authToken = "");
    }
}
