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
    /// Interaktionslogik für Level08.xaml
    /// </summary>
    public partial class Level08 : Window
    {
        public Level08()
        {
            InitializeComponent();

            create_button();
        }

        private void create_button()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#CE7300");
            SolidColorBrush brush = new SolidColorBrush(color);

            Button btn = new Button();

            btn.Width = 50;
            btn.Height = 50;
            btn.Background = brush;

            btn.Click += btn_Click;

            btn.SetValue(Grid.RowProperty, new Random().Next(0, grid_l8.RowDefinitions.Count()));
            Thread.Sleep(new Random().Next(0,1000));
            btn.SetValue(Grid.ColumnProperty, new Random().Next(0, grid_l8.ColumnDefinitions.Count()));

            int[,] arr_grid = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    bool temp = false;
                    arr_grid.SetValue(temp, i, i2);
                }
            }

            //MessageBox.Show(btn.GetValue(Grid.RowProperty).ToString());
            //MessageBox.Show(btn.GetValue(Grid.ColumnProperty).ToString());

            grid_l8.Children.Add(btn);
            object table_x = btn.GetValue(Grid.ColumnProperty);
            object table_y = btn.GetValue(Grid.RowProperty);

            arr_grid.SetValue(true, Int32.Parse(table_x.ToString()), Int32.Parse(table_y.ToString()));
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            create_button();
        }
    }
}
