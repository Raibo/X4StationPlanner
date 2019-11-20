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

        public MainWindow()
        {
            InitializeComponent();
            dataContext = (MainVM)DataContext;
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
    }
}
