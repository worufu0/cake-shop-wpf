using LiveCharts;
using LiveCharts.Wpf;
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
    public partial class RevenuingUserControl : UserControl
    {
        public RevenuingUserControl()
        {
            InitializeComponent();
        }

        private void addingUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            createChart();
        }

        /// <summary>
		/// Tạo ra các biểu đồ
		/// </summary>
		private void createChart()
        {
            foreach (Revenue revenue in Global.data.cakeTypeRevenue)
            {
                pieChart.Series.Add(new PieSeries { Title = typeIntToString(revenue.criteria), Values = new ChartValues<double> { revenue.revenue } });
            }

            foreach (Revenue revenue in Global.data.monthRevenue)
            {
                cartesianChart.Series.Add(new ColumnSeries { Title = $"Tháng {revenue.criteria}", Values = new ChartValues<double> { revenue.revenue } });
            }
        }

        private void getCakeTypeRevenue()
        {
            for (int i = 1; i <= 4; i++)
            {
                Global.data.cakeTypeRevenue.Add(new Revenue() { criteria = i });
            }

            Revenue temp = new Revenue();
            foreach (Cake cake in Global.data.cakes)
            {
                Global.data.cakeTypeRevenue[cake.type - 1].revenue += cake.price * cake.quantitySold;
            }
        }

        private string typeIntToString(int type)
        {
            if (type == 1)
            {
                return "Bánh ngọt";
            }

            else if(type == 2)
            {
                return "Bánh mặn";
            }

            else if(type == 3)
            {
                return "Bánh đường phố";
            }

            else if (type == 4)
            {
                return "Bánh đặc sản Việt Nam";
            }

            return string.Empty;
        }
    }
}
