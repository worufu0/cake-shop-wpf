using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class CreatingBillScreen : Window
    {
        public CreatingBillScreen()
        {
            InitializeComponent();
        }
        private void creatinggBiilScreen_Loaded(object sender, RoutedEventArgs e)
        {
            dateBlock.Text += $" {DateTime.Now.ToShortDateString()}";
            cakeBox1.ItemsSource = Global.data.cakes;
            cakeBox2.ItemsSource = Global.data.cakes;
            cakeBox3.ItemsSource = Global.data.cakes;
            cakeBox4.ItemsSource = Global.data.cakes;
            cakeBox5.ItemsSource = Global.data.cakes;
        }

        private void closeUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int total = 0;

            if (cakeBox1.SelectedIndex != -1 && quantityBox1.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox1.SelectedIndex].price * int.Parse(quantityBox1.Text);
            }

            if (cakeBox2.SelectedIndex != -1 && quantityBox2.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox2.SelectedIndex].price * int.Parse(quantityBox2.Text);
            }

            if (cakeBox3.SelectedIndex != -1 && quantityBox3.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox3.SelectedIndex].price * int.Parse(quantityBox3.Text);
            }

            if (cakeBox4.SelectedIndex != -1 && quantityBox4.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox4.SelectedIndex].price * int.Parse(quantityBox4.Text);
            }

            if (cakeBox5.SelectedIndex != -1 && quantityBox5.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox5.SelectedIndex].price * int.Parse(quantityBox5.Text);
            }

            totalBlock.Text = $"Tổng tiền: {total.ToString()}";
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int total = 0;

            if (cakeBox1.SelectedIndex != -1 && quantityBox1.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox1.SelectedIndex].price * int.Parse(quantityBox1.Text);
            }

            if (cakeBox2.SelectedIndex != -1 && quantityBox2.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox2.SelectedIndex].price * int.Parse(quantityBox2.Text);
            }

            if (cakeBox3.SelectedIndex != -1 && quantityBox3.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox3.SelectedIndex].price * int.Parse(quantityBox3.Text);
            }

            if (cakeBox4.SelectedIndex != -1 && quantityBox4.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox4.SelectedIndex].price * int.Parse(quantityBox4.Text);
            }

            if (cakeBox5.SelectedIndex != -1 && quantityBox5.Text != string.Empty)
            {
                total += Global.data.cakes[cakeBox5.SelectedIndex].price * int.Parse(quantityBox5.Text);
            }

            totalBlock.Text = $"Tổng tiền: {total.ToString()}";
        }
    }
}
