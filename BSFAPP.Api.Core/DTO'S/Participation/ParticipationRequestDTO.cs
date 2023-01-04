using System;

namespace BSFAPP.Api.Core.DTO_S.Participation
{
    public class ParticipationRequestDTO
    {
        public Guid UserId { get; set; }
        public Guid OperationId { get; set; }
    }
}