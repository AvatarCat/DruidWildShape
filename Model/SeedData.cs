using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DruidShapeshifting.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DruidShapeshiftingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DruidShapeshiftingContext>>()))
            {
                Console.WriteLine("Initializing");
                if (context.Druid.Any())
                {
                    return;
                }
                if (context.Creature.Any())
                {
                    return;
                }

                Console.WriteLine("Initialized");
                context.Druid.AddRange(
                    new Druid
                    {
                        Name = "Nala",
                        Level = 4,
                        Race = "DragonBorn",
                        Creatures = new List<Creature> {}
                    }
                );

                context.Creature.AddRange(
                    new Creature
                    {
                        Name = "Giant Crocodile",
                        Challenge = "5",
                        HitPoints = "85 (9d12 + 27)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Panther",
                        Challenge = "1/4",
                        HitPoints = "13 (3d8)",
                        Armor = 12,
                    }, 
                    new Creature
                    {
                        Name = "Acolyte",
                        Challenge = "1/4",
                        HitPoints = "9 (2d8)",
                        Armor = 10,
                    }, 
                    new Creature
                    {
                        Name = "Scorpion",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Black Bear",
                        Challenge = "1/2",
                        HitPoints = "19 (3d8 + 6)",
                        Armor = 11,
                    }, 
                    new Creature
                    {
                        Name = "Crocodile",
                        Challenge = "1/2",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Frog",
                        Challenge = "1/4",
                        HitPoints = "18 (4d8)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Boar",
                        Challenge = "1/4",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 11,
                    }, 
                    new Creature
                    {
                        Name = "Spider",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Deer",
                        Challenge = "0",
                        HitPoints = "4 (1d8)",
                        Armor = 13,
                    }, 
                    new Creature
                    {
                        Name = "Giant Elk",
                        Challenge = "2",
                        HitPoints = "42 (5d12 + 10)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Pseudodragon",
                        Challenge = "1/4",
                        HitPoints = "7 (2d4 + 2)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Lizard",
                        Challenge = "1/4",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Sea Horse",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Cat",
                        Challenge = "0",
                        HitPoints = "2 (1d4)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Fire Beetle",
                        Challenge = "0",
                        HitPoints = "4 (1d6 + 1)",
                        Armor = 13,
                    }, 
                    new Creature
                    {
                        Name = "Constrictor Snake",
                        Challenge = "1/4",
                        HitPoints = "13 (2d10 + 2)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Allosaurus",
                        Challenge = "2",
                        HitPoints = "51 (6d10 + 18)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Goat",
                        Challenge = "1/2",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Dire Wolf",
                        Challenge = "1",
                        HitPoints = "37 (5d10 + 10)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Bat",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Frog",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 11,
                    }, 
                    new Creature
                    {
                        Name = "Vulture",
                        Challenge = "0",
                        HitPoints = "5 (1d8 + 1)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Giant Hyena",
                        Challenge = "1",
                        HitPoints = "45 (6d10 + 12)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Ankylosarus",
                        Challenge = "3",
                        HitPoints = "68 (8d12 + 16)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Zombie",
                        Challenge = "1/4",
                        HitPoints = "22 (3d8 + 9)",
                        Armor = 8,
                    },

                    new Creature
                    {
                        Name = "Giant Eagle",
                        Challenge = "1",
                        HitPoints = "26 (4d10 + 4)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Weasel",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Plesiosaurus",
                        Challenge = "2",
                        HitPoints = "68 (8d12 + 24)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Spider",
                        Challenge = "1",
                        HitPoints = "26 (4d10 + 4)",
                        Armor = 42,
                    },
                    new Creature
                    {
                        Name = "Ape",
                        Challenge = "1/2",
                        HitPoints = "19 (3d8 + 6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Octopus",
                        Challenge = "1",
                        HitPoints = "52 (8d10 + 8)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Hawk",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 13,
                    }, 
                    new Creature
                    {
                        Name = "Pteranodon",
                        Challenge = "1/4",
                        HitPoints = "13 (3d8)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Baboon",
                        Challenge = "0",
                        HitPoints = "3 (1d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Warhorse",
                        Challenge = "1/2",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Triceratops",
                        Challenge = "5",
                        HitPoints = "95 (10d12 + 30)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Rat",
                        Challenge = "1/8",
                        HitPoints = "7 (2d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Badger",
                        Challenge = "0",
                        HitPoints = "3 (1d4 + 1)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Tiger",
                        Challenge = "1",
                        HitPoints = "37 (5d10 + 10)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Poisonous Snake",
                        Challenge = "1/4",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Air Elemental",
                        Challenge = "5",
                        HitPoints = "90 (12d10 + 24)",
                        Armor = 15,
                    },
                    new Creature
                    {
                        Name = "Giant Owl",
                        Challenge = "1/4",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Blood Hawk",
                        Challenge = "1/8",
                        HitPoints = "7 (2d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Imp",
                        Challenge = "1",
                        HitPoints = "10 (3d4 + 3)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Scorpion",
                        Challenge = "3",
                        HitPoints = "52 (7d10 + 14)",
                        Armor = 15,
                    },
                    new Creature
                    {
                        Name = "Lion",
                        Challenge = "1",
                        HitPoints = "26 (4d10 + 4)",
                        Armor = 12,
                    }, 
                    new Creature
                    {
                        Name = "Camel",
                        Challenge = "1/8",
                        HitPoints = "15 (2d10 + 4)",
                        Armor = 9,
                    },
                    new Creature
                    {
                        Name = "Giant Sea Horse",
                        Challenge = "1/2",
                        HitPoints = "16 (3d10)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Skeleton",
                        Challenge = "1/4",
                        HitPoints = "13 (2d8 + 4)",
                        Armor = 12,
                    }, 
                    new Creature
                    {
                        Name = "Crab",
                        Challenge = "0",
                        HitPoints = "2 (1d4)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Giant Shark",
                        Challenge = "5",
                        HitPoints = "126 (11d612 + 55)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Earth Elemental",
                        Challenge = "5",
                        HitPoints = "126 (12d10 + 60)",
                        Armor = 17,
                    },
                    new Creature
                    {
                        Name = "Mastiff",
                        Challenge = "1/8",
                        HitPoints = "5 (1d8 + 1)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Weasel",
                        Challenge = "1/8",
                        HitPoints = "9 (2d8)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Mule",
                        Challenge = "1/8",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Draft Horse",
                        Challenge = "1/4",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Giant Toad",
                        Challenge = "1",
                        HitPoints = "39 (6d10 + 6)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Wolf",
                        Challenge = "1/4",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 13,
                    },

                    new Creature
                    {
                        Name = "Poisonous Snake",
                        Challenge = "1/8",
                        HitPoints = "2 (1d4)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Wasp",
                        Challenge = "1/2",
                        HitPoints = "13 (3d8)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Elk",
                        Challenge = "1/4",
                        HitPoints = "13 (2d10 + 2)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Quasit",
                        Challenge = "1",
                        HitPoints = "7 (3d4)",
                        Armor = 13,
                    }, 
                    new Creature
                    {
                        Name = "Giant Vulture",
                        Challenge = "1",
                        HitPoints = "22 (3d10 + 6)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Fire Elemental",
                        Challenge = "5",
                        HitPoints = "102 (12d10 + 36)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Owl",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Polar Bear",
                        Challenge = "2",
                        HitPoints = "42 (5d10 + 15)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Wolf Spider",
                        Challenge = "1/4",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Eagle",
                        Challenge = "0",
                        HitPoints = "3 (1d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Rat",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Giant Boar",
                        Challenge = "2",
                        HitPoints = "42 (5d10 + 15)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Water Elemental",
                        Challenge = "5",
                        HitPoints = "114 (12d10 + 48)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Hunter Shark",
                        Challenge = "2",
                        HitPoints = "45 (6d10 + 12)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Flying Snake",
                        Challenge = "1/8",
                        HitPoints = "5 (2d4)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Raven",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Hyena",
                        Challenge = "0",
                        HitPoints = "5 (1d8 + 1)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Giant Bat",
                        Challenge = "1/4",
                        HitPoints = "22 (4d10)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Jackal",
                        Challenge = "0",
                        HitPoints = "3 (1d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Reef Shark",
                        Challenge = "1/2",
                        HitPoints = "22 (4d8 + 4)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Elephant",
                        Challenge = "4",
                        HitPoints = "76 (8d12 + 24)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Riding Horse",
                        Challenge = "1/4",
                        HitPoints = "13 (2d10 + 2)",
                        Armor = 10,
                    }, 
                    new Creature
                    {
                        Name = "Killer Whale",
                        Challenge = "3",
                        HitPoints = "90 (12d12 + 12)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Stirge",
                        Challenge = "1/8",
                        HitPoints = "2 (1d4)",
                        Armor = 14,
                    },
                    new Creature
                    {
                        Name = "Pony",
                        Challenge = "1/8",
                        HitPoints = "11 (2d8 + 2)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Giant Crab",
                        Challenge = "1/8",
                        HitPoints = "13 (3d8)",
                        Armor = 15,
                    },
                    new Creature
                    {
                        Name = "Lizard",
                        Challenge = "0",
                        HitPoints = "2 (1d4)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Sprite",
                        Challenge = "1/4",
                        HitPoints = "2 (1d4)",
                        Armor = 15,
                    }, 
                    new Creature
                    {
                        Name = "Goat",
                        Challenge = "0",
                        HitPoints = "4 (1d8)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Quipper",
                        Challenge = "0",
                        HitPoints = "1 (1d4 - 1)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Giant Badger",
                        Challenge = "1/4",
                        HitPoints = "13 (2d10 + 2)",
                        Armor = 10,
                    },
                    new Creature
                    {
                        Name = "Mammoth",
                        Challenge = "6",
                        HitPoints = "126 (11d12 + 55)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Brown Bear",
                        Challenge = "1",
                        HitPoints = "34 (4d10 + 12)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Rhinoceros",
                        Challenge = "2",
                        HitPoints = "45 (6d10 + 12)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Giant Constrictor Snake",
                        Challenge = "2",
                        HitPoints = "60 (8d12 + 8)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Octopus",
                        Challenge = "0",
                        HitPoints = "3 (1d6)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Cave Bear",
                        Challenge = "2",
                        HitPoints = "42 (5d10 + 15)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Centipede",
                        Challenge = "1/4",
                        HitPoints = "4 (1d6 + 1)",
                        Armor = 13,
                    },
                    new Creature
                    {
                        Name = "Axe Beak",
                        Challenge = "1/4",
                        HitPoints = "19 (3d10 + 3)",
                        Armor = 11,
                    },
                    new Creature
                    {
                        Name = "Saber-Toothed Tiger",
                        Challenge = "2",
                        HitPoints = "52 (7d10 + 14)",
                        Armor = 12,
                    },
                    new Creature
                    {
                        Name = "Giant Eagle",
                        Challenge = "1",
                        HitPoints = "26 (4d10 + 4)",
                        Armor = 13,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}