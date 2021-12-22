using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IDietaryRequirementService
    {
        IQueryable<DietaryRequirement> GetAll();
        Task<IEnumerable<DietaryRequirement>> ListAllAsync();
        Task<DietaryRequirement> GetByIdAsync(Guid id);
        Task<DietaryRequirement> UpdateAsync(DietaryRequirement dietaryRequirement);
        Task<DietaryRequirement> AddAsync(DietaryRequirement dietaryRequirement);
        Task<DietaryRequirement> DeleteAsync(DietaryRequirement dietaryRequirement);
    }
}
