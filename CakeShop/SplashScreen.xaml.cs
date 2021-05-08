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
using System.Windows.Threading;

namespace CakeShop
{
    public partial class SplashScreen : Window
    {
        public List<string> tips { get; set; }
        public string tip { get; set; }

        public bool disabledSplash { get; set; }

        public DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();
            tips = Global.data.tips;
            disabledSplash = Global.data.parameterSettings.splashScreenDisabled;
        }

        private void splashScreen_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataContext = this;
                tip = getTip();
                dispatcherTimer.Interval = TimeSpan.FromSeconds(8);
                dispatcherTimer.Start();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            Global.data.parameterSettings.splashScreenDisabled = disabledSplash;
            this.Close();
        }

        private void skipButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
            Global.data.parameterSettings.splashScreenDisabled = disabledSplash;
            this.Close();
        }

        /// <summary>
        /// Chọn ra thông tin thú vị ngẫu nhiên từ mảng tips.
        /// </summary>
        /// <returns> Thông tin thú vị </returns>
        public string getTip()
        {
            Random rng = new Random();
            string tip = tips[rng.Next(tips.Count())];
            return tip;
        }
    }
}
