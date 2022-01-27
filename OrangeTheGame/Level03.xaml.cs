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
        private int amountOfClicks;

        public Level03()
        {
            InitializeComponent();
            amountOfClicks = 0;
        }

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

            if (amountOfClicks == 5)
            {
                //fkue
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                //level finished
                //MessageBox.Show("Finished lv3");

                
                Level05 level = new Level05();
                level.Show();
                this.Close();
            }
        }
    }
}