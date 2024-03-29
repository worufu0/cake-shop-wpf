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
    public partial class ConfirmationScreen : Window
    {
        public delegate void CommandExecution(int command, int way, int id);
        public event CommandExecution commandExecutionHandler;

        public int saveCommand { get; set; }

        public ConfirmationScreen(int command)
        {
            InitializeComponent();
            saveCommand = command;
        }

        private void confirmationScreen_Loaded(object sender, RoutedEventArgs e)
        {
            if (saveCommand == 0)
            {
                textBlock.Text = "Bạn có chắc thoát ?";
            }
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            commandExecutionHandler?.Invoke(saveCommand, 0, -1);
            this.Close();
        }
    }
}
