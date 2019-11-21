using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace x4StationPlanner.Maps
{
    public static partial class Map
    {
        const string RecipeMapPath = @"Maps\RecipeMap.json";
        const string ItemTypeMapPath = @"Maps\ItemTypeMap.json";
        const string ItemTypeSortMapPath = @"Maps\ItemTypeSortMap.json";

        public static readonly Dictionary<string, Recipe> RecipeMap;
        public static readonly Dictionary<string, string> ItemTypeMap;
        public static readonly Dictionary<string, int> ItemTypeSortMap;

        static Map()
        {
            RecipeMap = JsonConvert.DeserializeObject<Dictionary<string, Recipe>>(File.ReadAllText(RecipeMapPath));
            ItemTypeMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(ItemTypeMapPath));
            ItemTypeSortMap = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(ItemTypeSortMapPath));
        }
    }
}
