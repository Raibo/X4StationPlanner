using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace x4StationPlanner
{
    public class ItemFaction: INotifyPropertyChanged
    {
        private const string ImagesPath = "Images";
        public string Item { get; set; }
        private string faction;
        public string Faction { 
            get => faction;
            set 
            {
                NotifyPropertyChanged();
                NotifyPropertyChanged("RequiredFactoryGroups");
                NotifyPropertyChanged(nameof(ImagePath));
                faction = value;
            } 
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public string ImagePath => $"{ImagesPath}\\Faction_{Faction}.jpg";

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> Options { get; set; }
    }
}
