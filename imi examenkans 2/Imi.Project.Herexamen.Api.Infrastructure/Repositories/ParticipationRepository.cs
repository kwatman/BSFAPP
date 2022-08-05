using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Imi.Project.Herexamen.Api.Infrastructure.Data;

namespace Imi.Project.Herexamen.Api.Infrastucture.Repositories
{
    public class ParticipationRepository : BaseRepository<Participation>, IParticipationRepository
    {
        public ParticipationRepository(AppDbContext ctx) : base(ctx)
        {

        }
    }
}