using System;
using BSFAPP.Api.Core.DTO_S.Base;

namespace BSFAPP.Api.Core.DTO_S.Operation
{
    public class OperationRequestDTO : BaseDTO
    {
        public string CodeName { get; set; }
        public string Sitrep { get; set; }
        public DateTime ZeroHour { get; set; }
        // public Guid MapId { get; set; }
        // Participants
    }
}