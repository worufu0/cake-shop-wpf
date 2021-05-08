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

namespace CakeShop
{
    public partial class HomeUserControl : UserControl
    {
        public HomeUserControl()
        {
            InitializeComponent();
        }

        private void homeUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataListView.ItemsSource = Global.data.cakes;
        }

        private void filterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterBox.SelectedIndex == 0 || filterBox.SelectedIndex == -1)
            {
                dataListView.ItemsSource = Global.data.cakes;
            }

            else if (filterBox.SelectedIndex == 1)
            {
                dataListView.ItemsSource = Global.data.cakes.Where(cake => cake.type == 1);
            }

            else if (filterBox.SelectedIndex == 2)
            {
                dataListView.ItemsSource = Global.data.cakes.Where(cake => cake.type == 2);
            }

            else if (filterBox.SelectedIndex == 3)
            {
                dataListView.ItemsSource = Global.data.cakes.Where(cake => cake.type == 3);
            }

            else if (filterBox.SelectedIndex == 4)
            {
                dataListView.ItemsSource = Global.data.cakes.Where(cake => cake.type == 4);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddingScreen addingScreen = new AddingScreen();
            addingScreen.Owner = Window.GetWindow(this);
            addingScreen.ShowDialog();
            filterBox.SelectedIndex = -1;
        }
    }
}
