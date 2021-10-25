using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.DietaryRequirements
{
    public class DietaryRequirementRequestDTO : BaseDTO
    {
        [Required(ErrorMessage ="Naam is verplicht")]
        public string Name { get; set; }
    }
}
