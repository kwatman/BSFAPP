using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<ServiceResponse<IEnumerable<User>>> GetByCombatRoleIdAsync(Guid combatRoleId);
        Task<ServiceResponse<IEnumerable<User>>> SearchAsync(string searchString);
    }
}