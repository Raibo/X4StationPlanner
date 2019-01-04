using System.Collections.Generic;
using x4StationPlanner.Enums;

namespace x4StationPlanner.Maps
{
    public static partial class Map
    {
        public static readonly Dictionary<Item, ItemType> ItemTypeMap = new Dictionary<Item, ItemType>
        {
            [Item.Energy_cell] = ItemType.Energy,
            [Item.Antimatter_cell] = ItemType.RefinedResource,
            [Item.Graphene] = ItemType.RefinedResource,
            [Item.Refined_metal] = ItemType.RefinedResource,
            [Item.Silicon_wafer] = ItemType.RefinedResource,
            [Item.Superfluid_coolant] = ItemType.RefinedResource,
            [Item.Water] = ItemType.RefinedResource,
            [Item.Advanced_composite] = ItemType.Intermediate,
            [Item.Engine_part] = ItemType.TechProduct,
            [Item.Hull_part] = ItemType.TechProduct,
            [Item.Microchip] = ItemType.Intermediate,
            [Item.Plasma_conductor] = ItemType.Intermediate,
            [Item.Quantum_tube] = ItemType.Intermediate,
            [Item.Scanning_array] = ItemType.Intermediate,
            [Item.Advanced_electronics] = ItemType.TechProduct,
            [Item.Antimatter_converter] = ItemType.TechProduct,
            [Item.Claytronics] = ItemType.TechProduct,
            [Item.Drone_component] = ItemType.TechProduct,
            [Item.Field_coil] = ItemType.TechProduct,
            [Item.Missile_component] = ItemType.TechProduct,
            [Item.Shield_component] = ItemType.TechProduct,
            [Item.Smart_chip] = ItemType.TechProduct,
            [Item.Turret_component] = ItemType.TechProduct,
            [Item.Weapon_component] = ItemType.TechProduct,
            [Item.Meat] = ItemType.Intermediate,
            [Item.Spice] = ItemType.Intermediate,
            [Item.Wheat] = ItemType.Intermediate,
            [Item.Food_ration] = ItemType.FoodProduct,
            [Item.Medical_supply] = ItemType.Medical,

            [Item.Ore] = ItemType.RawResource,
            [Item.Silicon] = ItemType.RawResource,
            [Item.Ice] = ItemType.RawResource,
            [Item.Hydrogen] = ItemType.RawResource,
            [Item.Helium] = ItemType.RawResource,
            [Item.Methane] = ItemType.RawResource,

            [Item.Sunrise_flowers] = ItemType.Intermediate,
            [Item.Maja_snails] = ItemType.Intermediate,
            [Item.Swamp_plant] = ItemType.Intermediate,
            [Item.Soja_beans] = ItemType.Intermediate,

            [Item.Spacefuel] = ItemType.FoodProduct,
            [Item.Nostrop_oil] = ItemType.FoodProduct,
            [Item.Maja_dust] = ItemType.FoodProduct,
            [Item.Spaceweed] = ItemType.FoodProduct,
            [Item.Soja_husk] = ItemType.FoodProduct,
        };


    }
}
