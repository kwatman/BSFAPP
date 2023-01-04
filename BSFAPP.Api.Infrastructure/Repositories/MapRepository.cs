using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Data;

namespace BSFAPP.Api.Infrastructure.Repositories
{
    public class MapRepository : BaseRepository<Map>, IMapRepository
    {
        public MapRepository(AppDbContext ctx) : base(ctx)
        {

        }
    }
}