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

            for (int i = 0; i < 50; i++)
            {
                create_button();
                i++;
                counter++;
            }
        }

        bool[,] arr_grid = new bool[10, 10];
        int rnd_rows = 0;
        int rnd_cols = 0;
        int counter = 0;
        int colorcounter = 0;

        Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");

        /// <summary>
        /// ensures every button created is the same and has a unique position
        /// adds the click event after the 'obstacle' buttons are placed
        /// </summary>
        private void create_button()
        {
            SolidColorBrush brush = new SolidColorBrush(color);

            Button btn = new Button();

            btn.Width = grid_l8.Width/10;
            btn.Height = grid_l8.Height/10;
            btn.Background = brush;
            btn.BorderBrush = brush;

            if (counter == 24)
            {
                btn.Click += btn_Click;

                Color color2 = (Color)ColorConverter.ConvertFromString("#CE7300");
                SolidColorBrush brush2 = new SolidColorBrush(color2);

                btn.Background = brush2;
                btn.BorderBrush = brush2;

                //MessageBox.Show("Click-Event included.");
            }
            else if (counter > 24)
            {
                btn.Click += btn_Click;
            }

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

        /// <summary>
        /// adds another button WITH click event after the start button and further buttons are clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //disable click event \/
            //this.btn_Click(sender, e);

            SolidColorBrush brush = new SolidColorBrush(color);

            create_button();

            if (colorcounter > 1)
            {
                foreach (Button b in grid_l8.Children.OfType<Button>())
                {
                    b.Background = brush;
                } 
            }
            //btn.IsEnabled = false;
        }
    }
}
