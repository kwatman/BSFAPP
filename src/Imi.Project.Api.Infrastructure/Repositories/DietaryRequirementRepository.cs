using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class DietaryRequirementRepository: BaseRepository<DietaryRequirement>, IDietaryRequirementRepository
    {
        public DietaryRequirementRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
