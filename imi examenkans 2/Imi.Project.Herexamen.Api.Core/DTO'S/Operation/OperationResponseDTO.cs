using System;
using Imi.Project.Herexamen.Api.Core.DTO_S.Base;
using Imi.Project.Herexamen.Api.Core.DTO_S.Map;

namespace Imi.Project.Herexamen.Api.Core.DTO_S.Operation
{
    public class OperationResponseDTO : BaseDTO
    {
        public string CodeName { get; set; }
        public string Sitrep { get; set; }
        public DateTime ZeroHour { get; set; }
        public MapResponseDTO Map { get; set; }
        // Participants
    }
}