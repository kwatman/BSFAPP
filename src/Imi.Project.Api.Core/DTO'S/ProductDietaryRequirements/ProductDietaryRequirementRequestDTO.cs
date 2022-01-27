using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.DTO_S.ProductDietaryRequirements
{
    public class ProductDietaryRequirementRequestDTO
    {
        public Guid ProductId { get; set; }
        public Guid DietaryRequirementId { get; set; }
    }
}
