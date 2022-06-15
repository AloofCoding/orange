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

        /// <summary>
        /// creating the random order for the buttons,
        /// adding them to a list
        /// and placing the "startbuttons" on the form
        /// </summary>
        public Level08()
        {
            InitializeComponent();

            Random temp_rnd = new Random();

            order_rnd = btn_list.OrderBy(x => temp_rnd.Next()).ToList();

            //MessageBox.Show(string.Join(Environment.NewLine, order_rnd));

            for (int i = 0; i < 25; i++)
            {
                create_button();
                counter++;               
            }

            //if (btn_counter == 90)
            //{
            //    for (int i = 0; i < 20; i++)
            //    {
            //        create_button();
            //        counter++;
            //    }
            //}          
        }

        bool[,] arr_grid = new bool[7, 7];
        //List<Button> clicked = new List<Button>();
        //List<Button> unclicked = new List<Button>();
        List<int> btn_list = Enumerable.Range(1,49).ToList();
        List<int> order_rnd = new List<int>();
        //int rnd_rows = 0;
        //int rnd_cols = 0;
        int btn_x;
        int btn_y;
        int counter = 0;
        int colorcounter = 0;
        int btn_counter = 0;
        int btn_delayed = -1;
        int temp_i = 0;

        Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
        Color color2 = (Color)ColorConverter.ConvertFromString("#CE7300");

        /// <summary>
        /// ensures every button created is the same and has a unique position
        /// adds the click event after the 'startbuttons' buttons are placed
        /// </summary>
        private void create_button()
        {
            SolidColorBrush brush = new SolidColorBrush(color);

            Button btn = new Button();
            TextBlock tblock = new TextBlock();

            //a not working try to assign the created buttons a custom xaml style
            //Style style = (Style)Resources["ButtonStyle"];
            //btn.Style = style;

            btn.MouseEnter += Btn_MouseEnter;
            btn.MouseLeave += Btn_MouseLeave;

            btn.Width = grid_l8.Width/grid_l8.ColumnDefinitions.Count;
            btn.Height = grid_l8.Height/grid_l8.RowDefinitions.Count;
            btn.Background = brush;
            btn.BorderBrush = brush;
            btn.Tag = btn_counter;
            btn.BorderThickness = new Thickness(0, 0, 0, 0);

            tblock.Width = grid_l8.Width / grid_l8.ColumnDefinitions.Count;
            tblock.Height = grid_l8.Height / grid_l8.RowDefinitions.Count;
            tblock.Background = Brushes.Transparent;
            tblock.Tag = btn_counter;

            btn.Content = tblock;

            if (counter == 24)
            {
                btn.Click += btn_Click;

                SolidColorBrush brush2 = new SolidColorBrush(color2);

                btn.Background = brush2;
                btn.BorderBrush = brush2;
                btn.Foreground = brush;
                btn.FontSize = 84;
                btn.Content = "8";

                //MessageBox.Show("Click-Event included.");
            }
            else if (counter > 24)
            {
                btn.Click += btn_Click;
                colorcounter++;
            }

            /*
            rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
            btn.SetValue(Grid.RowProperty, rnd_rows);

            Thread.Sleep(new Random().Next(0,500));

            rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
            btn.SetValue(Grid.ColumnProperty, rnd_cols);

            btn.SetValue(Grid.RowProperty, temp_i);
            btn.SetValue(Grid.ColumnProperty, temp_i);
            */

            //MessageBox.Show(temp_i.ToString());

            if (temp_i<49)
            {
                switch (order_rnd.ElementAt(temp_i))
                {
                    #region 1st row
                    case 1:
                        btn_x = 0;
                        btn_y = 0;
                        break;
                    case 2:
                        btn_x = 1;
                        btn_y = 0;
                        break;
                    case 3:
                        btn_x = 2;
                        btn_y = 0;
                        break;
                    case 4:
                        btn_x = 3;
                        btn_y = 0;
                        break;
                    case 5:
                        btn_x = 4;
                        btn_y = 0;
                        break;
                    case 6:
                        btn_x = 5;
                        btn_y = 0;
                        break;
                    case 7:
                        btn_x = 6;
                        btn_y = 0;
                        break;
                    #endregion
                    #region 2nd row
                    case 8:
                        btn_x = 0;
                        btn_y = 1;
                        break;
                    case 9:
                        btn_x = 1;
                        btn_y = 1;
                        break;
                    case 10:
                        btn_x = 2;
                        btn_y = 1;
                        break;
                    case 11:
                        btn_x = 3;
                        btn_y = 1;
                        break;
                    case 12:
                        btn_x = 4;
                        btn_y = 1;
                        break;
                    case 13:
                        btn_x = 5;
                        btn_y = 1;
                        break;
                    case 14:
                        btn_x = 6;
                        btn_y = 1;
                        break;
                    #endregion
                    #region 3rd row
                    case 15:
                        btn_x = 0;
                        btn_y = 2;
                        break;
                    case 16:
                        btn_x = 1;
                        btn_y = 2;
                        break;
                    case 17:
                        btn_x = 2;
                        btn_y = 2;
                        break;
                    case 18:
                        btn_x = 3;
                        btn_y = 2;
                        break;
                    case 19:
                        btn_x = 4;
                        btn_y = 2;
                        break;
                    case 20:
                        btn_x = 5;
                        btn_y = 2;
                        break;
                    case 21:
                        btn_x = 6;
                        btn_y = 2;
                        break;
                    #endregion
                    #region 4th row
                    case 22:
                        btn_x = 0;
                        btn_y = 3;
                        break;
                    case 23:
                        btn_x = 1;
                        btn_y = 3;
                        break;
                    case 24:
                        btn_x = 2;
                        btn_y = 3;
                        break;
                    case 25:
                        btn_x = 3;
                        btn_y = 3;
                        break;
                    case 26:
                        btn_x = 4;
                        btn_y = 3;
                        break;
                    case 27:
                        btn_x = 5;
                        btn_y = 3;
                        break;
                    case 28:
                        btn_x = 6;
                        btn_y = 3;
                        break;
                    #endregion
                    #region 5th row
                    case 29:
                        btn_x = 0;
                        btn_y = 4;
                        break;
                    case 30:
                        btn_x = 1;
                        btn_y = 4;
                        break;
                    case 31:
                        btn_x = 2;
                        btn_y = 4;
                        break;
                    case 32:
                        btn_x = 3;
                        btn_y = 4;
                        break;
                    case 33:
                        btn_x = 4;
                        btn_y = 4;
                        break;
                    case 34:
                        btn_x = 5;
                        btn_y = 4;
                        break;
                    case 35:
                        btn_x = 6;
                        btn_y = 4;
                        break;
                    #endregion
                    #region 6th row
                    case 36:
                        btn_x = 0;
                        btn_y = 5;
                        break;
                    case 37:
                        btn_x = 1;
                        btn_y = 5;
                        break;
                    case 38:
                        btn_x = 2;
                        btn_y = 5;
                        break;
                    case 39:
                        btn_x = 3;
                        btn_y = 5;
                        break;
                    case 40:
                        btn_x = 4;
                        btn_y = 5;
                        break;
                    case 41:
                        btn_x = 5;
                        btn_y = 5;
                        break;
                    case 42:
                        btn_x = 6;
                        btn_y = 5;
                        break;
                    #endregion
                    #region 7th row
                    case 43:
                        btn_x = 0;
                        btn_y = 6;
                        break;
                    case 44:
                        btn_x = 1;
                        btn_y = 6;
                        break;
                    case 45:
                        btn_x = 2;
                        btn_y = 6;
                        break;
                    case 46:
                        btn_x = 3;
                        btn_y = 6;
                        break;
                    case 47:
                        btn_x = 4;
                        btn_y = 6;
                        break;
                    case 48:
                        btn_x = 5;
                        btn_y = 6;
                        break;
                    case 49:
                        btn_x = 6;
                        btn_y = 6;
                        break;
                    #endregion
                    default:
                        MessageBox.Show("Button outside of switch case");
                        break;
                } 
            }
            else
            {
                //MessageBox.Show("Level cleared!");              
                LevelSelection ls = new LevelSelection();
                ls.Show();
                this.Close();
            }

            btn.SetValue(Grid.RowProperty, btn_x);
            btn.SetValue(Grid.ColumnProperty, btn_y);

            grid_l8.Children.Add(btn);
            btn_counter++;
            btn_delayed++;
            temp_i++;

            //MessageBox.Show("Button should've been placed.");

            #region low performance 1st try
            //do
            //{
            //    if (/*arr_grid[rnd_cols, rnd_rows] == false*/)
            //    {
            //        grid_l8.Children.Add(btn);
            //        //MessageBox.Show(btn_counter.ToString());
            //        btn_counter++;
            //        btn_delayed++;
            //        //arr_grid[rnd_cols, rnd_rows] = true;
            //        return;
            //    }
            //    else
            //    {
            //        //MessageBox.Show("Button couldn't be placed.");

            //        /*
            //        rnd_rows = new Random().Next(0, grid_l8.RowDefinitions.Count());
            //        btn.SetValue(Grid.RowProperty, rnd_rows);

            //        Thread.Sleep(new Random().Next(0, 500));

            //        rnd_cols = new Random().Next(0, grid_l8.ColumnDefinitions.Count());
            //        btn.SetValue(Grid.ColumnProperty, rnd_cols);
            //        */

            //        //MessageBox.Show(rnd_cols.ToString() + ";" + rnd_rows.ToString());
            //    } 
            //} while (true);
            #endregion
        }

        /// <summary>
        /// removes the border effect as soon as the mouse leaves the certain button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (Button b in grid_l8.Children.OfType<Button>())
            {

                b.BorderThickness = new Thickness(0, 0, 0, 0);

                //b.Background = new SolidColorBrush(color); 
            }
        }

        /// <summary>
        /// Adds a border while moving your mouse over a certain button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush2 = new SolidColorBrush(color2);
            //SolidColorBrush brush = new SolidColorBrush(color);

            foreach (Button b in grid_l8.Children.OfType<Button>())
            {
                if (b.IsMouseOver)
                {
                    /*
                    ImageBrush ib = new ImageBrush();
                    BitmapImage bi = new BitmapImage();

                    bi.BeginInit();
                    bi.UriSource = new Uri("file:///C:/Users/andreas.steiner/source/repos/AloofCoding/orange/OrangeTheGame/Resources/frame.png");
                    bi.EndInit();

                    ib.ImageSource = bi;

                    b.Background = ib;
                    */

                    b.BorderThickness = new Thickness(7, 7, 7, 7);
                    b.BorderBrush = new SolidColorBrush(color2);
                }
            }

        }

        /// <summary>
        /// adds another button WITH click event after the start button and further buttons are clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //removes click event from clicked button
            foreach (Button b in grid_l8.Children.OfType<Button>())
            {
                if(b.Tag.Equals(btn_delayed))
                {
                    b.Click -= btn_Click;
                }
            }

            SolidColorBrush brush = new SolidColorBrush(color);

            create_button();

            if (colorcounter >= 1)
            {
                foreach (Button b in grid_l8.Children.OfType<Button>())
                {
                    b.Background = brush;
                    b.Content = "";
                } 
            }
        }
    }
}
