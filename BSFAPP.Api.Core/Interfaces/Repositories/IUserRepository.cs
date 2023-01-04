using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetByCombatRoleIdAsync(Guid combatRoleId);
        Task<IEnumerable<User>> SearchAsync(string searchString);
    }
}