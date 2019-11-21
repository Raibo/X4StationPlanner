using System.Linq;
using System.Collections.Generic;
using x4StationPlanner.Maps;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace x4StationPlanner
{
    public class FactoryGroup : INotifyPropertyChanged
    {
        const string UnknownItemType = "Unknown";
        const string ImagesPath = "Images";
        public FactoryGroup(string item)
        {
            Item = item;
            try
            {
                ItemType = Map.ItemTypeMap[Item];
            }
            catch(Exception)
            {
                ItemType = UnknownItemType;
            }

            try
            {
                Recipe = Map.RecipeMap[Item];
            }
            catch(Exception)
            {
                throw new ArgumentException($"Item [{item}] can not be produced, perhaps recipe missing or item is mined.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public readonly string Item;
        public string ItemType { get; private set; }
        public int SortIndex => Map.ItemTypeSortMap.ContainsKey(ItemType) ? Map.ItemTypeSortMap[ItemType] : 0;
        public readonly Recipe Recipe;

        public string ImagePath => $"{ImagesPath}\\{ItemType}.jpg";
        //public string ImagePath => @"D:\Coding\Games\X4\X4StationPlanner\x4StationPlannerWPF\Images\Energy.jpg";

        public string ItemName => Item;

        private double itemCount;
        public double ItemCount
        {
            get => itemCount;
            set
            {
                itemCount = value;
                stationCount = value / Recipe.Amount;
                UpdateRow();
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
                UpdateRow();
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

        private void UpdateRow()
        {
            NotifyPropertyChanged(nameof(ItemCount));
            NotifyPropertyChanged(nameof(StationCount));
            NotifyPropertyChanged(nameof(StationCountCeil));
        }
    }
}
