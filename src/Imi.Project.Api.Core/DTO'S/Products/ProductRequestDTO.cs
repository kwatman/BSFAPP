using Imi.Project.Api.Core.DTO_S.Base;
using Imi.Project.Api.Core.DTO_S.DietaryRequirements;
using Imi.Project.Api.Core.Entities;
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

        [Required(ErrorMessage ="Korte beschrijving is verplicht")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage ="Lange beschrijving is verplicht")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage ="Prijs is verplicht")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Categorie is verplicht")]
        public Guid CategoryId { get; set; }

        public ICollection<Guid> DietaryRequirementIds { get; set; }
    }
}
