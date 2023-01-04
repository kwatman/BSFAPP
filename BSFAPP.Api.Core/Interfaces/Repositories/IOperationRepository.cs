using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Repositories
{
    public interface IOperationRepository : IBaseRepository<Operation>
    {
        Task<IEnumerable<Operation>> GetByMapIdAsync(Guid mapId);
        Task<IEnumerable<Operation>> SearchAsync(string searchString);
    }
}