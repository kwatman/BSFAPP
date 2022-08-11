using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Herexamen.Api.Infrastucture.Migrations
{
    public partial class TableNameErrorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Maps_MapId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_Operations_OperationId",
                table: "Participation");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_Users_UserId",
                table: "Participation");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_CombatRoles_CombatRoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombatRoles",
                table: "CombatRoles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Operation");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.RenameTable(
                name: "CombatRoles",
                newName: "CombatRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CombatRoleId",
                table: "User",
                newName: "IX_User_CombatRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Operations_MapId",
                table: "Operation",
                newName: "IX_Operation_MapId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Participation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operation",
                table: "Operation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombatRole",
                table: "CombatRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Map_MapId",
                table: "Operation",
                column: "MapId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_Operation_OperationId",
                table: "Participation",
                column: "OperationId",
                principalTable: "Operation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_User_UserId",
                table: "Participation",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_CombatRole_CombatRoleId",
                table: "User",
                column: "CombatRoleId",
                principalTable: "CombatRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Map_MapId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_Operation_OperationId",
                table: "Participation");

            migrationBuilder.DropForeignKey(
                name: "FK_Participation_User_UserId",
                table: "Participation");

            migrationBuilder.DropForeignKey(
                name: "FK_User_CombatRole_CombatRoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operation",
                table: "Operation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombatRole",
                table: "CombatRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Participation");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Operation",
                newName: "Operations");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.RenameTable(
                name: "CombatRole",
                newName: "CombatRoles");

            migrationBuilder.RenameIndex(
                name: "IX_User_CombatRoleId",
                table: "Users",
                newName: "IX_Users_CombatRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_MapId",
                table: "Operations",
                newName: "IX_Operations_MapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombatRoles",
                table: "CombatRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Maps_MapId",
                table: "Operations",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_Operations_OperationId",
                table: "Participation",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participation_Users_UserId",
                table: "Participation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CombatRoles_CombatRoleId",
                table: "Users",
                column: "CombatRoleId",
                principalTable: "CombatRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
