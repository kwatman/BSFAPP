using Imi.Project.Api.Core.DTO_S.Base;
using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.Products
{
    public class ProductRequestDTO : BaseDTO
    {
        [Required(ErrorMessage ="Naam is verplicht")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Beschrijving is verplicht")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Prijs is verplicht")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Categorie is verplicht")]
        public Guid CategoryId { get; set; }
    }
}
