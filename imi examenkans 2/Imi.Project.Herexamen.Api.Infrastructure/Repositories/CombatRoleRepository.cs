using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Imi.Project.Herexamen.Api.Infrastructure.Data;

namespace Imi.Project.Herexamen.Api.Infrastucture.Repositories
{
    public class CombatRoleRepository : BaseRepository<CombatRole>, ICombatRoleRepository
    {
        public CombatRoleRepository(AppDbContext ctx) : base(ctx)
        {

        }
    }
}