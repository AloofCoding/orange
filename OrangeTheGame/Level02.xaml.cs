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
using System.Threading;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level02.xaml
    /// </summary>
    public partial class Level02 : Window
    {
        public Level02()
        {
            InitializeComponent();
        }

        public string hexstring;

        private async void iup_hex2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //ensures the code is only executed when the integer up down controls exist on the form
            if(!(iup_hex1 == null) && !(iup_hex2 == null))
            {
                hexstring = "#FF" + iup_hex1.Value.ToString() + "F" + iup_hex2.Value.ToString() + "2";
                Color color = (Color)ColorConverter.ConvertFromString(hexstring);
                SolidColorBrush myBrush = new SolidColorBrush(color);
                this.Background = myBrush;
                
                //checks if the users values + the pre written letters match the correct string
                if (hexstring.Equals("#FF8F02") && hexstring != null)
                {
                    //MessageBox.Show("Level cleared! Our colour code is #FF8F02!");

                    iup_hex1.IsEnabled = false;
                    iup_hex2.IsEnabled = false;

                    await Task.Run(() =>
                    {
                        Thread.Sleep(1000);
                    });

                    //Thread.Sleep(1000);
                    Level03 level = new Level03();
                    level.Show();
                    this.Close();
                }
            }          
        }
    }
}
