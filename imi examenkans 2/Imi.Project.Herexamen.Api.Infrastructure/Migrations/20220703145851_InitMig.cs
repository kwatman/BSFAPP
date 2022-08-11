using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Herexamen.Api.Infrastucture.Migrations
{
    public partial class InitMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CombatRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    SquadLeader = table.Column<bool>(nullable: false),
                    CombatRoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CombatRoles_CombatRoleId",
                        column: x => x.CombatRoleId,
                        principalTable: "CombatRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodeName = table.Column<string>(nullable: true),
                    Sitrep = table.Column<string>(nullable: true),
                    ZeroHour = table.Column<DateTime>(nullable: false),
                    MapId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => new { x.UserId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_Participation_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CombatRoles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "The spine of the infantry and fist of the squad, the rifleman is equipped with a standard select-fire service rifle to carry out the offensive and defensive orders of their squad leader.", "Rifleman" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Provides overwatch and suppresive fire for his teammates through high firepower. Usually equipped with a belt-fed light machine gun to maximize combat efficiency.", "Autorifleman" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "A rifleman that specialises in the use of grenades and other explosives to provide high-angle fire over deadzones. Equiped with either a rifle or carabine fitted with an 40mm under-barrel grenade launcher", "Grenadier" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "An infantryman skilled in precision firepower at longer-than-usual ranges. Usually kitted with a DMR (Designated Marksman Rifle), a long-range version of typical assault rifles. Sometimes carries out reconnaissance tasks within the squad.", "Scout" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "A medically trained rifleman who's role is to provide emergency treatment to those wounded on the battlefield, friend or foe. Deployed to the front line within a regular fire team and armed as a regular rifleman, but expected to stay out of direct-fire lines to focus on treating those in need.", "Combat Medic" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Infantryman kitted with various anti-tank equipment to counter the threat of enemy armor. Loadouts usually include a carbine-style primary weapon, an launcher of recoilless rifle with AT-munitions and AT-mines.", "AT Specialist" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "A squadmate that provides engineering tasks in the AO, be it construction or demolition. Equipped with a standard rifleman's loadout supplemented with various tools to carry out his tasks.", "Combat Engineer" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Marksman who engages targets from positions of concealment, usually from out of the direct vincinity of his squadmates. Equipped with a long-range high-precision rifle with high-magnification optics.", "Sniper" }
                });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Sahrani" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Bystrica" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Isla Duala" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Chernarus" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Altis" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Malden" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Stratis" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Tembelan" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Tanoa" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Vidda" }
                });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CodeName", "MapId", "Sitrep", "ZeroHour" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000011"), "New Wind", new Guid("00000000-0000-0000-0000-000000000002"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 8, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "FUBAR", new Guid("00000000-0000-0000-0000-000000000009"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 1, 14, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Knife's Edge", new Guid("00000000-0000-0000-0000-000000000008"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 1, 3, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Dangerous Places", new Guid("00000000-0000-0000-0000-000000000006"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 4, 24, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Homesick", new Guid("00000000-0000-0000-0000-000000000006"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 4, 8, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Last Flight Night", new Guid("00000000-0000-0000-0000-000000000005"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 5, 5, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Last Flight", new Guid("00000000-0000-0000-0000-000000000005"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 4, 30, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Night Spear", new Guid("00000000-0000-0000-0000-000000000005"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 4, 16, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "Apex Predator", new Guid("00000000-0000-0000-0000-000000000004"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 24, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Dragon's Tail", new Guid("00000000-0000-0000-0000-000000000004"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 20, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "Lion's Den", new Guid("00000000-0000-0000-0000-000000000003"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 1, 20, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Blackjack", new Guid("00000000-0000-0000-0000-000000000003"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 14, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "Vulture", new Guid("00000000-0000-0000-0000-000000000002"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 1, 29, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Anvil", new Guid("00000000-0000-0000-0000-000000000002"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 29, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "White Christmas", new Guid("00000000-0000-0000-0000-000000000010"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2021, 12, 21, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Nexus", new Guid("00000000-0000-0000-0000-000000000001"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 6, 1, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Hellish Politics", new Guid("00000000-0000-0000-0000-000000000001"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 5, 21, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Half-Life", new Guid("00000000-0000-0000-0000-000000000001"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 5, 14, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Blackout", new Guid("00000000-0000-0000-0000-000000000001"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 4, 1, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Knock Knock", new Guid("00000000-0000-0000-0000-000000000010"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.", new DateTime(2022, 5, 27, 19, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CombatRoleId", "SquadLeader", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000008"), false, "Tokoshi" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000006"), true, "ChristianVoo" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005"), false, "Kwatman" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000003"), false, "IMrByBy3" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000002"), true, "PetrolHeadG98" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), true, "Brangers" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), false, "HollowPointsz" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000001"), false, "Tiski" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001"), false, "Aidan" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), true, "HOX" }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "UserId", "OperationId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000010") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000011") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000019") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000012") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000020") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000016") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_MapId",
                table: "Operations",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_OperationId",
                table: "Participation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CombatRoleId",
                table: "Users",
                column: "CombatRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "CombatRoles");
        }
    }
}
