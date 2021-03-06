﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Mvvm;
using x4StationPlanner.Maps;
using System.Windows.Controls;

namespace x4StationPlanner
{
    public class Planner : BindableBase
    {
        public ObservableCollection<FactoryGroup> DesiredFactoryGroups = new ObservableCollection<FactoryGroup>();

        public Planner()
        {
            _RequiredFactoryGroups = new ReadOnlyObservableCollection<FactoryGroup>(_requiredFactoryGroups);

            foreach (var kvp in Map.ItemFactionMap)
                ItemsSettings.Add(new ItemSettings { Item = kvp.Key, Faction = kvp.Value, Options = Map.RecipeMap[kvp.Key].Keys.ToList() });

            foreach (INotifyPropertyChanged it in ItemsSettings)
                it.PropertyChanged += UpdateItemFactionSetting;
        }

        public void AddDesiredFactoryGroup(FactoryGroup factoryGroup)
        {
            DesiredFactoryGroups.Add(factoryGroup);
            var items = FactoryGroup.SumStations(DesiredFactoryGroups);
            DesiredFactoryGroups.Clear();
            DesiredFactoryGroups.AddRange(items);
            RaisePropertyChanged(nameof(RequiredFactoryGroups));
        }

        public void RemoveDesiredFactoryGroup(int pos)
        {
            if (pos >= 0 && pos < DesiredFactoryGroups.Count)
                DesiredFactoryGroups.RemoveAt(pos);
            RaisePropertyChanged(nameof(RequiredFactoryGroups));
        }

        private ObservableCollection<FactoryGroup> _requiredFactoryGroups = new ObservableCollection<FactoryGroup>();

        private ReadOnlyObservableCollection<FactoryGroup> _RequiredFactoryGroups;
        public ReadOnlyObservableCollection<FactoryGroup> RequiredFactoryGroups
        {
            get
            {

                var items = FactoryGroup.SumStations(DesiredFactoryGroups.SelectMany(x => x.RequiredStations));

                _requiredFactoryGroups.Clear();
                _requiredFactoryGroups.AddRange(items);
                return _RequiredFactoryGroups;
            }
        }

        public ObservableCollection<ItemSettings> ItemsSettings = new ObservableCollection<ItemSettings>();

        public void UpdateItemFactionSetting(object o, PropertyChangedEventArgs e)
        {
            var ItemFaction = (ItemSettings)o;
            Map.ItemFactionMap[ItemFaction.Item] = ItemFaction.Faction;
        }

        public int WorkersCount => _requiredFactoryGroups.Sum(x => x.Workers);

        public IEnumerable<ItemQuantity> TotalRawResources
        {
            get
            {
                var rez = new Dictionary<string, double>();
                var requiredFactoryGroupsWithWorkforce = _requiredFactoryGroups.ToList();
                var workersCount = WorkersCount;
                if (workersCount > 0)
                    requiredFactoryGroupsWithWorkforce.Add(new FactoryGroup(Map.WorkforceRecipeName) { ItemCount = workersCount });

                foreach (var it in requiredFactoryGroupsWithWorkforce)
                    foreach (var it2 in it.RawResources)
                        if (rez.ContainsKey(it2.Key)) rez[it2.Key] += it2.Value * it.StationCount; 
                        else rez[it2.Key] = it2.Value * it.StationCount;

                return rez.AsEnumerable().Select(x => new ItemQuantity(x.Key, x.Value));
            }
        }
    }
}
