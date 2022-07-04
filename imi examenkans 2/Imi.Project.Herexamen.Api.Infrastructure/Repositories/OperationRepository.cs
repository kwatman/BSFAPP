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
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public OperationRepository(AppDbContext ctx) : base(ctx)
        {

        }

        public override IQueryable<Operation> GetAll()
        {
            return _ctx.Operations.Include(o => o.Map);
        }

        public override async Task<ServiceResponse<IEnumerable<Operation>>> ListAllAsync()
        {
            ServiceResponse<IEnumerable<Operation>> response = new ServiceResponse<IEnumerable<Operation>>();
            var operations = await GetAll().ToListAsync();
            response.Data = operations;

            return response;
        }

        public override async Task<ServiceResponse<Operation>> GetByIdAsync(Guid id)
        {
            ServiceResponse<Operation> response = new ServiceResponse<Operation>();
            var operation = await GetAll().SingleOrDefaultAsync(o => o.Id.Equals(id));
            response.Data = operation;

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Operation>>> GetByMapIdAsync(Guid mapId)
        {
            ServiceResponse<IEnumerable<Operation>> response = new ServiceResponse<IEnumerable<Operation>>();
            var operations = await GetAll().Where(o => o.MapId.Equals(mapId)).ToListAsync();
            response.Data = operations;

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Operation>>> SearchAsync(string searchString)
        {
            ServiceResponse<IEnumerable<Operation>> response = new ServiceResponse<IEnumerable<Operation>>();
            var operations = await GetAll()
                .Where(o => o.CodeName.Contains(searchString.Trim().ToUpper()) ||
                            o.Map.Name.Contains(searchString.Trim().ToUpper())).ToListAsync();
            response.Data = operations;

            return response;
        }
    }
}