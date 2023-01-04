using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}