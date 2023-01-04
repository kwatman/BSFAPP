using System.Threading.Tasks;
using BSFAPP.Api.Core.DTO_S.Participation;
using BSFAPP.Api.Core.DTO_S.User;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Services
{
    public interface IParticipationService
    {
        Task<ServiceResponse<UserResponseDTO>> AddParticipation(ParticipationRequestDTO request);
    }
}