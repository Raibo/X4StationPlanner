using System.Linq;
using System.Collections.Generic;
using x4StationPlanner.Enums;
using x4StationPlanner.Maps;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace x4StationPlanner
{
    public class FactoryGroup : INotifyPropertyChanged
    {
        public FactoryGroup(Item item)
        {
            Item = item;
            try
            {
                ItemType = Map.ItemTypeMap[Item];
            }
            catch(Exception)
            {
                throw new Exception($"Missing item type for item [{item.ToString()}].");
            }
            try
            {
                Recipe = Map.RecipeMap[Item];
            }
            catch(Exception)
            {
                throw new ArgumentException($"Item [{item.ToString()}] can not be produced, perhaps recipe missing or item is mined.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public readonly Item Item;
        public readonly ItemType ItemType;
        public readonly Recipe Recipe;

        public string ItemName => Item.ToString();

        private double itemCount;
        public double ItemCount
        {
            get => itemCount;
            set
            {
                itemCount = value;
                stationCount = value / Recipe.Amount;
                NotifyPropertyChanged(nameof(ItemCount));
                NotifyPropertyChanged(nameof(StationCount));
            }
        }

        private double stationCount;
        public double StationCount
        {
            get => stationCount;
            set
            {
                stationCount = value;
                itemCount = value * Recipe.Amount;
                NotifyPropertyChanged(nameof(ItemCount));
                NotifyPropertyChanged(nameof(StationCount));
            }
        }

        public int StationCountCeil => (int)Math.Ceiling(StationCount);

        public List<FactoryGroup> RequiredStations
        {
            get
            {
                var result = new List<FactoryGroup>();
                result.Add(this);
                foreach (var x in Recipe.Ingredients)
                    if (Map.RecipeMap.TryGetValue(x.Key, out var recipe))
                    {
                        var rs = new FactoryGroup(x.Key) { ItemCount = x.Value * stationCount };
                        result.AddRange(rs.RequiredStations);
                    }

                return SumStations(result);
            }
        }

        public static List<FactoryGroup> SumStations(IEnumerable<FactoryGroup> inp) => 
            inp.GroupBy(x => x.Item)
                    .Select(
                        y => new FactoryGroup(y.Key) { StationCount = y.Sum(z => z.stationCount) }
                    )
                    .ToList();
    }
}
