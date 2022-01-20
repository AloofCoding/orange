using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für Level06.xaml
    /// </summary>
    public partial class Level06 : Window
    {
        public Level06()
        {
            InitializeComponent();
        }

        int count = 0;

        Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");

        private async void btn_top_Click(object sender, RoutedEventArgs e)
        {
            if (btn_top_blank1.Background == Brushes.Black)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_top_blank1.Background = brush;
                count++;
            }
            else if(btn_top_blank2.Background == Brushes.Black && count == 3)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_top_blank2.Background = brush;
                count++;
            }
            else if (btn_top_blank3.Background == Brushes.Black && count == 4)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_top_blank3.Background = brush;
                count++;
            }
            else if (btn_top_blank4.Background == Brushes.Black && count == 7)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_top_blank4.Background = brush;
                //MessageBox.Show("Level cleared!");

                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                btn_bottom.IsEnabled = false;
                btn_top.IsEnabled = false;

                //Thread.Sleep(1000);;
                Level07 level = new Level07();
                level.Show();
                this.Close();
            }
            else
            {
                btn_top_blank1.Background = Brushes.Black;
                btn_top_blank2.Background = Brushes.Black;
                btn_top_blank3.Background = Brushes.Black;
                btn_top_blank4.Background = Brushes.Black;
                btn_bottom_blank1.Background = Brushes.Black;
                btn_bottom_blank2.Background = Brushes.Black;
                btn_bottom_blank3.Background = Brushes.Black;
                btn_bottom_blank4.Background = Brushes.Black;
                count = 0;
            }
        }

        private void btn_bottom_Click(object sender, RoutedEventArgs e)
        {
            if (btn_bottom_blank1.Background == Brushes.Black && count == 1)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_bottom_blank1.Background = brush;
                count++;
            }
            else if(btn_bottom_blank2.Background == Brushes.Black && count == 2)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_bottom_blank2.Background = brush;
                count++;
            }
            else if (btn_bottom_blank3.Background == Brushes.Black && count == 5)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_bottom_blank3.Background = brush;
                count++;
            }
            else if (btn_bottom_blank4.Background == Brushes.Black && count == 6)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                btn_bottom_blank4.Background = brush;
                count++;
            }
            else
            {
                btn_top_blank1.Background = Brushes.Black;
                btn_top_blank2.Background = Brushes.Black;
                btn_top_blank3.Background = Brushes.Black;
                btn_top_blank4.Background = Brushes.Black;
                btn_bottom_blank1.Background = Brushes.Black;
                btn_bottom_blank2.Background = Brushes.Black;
                btn_bottom_blank3.Background = Brushes.Black;
                btn_bottom_blank4.Background = Brushes.Black;
                count = 0;
            }
        }
    }
}
