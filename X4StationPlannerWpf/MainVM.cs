using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
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

            foreach (INotifyPropertyChanged it in ItemsSettings)
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
            var items = DesiredFactoryGroups.Where(x => x.Item == ((ItemSettings)o).Item).ToList();
            foreach (var it in items)
                it.StationCount = it.ItemCount / it.Amount;
        }

        private Planner _planner;

        public ReadOnlyObservableCollection<FactoryGroup> RequiredFactoryGroups => _planner.RequiredFactoryGroups;
        public ObservableCollection<FactoryGroup> DesiredFactoryGroups => _planner.DesiredFactoryGroups;

        public DelegateCommand<string> AddDesiredFactoryGroup { get; }
        public DelegateCommand<int?> RemoveDesiredFactoryGroup { get; }

        public IEnumerable<string> ItemList => Map.RecipeMap.Keys.OrderBy(x => x.ToString());

        public ObservableCollection<ItemSettings> ItemsSettings => _planner.ItemsSettings;

        public ObservableCollection<ItemQuantity> TotalRawResources => new ObservableCollection<ItemQuantity>(_planner.TotalRawResources);

        public void CheckAllWorkforce(bool val)
        {
            foreach (var it in Map.ItemWorkforceMap.Keys.ToList())
                Map.ItemWorkforceMap[it] = val;
            // TODO: Make propertyChanged of items (somehow)
            foreach (var it in DesiredFactoryGroups)
                it.StationCount = it.StationCount;
            RaisePropertyChanged(nameof(RequiredFactoryGroups));
        }
    }
}
