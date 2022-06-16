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
using System.Threading;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level05.xaml
    /// </summary>
    public partial class Level05 : Window
    {
        public Level05(Sql_handler sql_handler)
        {
            handler = sql_handler;
            InitializeComponent();
        }

        Sql_handler handler;

        //variable specifying which of the 5 rectangles get turned orange.
        private int rectToFill = 0;

        /// <summary>
        /// The rectangle which's number is stored in rectToFill gets turned orange when the left button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ell_btn_left_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
            SolidColorBrush myBrush = new SolidColorBrush(color);

            switch (rectToFill)
            {
                case 1:
                    rect_01.Fill = myBrush;
                    break;
                case 2:
                    rect_02.Fill = myBrush;
                    break;
                case 3:
                    rect_03.Fill = myBrush;
                    break;
                case 4:
                    rect_04.Fill = myBrush;
                    break;
                case 5:
                    rect_05.Fill = myBrush;
                    break;
                default:
                    break;
            }
            checkIfFinished(myBrush);

            rectToFill = 0;
        }

        /// <summary>
        /// increases rectToFill when the right button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ell_btn_right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rectToFill += 1;
        }


        private async void checkIfFinished(SolidColorBrush myBrush)
        {
            if (rect_01.Fill.ToString().Equals(myBrush.ToString()) &&
                   rect_02.Fill.ToString().Equals(myBrush.ToString()) &&
                   rect_03.Fill.ToString().Equals(myBrush.ToString()) &&
                   rect_04.Fill.ToString().Equals(myBrush.ToString()) &&
                   rect_05.Fill.ToString().Equals(myBrush.ToString()))
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                handler.Progress = 6;

                Level06 level = new Level06(handler);

                level.Show();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            handler.Cmd.Connection = handler.Con;
            handler.Cmd.CommandText = "update login set progress = " + handler.Progress + " where username = '" + handler.Username + "';";
            handler.Cmd.ExecuteNonQuery();
        }
    }
}
