using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class SecondaryMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDietaryRequirements_DietaryRequirements_DietaryRequirementId",
                table: "ProductsDietaryRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsDietaryRequirements_Products_ProductId",
                table: "ProductsDietaryRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsDietaryRequirements",
                table: "ProductsDietaryRequirements");

            migrationBuilder.RenameTable(
                name: "ProductsDietaryRequirements",
                newName: "ProductDietaryRequirement");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsDietaryRequirements_DietaryRequirementId",
                table: "ProductDietaryRequirement",
                newName: "IX_ProductDietaryRequirement_DietaryRequirementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDietaryRequirement",
                table: "ProductDietaryRequirement",
                columns: new[] { "ProductId", "DietaryRequirementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDietaryRequirement_DietaryRequirements_DietaryRequirementId",
                table: "ProductDietaryRequirement",
                column: "DietaryRequirementId",
                principalTable: "DietaryRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDietaryRequirement_Products_ProductId",
                table: "ProductDietaryRequirement",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDietaryRequirement_DietaryRequirements_DietaryRequirementId",
                table: "ProductDietaryRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDietaryRequirement_Products_ProductId",
                table: "ProductDietaryRequirement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDietaryRequirement",
                table: "ProductDietaryRequirement");

            migrationBuilder.RenameTable(
                name: "ProductDietaryRequirement",
                newName: "ProductsDietaryRequirements");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDietaryRequirement_DietaryRequirementId",
                table: "ProductsDietaryRequirements",
                newName: "IX_ProductsDietaryRequirements_DietaryRequirementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsDietaryRequirements",
                table: "ProductsDietaryRequirements",
                columns: new[] { "ProductId", "DietaryRequirementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDietaryRequirements_DietaryRequirements_DietaryRequirementId",
                table: "ProductsDietaryRequirements",
                column: "DietaryRequirementId",
                principalTable: "DietaryRequirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsDietaryRequirements_Products_ProductId",
                table: "ProductsDietaryRequirements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
