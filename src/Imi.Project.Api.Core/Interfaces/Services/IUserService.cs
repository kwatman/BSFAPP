using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        IQueryable<User> GetAll();
        Task<IEnumerable<User>> ListAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateAsync(User user);
        Task<User> AddAsync(User user);
        Task<User> DeleteAsync(User user);
    }
}
