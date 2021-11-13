using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces.IRepositories
{
    public interface IBaseRepository
    {
        Task<T> GetAll<T>(string uri, string authToken = "");
        Task<T> GetById<T>(string uri, string authToken = "");
        Task<T> Update<T>(string uri, T model, string authToken = "");
        Task<T> Add<T>(string uri, T model, string authToken = "");
        Task<T> Delete<T>(string uri, string authToken = "");
    }
}
