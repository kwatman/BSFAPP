using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> SearchAsync(string searchString);
    }
}
