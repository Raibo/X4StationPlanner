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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace X4StationPlannerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainVM dataContext;
        readonly Factions factionsWindow = new Factions();

        public MainWindow()
        {
            InitializeComponent();
            dataContext = (MainVM)DataContext;
            factionsWindow.DataContext = DataContext;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            factionsWindow.timeToClose = true;
            factionsWindow.Close();
        }


        private void ItemBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dataContext.AddDesiredFactoryGroup.Execute(((ListBox)sender).SelectedItem.ToString());
        }

        private void ItemBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dataContext.AddDesiredFactoryGroup.Execute(((ListBox)sender).SelectedItem.ToString());
                e.Handled = true;
            }
        }

        private void Button_Factions_Click(object sender, RoutedEventArgs e)
        {
            factionsWindow.Show();
        }
    }
}
