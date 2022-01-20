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

            int rnd_rows = 0;
            int rnd_cols = 0;

            Button btn = new Button();

            btn.Width = 50;
            btn.Height = 50;
            btn.Background = brush;

            btn.Click += btn_Click;

            rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
            btn.SetValue(Grid.RowProperty, rnd_rows);

            Thread.Sleep(new Random().Next(0,1000));

            rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
            btn.SetValue(Grid.ColumnProperty, rnd_cols);

            bool[,] arr_grid = new bool[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    arr_grid.SetValue(false, i, i2);
                }
            }

            //MessageBox.Show(btn.GetValue(Grid.RowProperty).ToString());
            //MessageBox.Show(btn.GetValue(Grid.ColumnProperty).ToString());

            do
            {
                if (arr_grid[rnd_cols, rnd_rows] == false)
                {
                    grid_l8.Children.Add(btn);
                    arr_grid[rnd_cols, rnd_rows] = true;
                }
                else
                {
                    rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
                    btn.SetValue(Grid.RowProperty, rnd_rows);

                    Thread.Sleep(new Random().Next(0, 1000));

                    rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
                    btn.SetValue(Grid.ColumnProperty, rnd_cols);
                } 
            } while (arr_grid[rnd_cols, rnd_rows] == true);

            object table_x = btn.GetValue(Grid.ColumnProperty);
            object table_y = btn.GetValue(Grid.RowProperty);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            create_button();
        }
    }
}
