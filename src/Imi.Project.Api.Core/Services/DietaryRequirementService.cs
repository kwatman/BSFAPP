using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class DietaryRequirementService: IDietaryRequirementService
    {
        protected readonly IBaseRepository<DietaryRequirement> _dietaryRequirementRepository;

        public DietaryRequirementService(IBaseRepository<DietaryRequirement> dietaryRequirementService)
        {
            _dietaryRequirementRepository = dietaryRequirementService;
        }

        public IQueryable<DietaryRequirement> GetAll()
        {
            return _dietaryRequirementRepository.GetAll();
        }

        public async Task<IEnumerable<DietaryRequirement>> ListAllAsync()
        {
            return await _dietaryRequirementRepository.GetAll().ToListAsync();
        }

        public async Task<DietaryRequirement> GetByIdAsync(Guid id)
        {
            return await _dietaryRequirementRepository.GetByIdAsync(id);
        }

        public async Task<DietaryRequirement> UpdateAsync(DietaryRequirement dietaryRequirement)
        {
            return await _dietaryRequirementRepository.UpdateAsync(dietaryRequirement);
        }

        public async Task<DietaryRequirement> AddAsync(DietaryRequirement dietaryRequirement)
        {
            return await _dietaryRequirementRepository.AddAsync(dietaryRequirement);
        }

        public async Task<DietaryRequirement> DeleteAsync(DietaryRequirement dietaryRequirement)
        {
            return await _dietaryRequirementRepository.DeleteAsync(dietaryRequirement);
        }
    }
}
