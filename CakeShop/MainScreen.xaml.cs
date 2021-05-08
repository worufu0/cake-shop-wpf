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

namespace CakeShop
{
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void mainScreen_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void mainScreen_Closed(object sender, EventArgs e)
        {
            Global.data.save(Global.data, "Data/Data.ntp");
        }

        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationScreen confirmationScreen = new ConfirmationScreen(0);
            confirmationScreen.commandExecutionHandler += commandExecution;
            confirmationScreen.Owner = this;
            confirmationScreen.ShowDialog();
        }

        private void minimizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutScreen aboutScreen = new AboutScreen();
            aboutScreen.Owner = this;
            aboutScreen.ShowDialog();
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsScreen settingsScreen = new SettingsScreen();
            settingsScreen.Owner = this;
            settingsScreen.ShowDialog();
        }

        private void menuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuBox.SelectedIndex == 0)
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new HomeUserControl());
            }

            else if (menuBox.SelectedIndex == 1)
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new RevenuingUserControl());
            }

            else if(menuBox.SelectedIndex == 2)
            {
                CreatingBillScreen creatingBillScreen = new CreatingBillScreen();
                creatingBillScreen.Owner = this;
                creatingBillScreen.ShowDialog();
            }
        }

        /// <summary>
        /// Hàm điều hướng lệnh
        /// </summary>
        /// <param name="command"> Mã lệnh </param>
        /// <param name="way"> Hướng </param>
        /// <param name="id"> ID đối tượng (nếu không có đối tượng là -1) </param>
        private void commandExecution(int command, int way, int id)
        {
            if (command == 0)
            {
                if (way == 0)
                {
                    App.Current.Shutdown();
                }
            }
        }
    }
}
