using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Herexamen.Api.Infrastucture.Migrations
{
    public partial class AddRoleBasedAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAcceptedTermsAndConditions",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                nullable: false,
                defaultValue: "User");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CombatRoleId", "Email", "HasAcceptedTermsAndConditions", "PasswordHash", "PasswordSalt", "Role", "SquadLeader", "Username" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000001"), "admin@pri.be", false, new byte[] { 185, 83, 29, 157, 81, 100, 197, 135, 196, 90, 8, 128, 47, 94, 117, 24, 230, 164, 198, 42, 237, 234, 139, 97, 16, 45, 185, 32, 124, 220, 185, 75, 236, 171, 166, 100, 177, 221, 183, 121, 219, 19, 129, 191, 99, 234, 36, 240, 29, 29, 221, 133, 84, 95, 123, 179, 176, 115, 114, 90, 17, 233, 154, 240 }, new byte[] { 169, 167, 45, 13, 12, 209, 123, 170, 203, 203, 54, 246, 186, 83, 0, 97, 144, 68, 222, 87, 17, 125, 204, 230, 114, 141, 120, 63, 202, 82, 202, 58, 216, 25, 7, 112, 52, 43, 211, 101, 136, 168, 237, 131, 195, 143, 148, 193, 57, 107, 3, 235, 81, 234, 88, 150, 247, 99, 80, 42, 216, 135, 78, 209, 204, 1, 117, 93, 120, 96, 244, 4, 100, 245, 208, 173, 127, 240, 33, 244, 193, 189, 162, 109, 142, 240, 187, 188, 95, 161, 90, 137, 127, 133, 211, 106, 82, 249, 21, 40, 211, 154, 53, 215, 50, 35, 52, 161, 63, 134, 106, 117, 29, 121, 139, 104, 199, 153, 107, 229, 11, 146, 204, 29, 224, 126, 127, 13 }, "Admin", false, "PriAdmin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CombatRoleId", "Email", "HasAcceptedTermsAndConditions", "PasswordHash", "PasswordSalt", "Role", "SquadLeader", "Username" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000001"), "user@pri.be", true, new byte[] { 185, 83, 29, 157, 81, 100, 197, 135, 196, 90, 8, 128, 47, 94, 117, 24, 230, 164, 198, 42, 237, 234, 139, 97, 16, 45, 185, 32, 124, 220, 185, 75, 236, 171, 166, 100, 177, 221, 183, 121, 219, 19, 129, 191, 99, 234, 36, 240, 29, 29, 221, 133, 84, 95, 123, 179, 176, 115, 114, 90, 17, 233, 154, 240 }, new byte[] { 169, 167, 45, 13, 12, 209, 123, 170, 203, 203, 54, 246, 186, 83, 0, 97, 144, 68, 222, 87, 17, 125, 204, 230, 114, 141, 120, 63, 202, 82, 202, 58, 216, 25, 7, 112, 52, 43, 211, 101, 136, 168, 237, 131, 195, 143, 148, 193, 57, 107, 3, 235, 81, 234, 88, 150, 247, 99, 80, 42, 216, 135, 78, 209, 204, 1, 117, 93, 120, 96, 244, 4, 100, 245, 208, 173, 127, 240, 33, 244, 193, 189, 162, 109, 142, 240, 187, 188, 95, 161, 90, 137, 127, 133, 211, 106, 82, 249, 21, 40, 211, 154, 53, 215, 50, 35, 52, 161, 63, 134, 106, 117, 29, 121, 139, 104, 199, 153, 107, 229, 11, 146, 204, 29, 224, 126, 127, 13 }, "User", false, "PriUser" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CombatRoleId", "Email", "HasAcceptedTermsAndConditions", "PasswordHash", "PasswordSalt", "Role", "SquadLeader", "Username" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000001"), "Refuser@pri.be", false, new byte[] { 185, 83, 29, 157, 81, 100, 197, 135, 196, 90, 8, 128, 47, 94, 117, 24, 230, 164, 198, 42, 237, 234, 139, 97, 16, 45, 185, 32, 124, 220, 185, 75, 236, 171, 166, 100, 177, 221, 183, 121, 219, 19, 129, 191, 99, 234, 36, 240, 29, 29, 221, 133, 84, 95, 123, 179, 176, 115, 114, 90, 17, 233, 154, 240 }, new byte[] { 169, 167, 45, 13, 12, 209, 123, 170, 203, 203, 54, 246, 186, 83, 0, 97, 144, 68, 222, 87, 17, 125, 204, 230, 114, 141, 120, 63, 202, 82, 202, 58, 216, 25, 7, 112, 52, 43, 211, 101, 136, 168, 237, 131, 195, 143, 148, 193, 57, 107, 3, 235, 81, 234, 88, 150, 247, 99, 80, 42, 216, 135, 78, 209, 204, 1, 117, 93, 120, 96, 244, 4, 100, 245, 208, 173, 127, 240, 33, 244, 193, 189, 162, 109, 142, 240, 187, 188, 95, 161, 90, 137, 127, 133, 211, 106, 82, 249, 21, 40, 211, 154, 53, 215, 50, 35, 52, 161, 63, 134, 106, 117, 29, 121, 139, 104, 199, 153, 107, 229, 11, 146, 204, 29, 224, 126, 127, 13 }, "User", false, "PriRefuser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "HasAcceptedTermsAndConditions",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");
        }
    }
}
