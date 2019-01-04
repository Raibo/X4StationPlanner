using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Prism.Mvvm;
using x4StationPlanner.Enums;

namespace x4StationPlanner
{
    public class Planner : BindableBase
    {
        public readonly ObservableCollection<FactoryGroup> DesiredFactoryGroups = new ObservableCollection<FactoryGroup>();
        
        public Planner()
        {
            _RequiredFactoryGroups = new ReadOnlyObservableCollection<FactoryGroup>(_requiredFactoryGroups);
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

        //TODO DeleteFactoryGroup, EditFactoryGroup

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
    }
}
