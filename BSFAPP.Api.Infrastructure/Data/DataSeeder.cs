using System;
using BSFAPP.Api.Core.Models;
using BSFAPP.Api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BSFAPP.Api.Infrastructure.Data
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            AuthRepository.HashPassword("Test123?", out byte[] passwordHash, out byte[] passwordSalt);

            modelBuilder.Entity<Map>().HasData(
                new[]
                {
                    new Map
                    {
                        Id = 1,
                        Name = "Altis"
                    },

                    new Map
                    {
                        Id = 2,
                        Name = "Stratis"
                    },

                    new Map
                    {
                        Id = 3,
                        Name = "Malden"
                    },

                    new Map
                    {
                        Id = 4,
                        Name = "Tanoa"
                    },

                    new Map
                    {
                        Id = 5,
                        Name = "Chernarus"
                    },

                    new Map
                    {
                        Id = 6,
                        Name = "Isla Duala"
                    },

                    new Map
                    {
                        Id = 7,
                        Name = "Bystrica"
                    },

                    new Map
                    {
                        Id = 8,
                        Name = "Sahrani"
                    },

                    new Map
                    {
                        Id = 9,
                        Name = "Tembelan"
                    },

                    new Map
                    {
                        Id = 10,
                        Name = "Vidda"
                    }
                });

            modelBuilder.Entity<CombatRole>().HasData(
                new[]
                {
                    new CombatRole
                    {
                        Id = 1,
                        Name = "Rifleman",
                        Description = "The spine of the infantry and fist of the squad, the rifleman is equipped with a standard select-fire service rifle to carry out the offensive and defensive orders of their squad leader."
                    },

                    new CombatRole
                    {
                        Id = 2,
                        Name = "Autorifleman",
                        Description = "Provides overwatch and suppresive fire for his teammates through high firepower. Usually equipped with a belt-fed light machine gun to maximize combat efficiency."
                    },

                    new CombatRole
                    {
                        Id = 3,
                        Name = "Grenadier",
                        Description = "A rifleman that specialises in the use of grenades and other explosives to provide high-angle fire over deadzones. Equiped with either a rifle or carabine fitted with an 40mm under-barrel grenade launcher"
                    },

                    new CombatRole
                    {
                        Id = 4,
                        Name = "Scout",
                        Description = "An infantryman skilled in precision firepower at longer-than-usual ranges. Usually kitted with a DMR (Designated Marksman Rifle), a long-range version of typical assault rifles. Sometimes carries out reconnaissance tasks within the squad."
                    },

                    new CombatRole
                    {
                        Id = 5,
                        Name = "Combat Medic",
                        Description = "A medically trained rifleman who's role is to provide emergency treatment to those wounded on the battlefield, friend or foe. Deployed to the front line within a regular fire team and armed as a regular rifleman, but expected to stay out of direct-fire lines to focus on treating those in need."
                    },

                    new CombatRole
                    {
                        Id = 6,
                        Name = "AT Specialist",
                        Description = "Infantryman kitted with various anti-tank equipment to counter the threat of enemy armor. Loadouts usually include a carbine-style primary weapon, an launcher of recoilless rifle with AT-munitions and AT-mines."
                    },

                    new CombatRole
                    {
                        Id = 7,
                        Name = "Combat Engineer",
                        Description = "A squadmate that provides engineering tasks in the AO, be it construction or demolition. Equipped with a standard rifleman's loadout supplemented with various tools to carry out his tasks."
                    },

                    new CombatRole
                    {
                        Id = 8,
                        Name = "Sniper",
                        Description = "Marksman who engages targets from positions of concealment, usually from out of the direct vincinity of his squadmates. Equipped with a long-range high-precision rifle with high-magnification optics."
                    }
                });

            modelBuilder.Entity<User>().HasData(
                new[]
                {
                    new User
                    {
                        Id = 1,
                        Username = "PriAdmin",
                        Email = "admin@pri.be",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "Admin",
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = 2,
                        Username = "PriUser",
                        Email = "user@pri.be",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "User",
                        HasAcceptedTermsAndConditions = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = 3,
                        Username = "PriRefuser",
                        Email = "Refuser@pri.be",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "User",
                        HasAcceptedTermsAndConditions = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = 4,
                        Username = "HOX",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = 5,
                        Username = "ChristianVoo",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                    },

                    new User
                    {
                        Id = 6,
                        Username = "HollowPointsz",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = 7,
                        Username = "IMrByBy3",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },

                    new User
                    {
                        Id = 8,
                        Username = "Brangers",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = 9,
                        Username = "PetrolHeadG98",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = 10,
                        Username = "Kwatman",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },

                    new User
                    {
                        Id = 11,
                        Username = "Tokoshi",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },

                    new User
                    {
                        Id = 12,
                        Username = "Aidan",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = 13,
                        Username = "Tiski",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    }
                });

            modelBuilder.Entity<Operation>().HasData(
                new[]
                {
                    new Operation
                    {
                        Id = 1,
                        CodeName = "Blackout",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 04, 1, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 2,
                        CodeName = "Homesick",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 04, 8, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 3,
                        CodeName = "Night Spear",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 04, 16, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 4,
                        CodeName = "Dangerous Places",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 04, 24, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 5,
                        CodeName = "Last Flight",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 04, 30, 20, 00, 00),
                    },

                    new Operation
                    {
                        Id = 6,
                        CodeName = "Last Flight Night",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 05, 5, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 7,
                        CodeName = "Half-Life",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 05, 14, 19, 30 ,00),
                    },

                    new Operation
                    {
                        Id = 8,
                        CodeName = "Hellish Politics",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 05, 21, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 9,
                        CodeName = "Knock Knock",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 05, 27, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 10,
                        CodeName = "Nexus",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 1, 20, 00, 00),
                    },

                    new Operation
                    {
                        Id = 11,
                        CodeName = "New Wind",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 8, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 12,
                        CodeName = "Blackjack",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 14, 20, 00, 00),
                    },

                    new Operation
                    {
                        Id = 13,
                        CodeName = "Dragon's Tail",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 20, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 14,
                        CodeName = "Apex Predator",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 24, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 15,
                        CodeName = "Anvil",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 06, 29, 20, 00, 00),
                    },

                    new Operation
                    {
                        Id = 16,
                        CodeName = "White Christmas",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2021, 12, 21, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 17,
                        CodeName = "Knife's Edge",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 01, 3,20, 00, 00),
                    },

                    new Operation
                    {
                        Id = 18,
                        CodeName = "FUBAR",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 01, 14, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 19,
                        CodeName = "Lion's Den",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2022, 01, 20, 19, 30, 00),
                    },

                    new Operation
                    {
                        Id = 20,
                        CodeName = "Vulture",
                        Sitrep = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum commodo ante sit amet semper lacinia. Duis sit amet ante non tellus maximus finibus a non libero. Pellentesque ac tempor tortor, id hendrerit arcu. Duis nec sem urna. Sed at viverra odio. Pellentesque molestie mauris feugiat odio tristique vulputate. Cras sit amet neque elementum, faucibus arcu vel, finibus libero. Nullam non lacus eu dui blandit condimentum. Sed in justo eget magna gravida faucibus efficitur laoreet ligula. Etiam vel tincidunt tortor. Aenean quis sem mattis, dignissim purus ut, consequat lacus.",
                        ZeroHour = new DateTime(2024, 01, 29, 19, 30, 00),
                    },
                });
        }
    }
}