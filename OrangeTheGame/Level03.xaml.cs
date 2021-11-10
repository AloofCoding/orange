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
        public Level03()
        {
            InitializeComponent();
        }

        private void rect_01_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fillRectangles((Rectangle)sender);
            checkIfFinished();
        }

        //private void rect_02_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    fillRectangles(rect_02);
        //    checkIfFinished();
        //}

        //private void rect_03_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    fillRectangles(rect_03);
        //    checkIfFinished();
        //}

        //private void rect_04_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    fillRectangles(rect_04);
        //    checkIfFinished();
        //}

        //private void rect_05_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    fillRectangles(rect_05);
        //    checkIfFinished();
        //}

        private void fillRectangles(Rectangle rect)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
            SolidColorBrush myBrush = new SolidColorBrush(color);
            rect.Fill = myBrush;
        }

        private void checkIfFinished()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
            SolidColorBrush myBrush = new SolidColorBrush(color);

            if (rect_01.Fill.ToString().Equals(myBrush.ToString()) && rect_02.Fill.ToString().Equals(myBrush.ToString()) && rect_03.Fill.ToString().Equals(myBrush.ToString()) && rect_04.Fill.ToString().Equals(myBrush.ToString()) && rect_05.Fill.ToString().Equals(myBrush.ToString()))
            {
                this.UpdateLayout();
                Thread.Sleep(500);
                //level finished
                MessageBox.Show("Finished lv3");
                this.Close();
            }
        }
    }
}
