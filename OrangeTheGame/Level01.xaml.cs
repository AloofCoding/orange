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
    /// Interaktionslogik für Level01.xaml
    /// </summary>
    public partial class Level01 : Window
    {
        public Level01()
        {
            InitializeComponent();
        }

        /// <summary>
        /// with every step towards max 255, the screen becomes more orange-ish
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_lv1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush magicBrush = (SolidColorBrush)this.Resources["magicBrush"];
            byte green = 0;
            byte blue = 0;
            double calculation;

            if (slider_lv1 != null)
            {
                if (slider_lv1.Value >= 1)
                {
                    calculation = 143 * (slider_lv1.Value / 255);
                    green = (byte)Math.Round(calculation, 0);
                    calculation = 2 * (slider_lv1.Value / 255);
                    blue = (byte)Math.Round(calculation, 0);
                }
                magicBrush.Color = Color.FromRgb((byte)slider_lv1.Value, green, blue);
                this.Background = magicBrush;
            }
        }

        /// <summary>
        /// Method for registering the mouse leaving the slider, checking if the level is completed (slider is on 255/255)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_lv1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (slider_lv1.Value == 255)
            {
                //level completed!
                UpdateLayout();
                Thread.Sleep(1000);
                
                Level02 level = new Level02();
                level.Show();
                this.Close();
            }
        }
    }
}
