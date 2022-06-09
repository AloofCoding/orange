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
        public Level05()
        {
            InitializeComponent();
        }

        private int rectToFill = 0;

        /// <summary>
        /// Fills rectangle based on value determined by the right button
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
        /// when the right button is clicked, the rectangle which will be filled (when clicking on left button) is one more to the right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ell_btn_right_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rectToFill += 1;
        }

        /// <summary>
        /// checks if every rectangle is filled orange, then progresses to next level
        /// </summary>
        /// <param name="myBrush"></param>
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

                Level07 level = new Level07();
                level.Show();
                this.Close();
            }
        }
    }
}
