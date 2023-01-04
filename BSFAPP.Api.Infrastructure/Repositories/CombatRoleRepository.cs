using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Data;

namespace BSFAPP.Api.Infrastructure.Repositories
{
    public class CombatRoleRepository : BaseRepository<CombatRole>, ICombatRoleRepository
    {
        public CombatRoleRepository(AppDbContext ctx) : base(ctx)
        {

        }
    }
}