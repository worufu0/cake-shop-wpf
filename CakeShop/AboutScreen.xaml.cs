﻿using System;
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
    public partial class AboutScreen : Window
    {
        public AboutScreen()
        {
            InitializeComponent();
        }

        private void closeUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
