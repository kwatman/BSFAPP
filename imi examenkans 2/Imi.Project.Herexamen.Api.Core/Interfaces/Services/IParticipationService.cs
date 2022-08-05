using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.DTO_S.Participation;
using Imi.Project.Herexamen.Api.Core.DTO_S.User;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core.Interfaces.Services
{
    public interface IParticipationService
    {
        Task<ServiceResponse<UserResponseDTO>> AddParticipation(ParticipationRequestDTO request);
    }
}