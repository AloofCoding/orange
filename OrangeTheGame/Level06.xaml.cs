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
        public Level06(Sql_handler sql_handler)
        {
            handler = sql_handler;
            InitializeComponent();
            //MessageBox.Show(order.ToString());
        }

        Sql_handler handler;

        int count = 0;

        Color color = (Color)ColorConverter.ConvertFromString("#FF8F02");
        Color color2 = (Color)ColorConverter.ConvertFromString("#CE7300");

        int order = new Random().Next(0, 2);

        /// <summary>
        /// ensuring that the buttons change their color according to the right order
        /// resetting the buttons in case the buttons are clicked in the wrong order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_top_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush l_orange = new SolidColorBrush(color);
            SolidColorBrush d_orange = new SolidColorBrush(color2);

            #region 1st improvement
            /*
            if (btn_top_blank1.Background == Brushes.Black)
            {
                btn_top_blank1.Background = l_orange;
                count++;
            }
            else if(count == 3)
            {
                btn_top_blank2.Background = l_orange;
                count++;
            }
            else if (count == 4)
            {
                btn_top_blank3.Background = l_orange;
                count++;
            }
            else if (count == 7)
            {
                btn_top_blank4.Background = l_orange;
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
                foreach (Button b in main_grid.Children)
                {
                    b.Background = Brushes.Black;
                }

                btn_top.Background = d_orange;
                btn_bottom.Background = d_orange;
                
                count = 0;
            }
            */
            #endregion

            #region 2nd improvement
            if (order == 1)
            {
                switch (count)
                {
                    case 0:
                        btn_top_blank1.Background = l_orange;
                        count++;
                        break;
                    case 3:
                        btn_top_blank2.Background = l_orange;
                        count++;
                        break;
                    case 4:
                        btn_top_blank3.Background = l_orange;
                        count++;
                        break;
                    case 7:
                        btn_top_blank4.Background = l_orange;
                        count++;
                        await Task.Run(() =>
                        {
                            Thread.Sleep(1000);
                            //MessageBox.Show("Loading next level.", "Please be patient.", MessageBoxButton.OK);
                        });

                        btn_bottom.IsEnabled = false;
                        btn_top.IsEnabled = false;

                        handler.Progress = 7;

                        Level07 level = new Level07(handler);
                        level.Show();
                        this.Close();
                        break;
                    default:
                        foreach (Button b in main_grid.Children.OfType<Button>())
                        {
                            b.Background = Brushes.Black;
                        }

                        btn_top.Background = d_orange;
                        btn_bottom.Background = d_orange;

                        count = 0;
                        break;
                } 
            }
            else
            {
                switch (count)
                {
                    case 1:
                        btn_top_blank1.Background = l_orange;
                        count++;
                        break;
                    case 2:
                        btn_top_blank2.Background = l_orange;
                        count++;
                        break;
                    case 5:
                        btn_top_blank3.Background = l_orange;
                        count++;
                        break;
                    case 6:
                        btn_top_blank4.Background = l_orange;
                        count++;
                        break;
                    default:
                        foreach (Button b in main_grid.Children.OfType<Button>())
                        {
                            b.Background = Brushes.Black;
                        }

                        btn_top.Background = d_orange;
                        btn_bottom.Background = d_orange;

                        count = 0;
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// ensuring the buttons only change their color when clicked in the right order
        /// resetting the buttons in case the buttons are clicked in the wrong order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_bottom_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush l_orange = new SolidColorBrush(color);
            SolidColorBrush d_orange = new SolidColorBrush(color2);

            #region 1st improvement
            /*
            if (count == 1)
            {
                btn_bottom_blank1.Background = l_orange;
                count++;
            }
            else if(count == 2)
            {
                btn_bottom_blank2.Background = l_orange;
                count++;
            }
            else if (count == 5)
            {
                btn_bottom_blank3.Background = l_orange;
                count++;
            }
            else if (count == 6)
            {
                btn_bottom_blank4.Background = l_orange;
                count++;
            }
            else
            {
                foreach (Button b in main_grid.Children)
                {
                    b.Background = Brushes.Black;
                }

                btn_top.Background = d_orange;
                btn_bottom.Background = d_orange;

                count = 0;
            }
            */
            #endregion

            //determines which order the user has to solve
            //works with a switch-case for better performance than 1st improvement
            #region 2nd improvement
            if (order == 1)
            {
                switch (count)
                {
                    case 1:
                        btn_bottom_blank1.Background = l_orange;
                        count++;
                        break;
                    case 2:
                        btn_bottom_blank2.Background = l_orange;
                        count++;
                        break;
                    case 5:
                        btn_bottom_blank3.Background = l_orange;
                        count++;
                        break;
                    case 6:
                        btn_bottom_blank4.Background = l_orange;
                        count++;
                        break;
                    default:
                        foreach (Button b in main_grid.Children.OfType<Button>())
                        {
                            b.Background = Brushes.Black;
                        }

                        btn_top.Background = d_orange;
                        btn_bottom.Background = d_orange;

                        count = 0;
                        break;
                } 
            }
            else
            {
                switch (count)
                {
                    case 0:
                        btn_bottom_blank1.Background = l_orange;
                        count++;
                        break;
                    case 3:
                        btn_bottom_blank2.Background = l_orange;
                        count++;
                        break;
                    case 4:
                        btn_bottom_blank3.Background = l_orange;
                        count++;
                        break;
                    case 7:
                        btn_bottom_blank4.Background = l_orange;
                        count++;
                        await Task.Run(() =>
                        {
                            Thread.Sleep(1000);
                            //MessageBox.Show("Loading next level.", "Please be patient.", MessageBoxButton.OK);
                        });

                        btn_bottom.IsEnabled = false;
                        btn_top.IsEnabled = false;

                        handler.Progress = 7;

                        Level07 level = new Level07(handler);
                        level.Show();
                        this.Close();
                        break;
                    default:
                        foreach (Button b in main_grid.Children.OfType<Button>())
                        {
                            b.Background = Brushes.Black;
                        }

                        btn_top.Background = d_orange;
                        btn_bottom.Background = d_orange;

                        count = 0;
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// saving the users progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            handler.Cmd.Connection = handler.Con;
            handler.Cmd.CommandText = "update login set progress = " + handler.Progress + " where username = '" + handler.Username + "';";
            handler.Cmd.ExecuteNonQuery();
        }
    }
}
