using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using x4StationPlanner;

namespace X4StationPlannerWpf
{
    /// <summary>
    /// Interaction logic for Factions.xaml
    /// </summary>
    public partial class Factions : Window
    {
        public Factions()
        {
            InitializeComponent();
            Closing += Factions_Closing;
        }

        public bool timeToClose = false;

        private void Factions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!timeToClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void WorkForceCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            ((MainVM)DataContext).CheckAllWorkforce(true);
            // only two in a row work
            FactionsGrid.CancelEdit();
            FactionsGrid.CancelEdit();
            CollectionViewSource.GetDefaultView(FactionsGrid.ItemsSource).Refresh();
        }

        private void WorkForceCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            ((MainVM)DataContext).CheckAllWorkforce(false);
            // only two in a row work
            FactionsGrid.CancelEdit();
            FactionsGrid.CancelEdit();
            CollectionViewSource.GetDefaultView(FactionsGrid.ItemsSource).Refresh();
        }
    }
}
