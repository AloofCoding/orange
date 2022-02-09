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

        bool[,] arr_grid = new bool[10, 10];
        int rnd_rows = 0;
        int rnd_cols = 0;

        private void create_button()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#CE7300");
            SolidColorBrush brush = new SolidColorBrush(color);

            Button btn = new Button();

            btn.Width = grid_l8.Width/10;
            btn.Height = grid_l8.Height/10;
            btn.Background = brush;

            btn.Click += btn_Click;

            rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
            btn.SetValue(Grid.RowProperty, rnd_rows);

            Thread.Sleep(new Random().Next(0,500));

            rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
            btn.SetValue(Grid.ColumnProperty, rnd_cols);

            do
            {
                if (arr_grid[rnd_cols, rnd_rows] == false)
                {
                    grid_l8.Children.Add(btn);
                    arr_grid[rnd_cols, rnd_rows] = true;
                    return;
                }
                else
                {
                    //MessageBox.Show("Button couldn't be placed.");

                    rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
                    btn.SetValue(Grid.RowProperty, rnd_rows);

                    Thread.Sleep(new Random().Next(0, 500));

                    rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
                    btn.SetValue(Grid.ColumnProperty, rnd_cols);

                    //MessageBox.Show(rnd_cols.ToString() + ";" + rnd_rows.ToString());
                } 
            } while (true);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            create_button();
        }
    }
}
