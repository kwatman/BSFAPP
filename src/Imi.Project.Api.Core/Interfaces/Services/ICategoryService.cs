using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        Task<IEnumerable<Category>> ListAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> UpdateAsync(Category category);
        Task<Category> AddAsync(Category category);
        Task<Category> DeleteAsync(Category category);
    }
}
