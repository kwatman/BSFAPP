using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.Users
{
    public class UserResponseDTO : BaseDTO
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
