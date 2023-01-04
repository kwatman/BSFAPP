using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Data;

namespace BSFAPP.Api.Infrastructure.Repositories
{
    public class ParticipationRepository : BaseRepository<Participation>, IParticipationRepository
    {
        public ParticipationRepository(AppDbContext ctx) : base(ctx)
        {

        }
    }
}