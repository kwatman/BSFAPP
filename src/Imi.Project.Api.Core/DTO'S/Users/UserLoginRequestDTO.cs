using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.Users
{
    public class UserLoginRequestDTO
    {
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50), MinLength(6)]
        public string Password { get; set; }
    }
}
