using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using x4StationPlanner;
using x4StationPlanner.Maps;

namespace X4StationPlannerWpf
{
    public class MainVM : BindableBase, INotifyPropertyChanged
    {
        public MainVM()
        {
            AddDesiredFactoryGroup = new DelegateCommand<string>((x) =>
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(x))
                        _planner.AddDesiredFactoryGroup(new FactoryGroup(x) { StationCount = 1 });
                }
                catch(Exception)
                {
                }
            });

            RemoveDesiredFactoryGroup = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue)
                    _planner.RemoveDesiredFactoryGroup(i.Value);
            });

            _planner = new Planner();
            
            DesiredFactoryGroups.CollectionChanged += (o, e) =>
            {
                UpdateRequiredFactoryGroupsGui();
                
                if (e.OldItems != null)
                    foreach (INotifyPropertyChanged it in e.OldItems)
                        it.PropertyChanged -= (x, y) => UpdateRequiredFactoryGroupsGui();

                if (e.NewItems != null)
                    foreach (INotifyPropertyChanged it in e.NewItems)
                        it.PropertyChanged += (x, y) => UpdateRequiredFactoryGroupsGui();
            };

            foreach (INotifyPropertyChanged it in ItemFactions)
            {
                it.PropertyChanged += UpdateStationsCount;
                it.PropertyChanged += (x, y) => UpdateRequiredFactoryGroupsGui();
            }
        }

        ~MainVM() => Map.SaveFactionSettings();

        private void UpdateRequiredFactoryGroupsGui()
        {
            RaisePropertyChanged(nameof(RequiredFactoryGroups));
            RaisePropertyChanged(nameof(TotalRawResources));
        }

        private void UpdateStationsCount(object o, PropertyChangedEventArgs e)
        {
            var items = DesiredFactoryGroups.Where(x => x.Item == ((ItemFaction)o).Item).ToList();
            foreach (var it in items)
                it.StationCount = it.ItemCount / it.Recipe.Amount;
        }

        private Planner _planner;

        public ReadOnlyObservableCollection<FactoryGroup> RequiredFactoryGroups => _planner.RequiredFactoryGroups;
        public ObservableCollection<FactoryGroup> DesiredFactoryGroups => _planner.DesiredFactoryGroups;

        public DelegateCommand<string> AddDesiredFactoryGroup { get; }
        public DelegateCommand<int?> RemoveDesiredFactoryGroup { get; }

        public IEnumerable<string> ItemList => Map.RecipeMap.Keys.OrderBy(x => x.ToString());

        public ObservableCollection<ItemFaction> ItemFactions => _planner.ItemFactions;

        public ObservableCollection<ItemQuantity> TotalRawResources => new ObservableCollection<ItemQuantity>(_planner.TotalRawResources);

    }
}
