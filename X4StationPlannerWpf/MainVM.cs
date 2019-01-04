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
using x4StationPlanner.Enums;

namespace X4StationPlannerWpf
{
    public class MainVM : BindableBase, INotifyPropertyChanged
    {
        public MainVM()
        {
            AddDesiredFactoryGroup = new DelegateCommand<Item?>((x) =>
            {
                try
                {
                    if (x.HasValue)
                        _planner.AddDesiredFactoryGroup(new FactoryGroup(x.Value) { StationCount = 1 });
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
        }

        private void UpdateRequiredFactoryGroupsGui() => RaisePropertyChanged(nameof(RequiredFactoryGroups));

        private Planner _planner;

        public ReadOnlyObservableCollection<FactoryGroup> RequiredFactoryGroups => _planner.RequiredFactoryGroups;
        public ObservableCollection<FactoryGroup> DesiredFactoryGroups => _planner.DesiredFactoryGroups;

        public DelegateCommand<Item?> AddDesiredFactoryGroup { get; }
        public DelegateCommand<int?> RemoveDesiredFactoryGroup { get; }

        public IEnumerable<Item> ItemList => ((Item[])Enum.GetValues(typeof(Item))).OrderBy(x => x.ToString());
    }
}
