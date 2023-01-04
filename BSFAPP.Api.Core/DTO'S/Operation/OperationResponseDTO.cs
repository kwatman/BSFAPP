using System;
using System.Collections.Generic;
using BSFAPP.Api.Core.DTO_S.Base;
using BSFAPP.Api.Core.DTO_S.Map;
using BSFAPP.Api.Core.DTO_S.User;

namespace BSFAPP.Api.Core.DTO_S.Operation
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