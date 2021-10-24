using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DietaryRequirement> DietaryRequirements { get; set; }
        public DbSet<ProductDietaryRequirement> ProductsDietaryRequirements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<ProductDietaryRequirement>()
                .HasKey(pdr => new { pdr.ProductId, pdr.DietaryRequirementId });
            modelBuilder.Entity<ProductDietaryRequirement>()
                .HasOne(pdr => pdr.Product)
                .WithMany(p => p.ProductDietaryRequirements)
                .HasForeignKey(pdr => pdr.ProductId);
            modelBuilder.Entity<ProductDietaryRequirement>()
                .HasOne(pdr => pdr.DietaryRequirement)
                .WithMany(dr => dr.ProductDietaryRequirements)
                .HasForeignKey(pdr => pdr.DietaryRequirementId);

            modelBuilder.Entity<Category>().HasData(
                new[]
                {
                    new Category
                    {
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Taart"
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Gebak"
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Koekjes met glazuur"
                    },
                    new Category
                    {
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Koekjes met rolfondant"
                    }
                });
            modelBuilder.Entity<DietaryRequirement>().HasData(
                new[]
                {
                    new DietaryRequirement
                    {
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Vegan"
                    },
                    new DietaryRequirement
                    {
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Glutenvrij"
                    },
                    new DietaryRequirement
                    {
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Notenvrij"
                    },
                    new DietaryRequirement
                    {
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Lactosevrij"
                    }
                });

            modelBuilder.Entity<Product>().HasData(
                new[]
                {
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Clafoutis van kersen",
                        Description = "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven.",
                        Price = 8.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Marble Cake",
                        Description = "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake.",
                        Price = 6m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "6 Vegan Pumpkin Cookies",
                        Description = "Vanille vegan koekjes met pompoenglazuur",
                        Price = 5m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "6 Cannelés de Bordeaux",
                        Description = "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux",
                        Price = 4.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "6 Chistmas Cinnamon Cookies",
                        Description = "Vanille-kaneelkoekjes met vanille glazuur in Kertsthema.",
                        Price = 5.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "6 Glazed Signature Fondant Cookies",
                        Description = "Vanillekoekjes van het huis met roze rolfondant en het Glazed-logo.",
                        Price = 3.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Lemon Cheescake",
                        Description = "Kaastaart met citroencoulis op een bodem van caramelcrumble.",
                        Price = 7.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "6 Glazed Doughnut Cookies",
                        Description = "Glazed signature vanille-donutkoekjes met roze glazuur en sprinkles.",
                        Price = 6.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "6 Valentine Fondant Cookies",
                        Description = "Hartvormige chocoladekoekjes met afwerking in rode rolfondant",
                        Price = 4.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new Product
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Vegan Apple Crumble",
                        Description = "Verse crumble met stukjes appel en kaneel, heerlijk warm met een bolltje vanille-ijs.",
                        Price = 7.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    }
                });

            modelBuilder.Entity<ProductDietaryRequirement>().HasData(
                new[] 
                { 
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },
                    new ProductDietaryRequirement
                    {
                        ProductId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        DietaryRequirementId = Guid.Parse("00000000-0000-0000-0000-000000000004")
                    },
                });

            modelBuilder.Entity<User>().HasData(
                new[]
                {
                    new User
                    {
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Decru",
                        Surname = "Amaury",
                        Email = "amaury.decru@test.com",
                        PhoneNumber = "+32 111 111 111",
                        Password = "Test123"
                    },
                    new User
                    {
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Doe",
                        Surname = "John",
                        Email = "john.doe@test.com",
                        PhoneNumber = "+32 222 222 222",
                        Password = "Test123"
                    },
                    new User
                    {
                        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Doe",
                        Surname = "Jane",
                        Email = "jane.doe@test.com",
                        PhoneNumber = "+32 333 333 333",
                        Password = "Test123"
                    }
                });

            modelBuilder.Entity<BlogPost>().HasData(
                new[]
                {
                    new BlogPost
                    {
                        BlogPostId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Title = "Recept: Eclairs",
                        PostDate = DateTime.Parse("23/07/2021")
                    },
                    new BlogPost
                    {
                        BlogPostId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Title = "Nieuw product: Vegan Apple Crumble",
                        PostDate = DateTime.Parse("18/09/2021")
                    },
                    new BlogPost
                    {
                        BlogPostId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Title = "Glazed in de Krant van West-Vlaanderen",
                        PostDate = DateTime.Parse("13/10/2021")
                    }
                });
        }
    }
}
