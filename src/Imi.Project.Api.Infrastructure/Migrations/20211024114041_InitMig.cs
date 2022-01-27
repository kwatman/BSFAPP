using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DietaryRequirements",
                columns: table => new
                {
                    DietaryRequirementId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryRequirements", x => x.DietaryRequirementId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDietaryRequirements",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    DietaryRequirementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDietaryRequirements", x => new { x.ProductId, x.DietaryRequirementId });
                    table.ForeignKey(
                        name: "FK_ProductsDietaryRequirements_DietaryRequirements_DietaryRequirementId",
                        column: x => x.DietaryRequirementId,
                        principalTable: "DietaryRequirements",
                        principalColumn: "DietaryRequirementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsDietaryRequirements_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "BlogPostId", "PostDate", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2021, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recept: Eclairs" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nieuw product: Vegan Apple Crumble" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2021, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glazed in de Krant van West-Vlaanderen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Taart" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Gebak" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Koekjes met glazuur" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Koekjes met rolfondant" }
                });

            migrationBuilder.InsertData(
                table: "DietaryRequirements",
                columns: new[] { "DietaryRequirementId", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Vegan" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Glutenvrij" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Notenvrij" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Lactosevrij" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "amaury.decru@test.com", "Decru", "Test123", "+32 111 111 111", "Amaury" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "john.doe@test.com", "Doe", "Test123", "+32 222 222 222", "John" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "jane.doe@test.com", "Doe", "Test123", "+32 333 333 333", "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "Frans nagerecht van kersen in een lekker gebakken roommengsel uit de oven.", "Clafoutis van kersen", 8.50m },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000001"), "Kaastaart met citroencoulis op een bodem van caramelcrumble.", "Lemon Cheescake", 7.50m },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001"), "Verse crumble met stukjes appel en kaneel, heerlijk warm met een bolltje vanille-ijs.", "Vegan Apple Crumble", 7.50m },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002"), "Marmercake is de ultieme combinatie van een vanillecake en een chocoladecake.", "Marble Cake", 6m },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), "Frans gebakje op smaak gebracht met rum, een culinaire specialiteit uit de streek rond Bordeaux", "6 Cannelés de Bordeaux", 4.50m },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003"), "Vanille vegan koekjes met pompoenglazuur", "6 Vegan Pumpkin Cookies", 5m },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), "Vanille-kaneelkoekjes met vanille glazuur in Kertsthema.", "6 Chistmas Cinnamon Cookies", 5.50m },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003"), "Glazed signature vanille-donutkoekjes met roze glazuur en sprinkles.", "6 Glazed Doughnut Cookies", 6.50m },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), "Vanillekoekjes van het huis met roze rolfondant en het Glazed-logo.", "6 Glazed Signature Fondant Cookies", 3.50m },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), "Hartvormige chocoladekoekjes met afwerking in rode rolfondant", "6 Valentine Fondant Cookies", 4.50m }
                });

            migrationBuilder.InsertData(
                table: "ProductsDietaryRequirements",
                columns: new[] { "ProductId", "DietaryRequirementId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDietaryRequirements_DietaryRequirementId",
                table: "ProductsDietaryRequirements",
                column: "DietaryRequirementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "ProductsDietaryRequirements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DietaryRequirements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
