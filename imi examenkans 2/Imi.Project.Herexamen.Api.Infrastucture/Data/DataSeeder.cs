using System;
using Imi.Project.Herexamen.Api.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Imi.Project.Herexamen.Api.Infrastucture.Data
{
    public class DataSeeder
    {
        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Map>().HasData(
                new[]
                {
                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Altis"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Stratis"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Malden"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Tanoa"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Chernarus"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "Isla Duala"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Bystrica"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Sahrani"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Name = "Tembelan"
                    },

                    new Map
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Name = "Vidda"
                    }
                });

            modelBuilder.Entity<CombatRole>().HasData(
                new[]
                {
                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Rifleman",
                        Description = "The spine of the infantry and fist of the squad, the rifleman is equipped with a standard select-fire service rifle to carry out the offensive and defensive orders of their squad leader."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Autorifleman",
                        Description = "Provides overwatch and suppresive fire for his teammates through high firepower. Usually equipped with a belt-fed light machine gun to maximize combat efficiency."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Grenadier",
                        Description = "A rifleman that specialises in the use of grenades and other explosives to provide high-angle fire over deadzones. Equiped with either a rifle or carabine fitted with an 40mm under-barrel grenade launcher"
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Name = "Scout",
                        Description = "An infantryman skilled in precision firepower at longer-than-usual ranges. Usually kitted with a DMR (Designated Marksman Rifle), a long-range version of typical assault rifles. Sometimes carries out reconnaissance tasks within the squad."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Name = "Combat Medic",
                        Description = "A medically trained rifleman who's role is to provide emergency treatment to those wounded on the battlefield, friend or foe. Deployed to the front line within a regular fire team and armed as a regular rifleman, but expected to stay out of direct-fire lines to focus on treating those in need."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Name = "AT Specialist",
                        Description = "Infantryman kitted with various anti-tank equipment to counter the threat of enemy armor. Loadouts usually include a carbine-style primary weapon, an launcher of recoilless rifle with AT-munitions and AT-mines."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Name = "Combat Engineer",
                        Description = "A squadmate that provides engineering tasks in the AO, be it construction or demolition. Equipped with a standard rifleman's loadout supplemented with various tools to carry out his tasks."
                    },

                    new CombatRole
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Name = "Sniper",
                        Description = "Marksman who engages targets from positions of concealment, usually from out of the direct vincinity of his squadmates. Equipped with a long-range high-precision rifle with high-magnification optics."
                    }
                });

            modelBuilder.Entity<User>().HasData(
                new[]
                {
                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Username = "HOX",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Username = "ChristianVoo",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000006")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Username = "HollowPointsz",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                        Username = "IMrByBy3",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000003")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                        Username = "Brangers",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                        Username = "PetrolHeadG98",
                        SquadLeader = true,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                        Username = "Kwatman",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000005")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                        Username = "Tokoshi",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000008")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                        Username = "Aidan",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    },

                    new User
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                        Username = "Tiski",
                        SquadLeader = false,
                        CombatRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001")
                    }
                });
        }
    }
}