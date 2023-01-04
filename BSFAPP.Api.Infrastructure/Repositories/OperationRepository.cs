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
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public OperationRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public override IQueryable<Operation> GetAll()
        {
            return _ctx.Operations
                .Include(o => o.Map)
                .Include(o => o.Participations)
                .ThenInclude(p => p.User)
                .ThenInclude(u => u.CombatRole);
        }

        public override async Task<IEnumerable<Operation>> ListAllAsync()
        {
            var operations = await GetAll().ToListAsync();

            return operations;
        }

        public override async Task<Operation> GetByIdAsync(Guid id)
        {
            var operation = await GetAll().SingleOrDefaultAsync(o => o.Id.Equals(id));

            return operation;
        }

        public async Task<IEnumerable<Operation>> GetByMapIdAsync(Guid mapId)
        {
            var operations = await GetAll().Where(o => o.MapId.Equals(mapId)).ToListAsync();

            return operations;
        }

        public async Task<IEnumerable<Operation>> SearchAsync(string searchString)
        {
            var operations = await GetAll()
                .Where(o => o.CodeName.Contains(searchString.Trim().ToUpper()) ||
                            o.Map.Name.Contains(searchString.Trim().ToUpper())).ToListAsync();

            return operations;
        }
    }
}