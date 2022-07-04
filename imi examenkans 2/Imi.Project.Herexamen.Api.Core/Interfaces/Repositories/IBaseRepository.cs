using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        IQueryable<T> GetAll();
        Task<ServiceResponse<IEnumerable<T>>> ListAllAsync();
        Task<ServiceResponse<T>> GetByIdAsync(Guid id);
        Task<ServiceResponse<T>> CreateAsync(T entity);
        Task<ServiceResponse<T>> UpdateAsync(T entity);
        Task<ServiceResponse<T>> DeleteAsync(T entity);
    }
}