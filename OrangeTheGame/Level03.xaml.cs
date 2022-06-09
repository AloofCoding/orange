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
    /// Interaktionslogik für Level03.xaml
    /// </summary>
    public partial class Level03 : Window
    {

        private int amountOfClicks = 0;

        public Level03()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If a rectangle is clicked upon, it changes its color from black to #FF8F02
        /// When all 5 rectangles are covered, the level is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
            SolidColorBrush myBrush = new SolidColorBrush(color);

            if (!rect.Fill.ToString().Equals(color.ToString()))
            {
                rect.Fill = myBrush;

                amountOfClicks++;
            }

            checkIfFinished();
        }

        private async void checkIfFinished()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");

            string myBrush = new SolidColorBrush(color).ToString();

            if (filledRectangles == 5)
            {
                //fkue
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                Level04 level = new Level04();
                level.Show();
                this.Close();
            }
        }
    }
}