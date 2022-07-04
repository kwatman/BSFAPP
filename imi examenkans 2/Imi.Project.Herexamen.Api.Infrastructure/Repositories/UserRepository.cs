using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Imi.Project.Herexamen.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Herexamen.Api.Infrastucture.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public override IQueryable<User> GetAll()
        {
            return _ctx.Users.Include(u => u.CombatRole);
        }

        public override async Task<ServiceResponse<IEnumerable<User>>> ListAllAsync()
        {
            ServiceResponse<IEnumerable<User>> response = new ServiceResponse<IEnumerable<User>>();
            var users = await GetAll().ToListAsync();
            response.Data = users;

            return response;
        }

        public override async Task<ServiceResponse<User>> GetByIdAsync(Guid id)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            var user = await GetAll().SingleOrDefaultAsync(u => u.Id.Equals(id));
            response.Data = user;

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<User>>> GetByCombatRoleIdAsync(Guid combatRoleId)
        {
            ServiceResponse<IEnumerable<User>> response = new ServiceResponse<IEnumerable<User>>();
            var users = await GetAll().Where(u => u.CombatRoleId.Equals(combatRoleId)).ToListAsync();
            response.Data = users;

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<User>>> SearchAsync(string searchString)
        {
            ServiceResponse<IEnumerable<User>> response = new ServiceResponse<IEnumerable<User>>();
            var users = await GetAll()
                .Where(u => u.Username.Contains(searchString.Trim().ToUpper()) ||
                            u.CombatRole.Name.Contains(searchString.Trim().ToUpper())).ToListAsync();
            response.Data = users;

            return response;
        }
    }
}