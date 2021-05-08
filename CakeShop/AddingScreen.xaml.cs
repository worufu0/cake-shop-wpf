using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AddingScreen : Window
    {
        public AddingScreen()
        {
            InitializeComponent();
        }

        private void closeUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            openFileDialog.ShowDialog();
            imageBox.Text = openFileDialog.FileName;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Cake cake = new Cake();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string myPath, relativePath;
            string[] pathSplit;

            pathSplit = imageBox.Text.Split('\\');
            relativePath = pathSplit.Last();
            myPath = $"{baseDirectory}\\Data\\Images\\{relativePath}";
            if (File.Exists(imageBox.Text))
            {
                if (!File.Exists(myPath))
                {
                    File.Copy(imageBox.Text, myPath);
                }
            }

            cake.id = searchValidID();
            cake.cakeName = cakeNameBox.Text;
            cake.type = typeBox.SelectedIndex + 1;
            cake.price = int.Parse(priceBox.Text);
            cake.quantityLeft = int.Parse(quantityBox.Text);
            cake.quantitySold = 0;
            cake.image = relativePath;
            Global.data.cakes.Add(cake);

            this.Close();
        }

        /// <summary>
		/// Tìm ID hợp lệ
		/// </summary>
		/// <returns>ID hợp lệ</returns>
		public int searchValidID()
        {
            int result = 0;

            List<int> ids = new List<int>();
            foreach (Cake cake in Global.data.cakes)
            {
                ids.Add(cake.id);
            }

            for (int i = 13; i < int.MaxValue; i++)
            {
                if (!ids.Contains(i))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
