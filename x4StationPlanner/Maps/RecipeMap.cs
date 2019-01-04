using System.Collections.Generic;
using x4StationPlanner.Enums;

namespace x4StationPlanner.Maps
{
    public static partial class Map
    {
        public static readonly Dictionary<Item, Recipe> RecipeMap = new Dictionary<Item, Recipe>
        {
            [Item.Energy_cell] = new Recipe
            {
                Amount = 12000,
                Ingredients = new Dictionary<Item, int>
                {

                }
            },

            [Item.Antimatter_cell] = new Recipe
            {
                Amount = 3300,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 3000,
                    [Item.Hydrogen] = 9600,
                }
            },

            [Item.Graphene] = new Recipe
            {
                Amount = 1650,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 1200,
                    [Item.Methane] = 4800,
                }
            },

            [Item.Refined_metal] = new Recipe
            {
                Amount = 2400,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 2160,
                    [Item.Ore] = 5760,
                }
            },

            [Item.Silicon_wafer] = new Recipe
            {
                Amount = 2400,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 1800,
                    [Item.Silicon] = 4800,
                }
            },

            [Item.Superfluid_coolant] = new Recipe
            {
                Amount = 1650,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 900,
                    [Item.Helium] = 4800,
                }
            },

            [Item.Water] = new Recipe
            {
                Amount = 6600,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 1800,
                    [Item.Ice] = 9600,
                }
            },

            [Item.Advanced_composite] = new Recipe
            {
                Amount = 720,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 600,
                    [Item.Graphene] = 960,
                    [Item.Refined_metal] = 960,
                }
            },

            [Item.Engine_part] = new Recipe
            {
                Amount = 480,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 240,
                    [Item.Refined_metal] = 384,
                    [Item.Antimatter_cell] = 320,
                }
            },

            [Item.Hull_part] = new Recipe
            {
                Amount = 880,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 320,
                    [Item.Graphene] = 160,
                    [Item.Refined_metal] = 1120,
                }
            },

            [Item.Microchip] = new Recipe
            {
                Amount = 480,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 300,
                    [Item.Silicon_wafer] = 1200,
                }
            },

            [Item.Plasma_conductor] = new Recipe
            {
                Amount = 200,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 300,
                    [Item.Graphene] = 384,
                    [Item.Superfluid_coolant] = 560,
                }
            },

            [Item.Quantum_tube] = new Recipe
            {
                Amount = 550,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 200,
                    [Item.Graphene] = 580,
                    [Item.Superfluid_coolant] = 150,
                }
            },

            [Item.Scanning_array] = new Recipe
            {
                Amount = 240,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 360,
                    [Item.Refined_metal] = 600,
                    [Item.Silicon_wafer] = 360,
                }
            },

            [Item.Advanced_electronics] = new Recipe
            {
                Amount = 300,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 300,
                    [Item.Microchip] = 220,
                    [Item.Quantum_tube] = 100,
                }
            },

            [Item.Antimatter_converter] = new Recipe
            {
                Amount = 1800,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 960,
                    [Item.Advanced_composite] = 240,
                    [Item.Microchip] = 360,
                }
            },

            [Item.Claytronics] = new Recipe
            {
                Amount = 480,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 560,
                    [Item.Antimatter_cell] = 400,
                    [Item.Microchip] = 640,
                    [Item.Quantum_tube] = 400,
                }
            },

            [Item.Drone_component] = new Recipe
            {
                Amount = 360,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 180,
                    [Item.Engine_part] = 60,
                    [Item.Hull_part] = 60,
                    [Item.Microchip] = 60,
                    [Item.Scanning_array] = 120,
                }
            },

            [Item.Field_coil] = new Recipe
            {
                Amount = 1200,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 360,
                    [Item.Plasma_conductor] = 240,
                    [Item.Quantum_tube] = 258,
                }
            },

            [Item.Missile_component] = new Recipe
            {
                Amount = 1320,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 80,
                    [Item.Advanced_composite] = 8,
                    [Item.Hull_part] = 8,
                }
            },

            [Item.Shield_component] = new Recipe
            {
                Amount = 660,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 210,
                    [Item.Plasma_conductor] = 60,
                    [Item.Quantum_tube] = 60,
                }
            },

            [Item.Smart_chip] = new Recipe
            {
                Amount = 480,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 300,
                    [Item.Silicon_wafer] = 120,
                }
            },

            [Item.Turret_component] = new Recipe
            {
                Amount = 400,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 120,
                    [Item.Microchip] = 40,
                    [Item.Quantum_tube] = 40,
                    [Item.Scanning_array] = 20,
                }
            },

            [Item.Weapon_component] = new Recipe
            {
                Amount = 400,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 120,
                    [Item.Hull_part] = 40,
                    [Item.Plasma_conductor] = 60,
                }
            },

            [Item.Meat] = new Recipe
            {
                Amount = 1760,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 320,
                    [Item.Water] = 800,
                }
            },

            [Item.Spice] = new Recipe
            {
                Amount = 2880,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 240,
                    [Item.Water] = 480,
                }
            },

            [Item.Wheat] = new Recipe
            {
                Amount = 3240,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 360,
                    [Item.Water] = 960,
                }
            },

            [Item.Food_ration] = new Recipe
            {
                Amount = 4920,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 600,
                    [Item.Meat] = 600,
                    [Item.Wheat] = 600,
                    [Item.Spice] = 300,
                }
            },

            [Item.Medical_supply] = new Recipe
            {
                Amount = 1440,
                Ingredients = new Dictionary<Item, int>
                {
                    [Item.Energy_cell] = 480,
                    [Item.Spice] = 360,
                    [Item.Water] = 720,
                    [Item.Wheat] = 264,
                }
            },
        };
    }
}
