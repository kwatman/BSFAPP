using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.Users
{
    public class UserRequestDTO : BaseDTO
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; }
    }
}
