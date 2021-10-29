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
    public class DietaryRequirementRepository : BaseRepository<DietaryRequirement>, IDietaryRequirementRepository
    {
        public DietaryRequirementRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public override IQueryable<DietaryRequirement> GetAll()
        {
            return _appDbContext.DietaryRequirements.Include(dr => dr.ProductDietaryRequirements).ThenInclude(pdr => pdr.Product);
        }

        public async override Task<IEnumerable<DietaryRequirement>> ListAllAsync()
        {
            var dietaryRequirements = await GetAll().ToListAsync();
            return dietaryRequirements;
        }
    }
}
