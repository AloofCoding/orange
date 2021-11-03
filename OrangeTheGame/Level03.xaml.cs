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

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level03.xaml
    /// </summary>
    public partial class Level03 : Window
    {
        public Level03()
        {
            InitializeComponent();
        }

        private void rect_01_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_01);
        }


        private void rect_02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_02);

        }

        private void rect_03_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_03);

        }

        private void rect_04_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_04);

        }

        private void rect_05_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_05);

        }

        private void rect_06_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles(rect_06);

        }
        private void fillRectangles(Rectangle rect)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
            SolidColorBrush myBrush = new SolidColorBrush(color);
            rect.Fill = myBrush;
        }
    }
}
