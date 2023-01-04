using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BSFAPP.Api.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public override IQueryable<User> GetAll()
        {
            return _ctx.Users
                .Include(u => u.CombatRole);
        }

        public override async Task<IEnumerable<User>> ListAllAsync()
        {
            var users = await GetAll().ToListAsync();

            return users;
        }

        public override async Task<User> GetByIdAsync(Guid id)
        {
            var user = await GetAll().SingleOrDefaultAsync(u => u.Id.Equals(id));

            return user;
        }

        public async Task<IEnumerable<User>> GetByCombatRoleIdAsync(Guid combatRoleId)
        {
            var users = await GetAll().Where(u => u.CombatRoleId.Equals(combatRoleId)).ToListAsync();

            return users;
        }

        public async Task<IEnumerable<User>> SearchAsync(string searchString)
        {
            var users = await GetAll()
                .Where(u => u.Username.Contains(searchString.Trim().ToUpper()) ||
                            u.CombatRole.Name.Contains(searchString.Trim().ToUpper())).ToListAsync();

            return users;
        }
    }
}