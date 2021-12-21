using Imi.Project.Api.Core.DTO_S.ProductDietaryRequirements;
using Imi.Project.Api.Core.DTO_S.Products;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Infrastructure;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class ProductDietaryRequirementRepository: IProductDietaryRequirementRepository
    {
        protected readonly AppDbContext _appDbContext;
        public ProductDietaryRequirementRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductDietaryRequirement> AddProductDietaryRequirement(ProductDietaryRequirementRequestDTO newProductDietaryRequirement)
        {
            Product product = await _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductDietaryRequirements).ThenInclude(pdr => pdr.DietaryRequirement)
                .FirstOrDefaultAsync(p => p.Id == newProductDietaryRequirement.ProductId);

            DietaryRequirement dietaryRequirement = await _appDbContext.DietaryRequirements
                .FirstOrDefaultAsync(pdr => pdr.Id == newProductDietaryRequirement.DietaryRequirementId);

            ProductDietaryRequirement productDietaryRequirement = new ProductDietaryRequirement
            {
                ProductId = product.Id,
                DietaryRequirementId = dietaryRequirement.Id
            };

            await _appDbContext.AddAsync(productDietaryRequirement);
            await _appDbContext.SaveChangesAsync();
            return productDietaryRequirement;
        }
    }
}
