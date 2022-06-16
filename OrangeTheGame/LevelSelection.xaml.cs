using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaktionslogik für LevelSelection.xaml
    /// opens/starts the level the user chose
    /// </summary>
    public partial class LevelSelection : Window
    {
        public LevelSelection(Sql_handler sql_handler)
        {
            handler = sql_handler;
            handler.Cmd.CommandText = "select progress from login where username = '" + handler.Username + "';";
            SqlDataReader reader = handler.Cmd.ExecuteReader();
            reader.Read();
            handler.Progress = reader.GetInt32(0);

            InitializeComponent();
            switch (handler.Progress)
            {
                case 1:
                    btn_Level1.IsEnabled = true;
                    break;
                case 2:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    break;
                case 3:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    break;
                case 4:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    break;
                case 5:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    btn_Level5.IsEnabled = true;
                    btn_Level5.Content = "5";
                    break;
                case 6:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    btn_Level5.IsEnabled = true;
                    btn_Level5.Content = "5";
                    btn_Level6.IsEnabled = true;
                    btn_Level6.Content = "6";
                    break;
                case 7:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    btn_Level5.IsEnabled = true;
                    btn_Level5.Content = "5";
                    btn_Level6.IsEnabled = true;
                    btn_Level6.Content = "6";
                    btn_Level7.IsEnabled = true;
                    btn_Level7.Content = "7";
                    break;
                case 8:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    btn_Level5.IsEnabled = true;
                    btn_Level5.Content = "5";
                    btn_Level6.IsEnabled = true;
                    btn_Level6.Content = "6";
                    btn_Level7.IsEnabled = true;
                    btn_Level7.Content = "7";
                    btn_Level8.IsEnabled = true;
                    btn_Level8.Content = "8";
                    break;
                case 9:
                    btn_Level1.IsEnabled = true;
                    btn_Level2.IsEnabled = true;
                    btn_Level2.Content = "2";
                    btn_Level3.IsEnabled = true;
                    btn_Level3.Content = "3";
                    btn_Level4.IsEnabled = true;
                    btn_Level4.Content = "4";
                    btn_Level5.IsEnabled = true;
                    btn_Level5.Content = "5";
                    btn_Level6.IsEnabled = true;
                    btn_Level6.Content = "6";
                    btn_Level7.IsEnabled = true;
                    btn_Level7.Content = "7";
                    btn_Level8.IsEnabled = true;
                    btn_Level8.Content = "8";
                    btn_Level9.IsEnabled = true;
                    btn_Level9.Content = "9";
                    break;
            }
        }

        Sql_handler handler;


        //opens the prefered level of the user and closes the level selection
        //every button does literally the same
        private void btn_Level1_Click(object sender, RoutedEventArgs e)
        {
            Level01 level = new Level01(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level2_Click(object sender, RoutedEventArgs e)
        {           
            Level02 level = new Level02(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level3_Click(object sender, RoutedEventArgs e)
        {
            Level03 level = new Level03(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level4_Click(object sender, RoutedEventArgs e)
        {
            Level04 level = new Level04(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level5_Click(object sender, RoutedEventArgs e)
        {
            Level05 level = new Level05(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level6_Click(object sender, RoutedEventArgs e)
        {
            Level06 level = new Level06(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level7_Click(object sender, RoutedEventArgs e)
        {
            Level07 level = new Level07(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }
        private void btn_Level8_Click(object sender, RoutedEventArgs e)
        {
            Level08 level = new Level08(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }

        private void btn_Level9_Click(object sender, RoutedEventArgs e)
        {
            Level09 level = new Level09(handler);
            if (handler.Fullscreen)
            {
                level.WindowState = WindowState.Maximized;
            }
            else
            {
                level.WindowState = WindowState.Normal;
                level.Width = handler.Size_Width;
                level.Height = handler.Size_Height;
            }
            level.Show();
            this.Close();
        }
    }
}
