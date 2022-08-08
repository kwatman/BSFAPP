using System;
using System.Collections.Generic;
using Imi.Project.Herexamen.Api.Core.DTO_S.Base;
using Imi.Project.Herexamen.Api.Core.DTO_S.Map;
using Imi.Project.Herexamen.Api.Core.DTO_S.User;

namespace Imi.Project.Herexamen.Api.Core.DTO_S.Operation
{
    public class OperationResponseDTO : BaseDTO
    {
        public string CodeName { get; set; }
        public string Sitrep { get; set; }
        public DateTime ZeroHour { get; set; }
        public MapResponseDTO Map { get; set; }
        public List<UserResponseDTO> Participants { get; set; }
    }
}