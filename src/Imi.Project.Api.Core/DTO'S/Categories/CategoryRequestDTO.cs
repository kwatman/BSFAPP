using Imi.Project.Api.Core.DTO_S.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.Categories
{
    public class CategoryRequestDTO : BaseDTO
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }
    }
}
