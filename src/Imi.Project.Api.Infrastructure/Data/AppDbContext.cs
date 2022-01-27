using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DietaryRequirement> DietaryRequirements { get; set; }
        public DbSet<ProductDietaryRequirement> ProductsDietaryRequirements { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .IsRequired();

            modelBuilder.Entity<ProductDietaryRequirement>()
                .ToTable("ProductDietaryRequirement")
                .HasKey(pdr => new { pdr.ProductId, pdr.DietaryRequirementId });
            modelBuilder.Entity<ProductDietaryRequirement>()
                .HasOne(pdr => pdr.Product)
                .WithMany(p => p.ProductDietaryRequirements)
                .HasForeignKey(pdr => pdr.ProductId);
            modelBuilder.Entity<ProductDietaryRequirement>()
                .HasOne(pdr => pdr.DietaryRequirement)
                .WithMany(dr => dr.ProductDietaryRequirements)
                .HasForeignKey(pdr => pdr.DietaryRequirementId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(80);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80);
            modelBuilder.Entity<DietaryRequirement>()
                .Property(dr => dr.Name)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Category>().HasData(
                new[]
                {
                    new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Taart"
                    },
                    new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Gebak"
                    },
                    new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Koekjes met glazuur"
                    },
                    new Category
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Koekjes met rolfondant"
                    }
                });

            modelBuilder.Entity<DietaryRequirement>().HasData(
                new[]
                {
                    new DietaryRequirement
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Vegan"
                    },
                    new DietaryRequirement
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Glutenvrij"
                    },
                    new DietaryRequirement
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Notenvrij"
                    },
                    new DietaryRequirement
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Lactosevrij"
                    }
                });

            modelBuilder.Entity<Product>().HasData(
                new[]
                {
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Clafoutis van kersen",
                        ShortDescription = "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 8.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        ImageURI = "kersenclafoutis.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Marble Cake",
                        ShortDescription = "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 6m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        ImageURI = "marblecake.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "6 Vegan Pumpkin Cookies",
                        ShortDescription = "Vanille vegan koekjes met pompoenglazuur",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 5m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        ImageURI = "pumpkincookie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "6 Cannelés de Bordeaux",
                        ShortDescription = "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 4.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        ImageURI = "canneles.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "6 Chistmas Cinnamon Cookies",
                        ShortDescription = "Chocolade-kaneelkoekjes met vanille glazuur in Kertsthema.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 5.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        ImageURI = "peppermintcookie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "6 Glazed Signature Fondant Cookies",
                        ShortDescription = "Vanillekoekjes van het huis met roze rolfondant en het Glazed-logo.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 3.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        ImageURI = "fondantcookie.jpeg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Lemon Cheescake",
                        ShortDescription = "Kaastaart met citroencoulis op een bodem van caramelcrumble.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 7.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        ImageURI = "lemoncheesecake.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "6 Glazed Doughnut Cookies",
                        ShortDescription = "Glazed signature vanille-donutkoekjes met roze glazuur en sprinkles.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 6.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        ImageURI = "doughnutcookie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "6 Valentine Fondant Cookies",
                        ShortDescription = "Hartvormige chocoladekoekjes met afwerking in rode rolfondant",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 4.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        ImageURI = "marblecookie.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Vegan Apple Crumble",
                        ShortDescription = "Verse crumble met stukjes appel en kaneel, heerlijk warm met een bolltje vanille-ijs.",
                        LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis.",
                        Price = 7.50m,
                        CategoryId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        ImageURI = "applecrumble.jpg"
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

            //modelBuilder.Entity<User>().HasData(
            //    new[]
            //    {
            //        new User
            //        {
            //            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            //            Name = "Decru",
            //            Surname = "Amaury",
            //            Email = "amaury.decru@test.com",
            //            PhoneNumber = "+32 111 111 111",
            //            Password = "Test123"
            //        },
            //        new User
            //        {
            //            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            //            Name = "Doe",
            //            Surname = "John",
            //            Email = "john.doe@test.com",
            //            PhoneNumber = "+32 222 222 222",
            //            Password = "Test123"
            //        },
            //        new User
            //        {
            //            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            //            Name = "Doe",
            //            Surname = "Jane",
            //            Email = "jane.doe@test.com",
            //            PhoneNumber = "+32 333 333 333",
            //            Password = "Test123"
            //        }
            //    });

            modelBuilder.Entity<BlogPost>().HasData(
                new[]
                {
                    new BlogPost
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Title = "Recept: Eclairs",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis." +
                        "Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. " +
                        "Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. " +
                        "Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. " +
                        "Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. " +
                        "Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. " +
                        "Integer sollicitudin metus tellus, et pretium nibh imperdiet ut." +
                        "Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. " +
                        "Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. " +
                        "Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. " +
                        "Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. " +
                        "Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.",
                        PostDate = DateTime.Parse("23/07/2021")
                    },
                    new BlogPost
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Title = "Nieuw product: Vegan Apple Crumble",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis." +
                        "Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. " +
                        "Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. " +
                        "Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. " +
                        "Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. " +
                        "Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. " +
                        "Integer sollicitudin metus tellus, et pretium nibh imperdiet ut." +
                        "Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. " +
                        "Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. " +
                        "Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. " +
                        "Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. " +
                        "Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.",
                        PostDate = DateTime.Parse("18/09/2021")
                    },
                    new BlogPost
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Title = "Glazed in de Krant van West-Vlaanderen",
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                        "Ut auctor orci ac luctus pulvinar. Nam finibus a ante sed varius. Donec eget erat elit. " +
                        "Suspendisse lobortis suscipit leo. Morbi quis lorem lacus. " +
                        "Fusce elementum, mauris nec euismod finibus, sapien enim pharetra ex, ut porttitor risus sem nec ante. " +
                        "In dapibus libero ut mattis imperdiet. Nulla aliquam fermentum erat, non pellentesque enim vestibulum nec. " +
                        "Phasellus sit amet dui nunc. Integer placerat maximus sodales. Ut feugiat lorem quis eros dignissim, eu varius velit consectetur. " +
                        "Mauris pulvinar elementum orci vitae sodales. Morbi lacinia ultricies ligula id sollicitudin. " +
                        "Suspendisse consectetur nibh ac metus luctus facilisis." +
                        "Suspendisse potenti. Nullam ut lorem auctor, lacinia mauris at, viverra est. " +
                        "Donec finibus odio eu leo efficitur, eget dapibus elit hendrerit. Aliquam eu rutrum justo. " +
                        "Pellentesque sagittis efficitur molestie. Fusce ut neque sit amet felis bibendum rutrum. " +
                        "Sed sit amet massa a urna volutpat sodales. Mauris elit nibh, ornare quis commodo a, pellentesque nec turpis. " +
                        "Nam ullamcorper nibh viverra turpis lobortis, laoreet eleifend erat lobortis. " +
                        "Integer sollicitudin metus tellus, et pretium nibh imperdiet ut." +
                        "Aliquam cursus ligula sed erat volutpat accumsan. Fusce ut risus sollicitudin, tincidunt elit commodo, varius nunc. " +
                        "Vivamus fermentum eros at egestas tristique. Duis metus purus, auctor et congue vitae, finibus rhoncus arcu. " +
                        "Aenean lobortis, sem a rutrum commodo, urna velit posuere lacus, aliquam rutrum sapien lacus ac sem. " +
                        "Proin auctor, augue et tempor imperdiet, ante urna blandit tortor, vitae condimentum massa velit nec arcu. " +
                        "Mauris euismod magna id velit consectetur lacinia. Nam id sapien et justo tempor consectetur ac vitae massa.",
                        PostDate = DateTime.Parse("13/10/2021")
                    }
                });
        }
    }
}
