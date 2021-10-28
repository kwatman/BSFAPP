using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<IEnumerable<User>> SearchAsync(string searchString)
        {
            var users = await GetAll().Where(p => p.Name.Contains(searchString.Trim().ToUpper())
            || p.Name.Contains(searchString.Trim().ToUpper())
            || p.Surname.Contains(searchString.Trim().ToUpper())).ToListAsync();

            return users;
        }
    }
}
