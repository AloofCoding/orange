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
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level04.xaml
    /// </summary>
    public partial class Level04 : Window
    {
        DispatcherTimer dTimer;

        public Level04()
        {
            InitializeComponent();
            dTimer = new DispatcherTimer();
            dTimer.Interval = TimeSpan.FromSeconds(1);
            dTimer.Tick += DTimer_Tick;
        }

        /// <summary>
        /// setting up the created dispatch timer to remove progress from the progress bar
        /// depending on how long the user needs to make the next click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan.FromSeconds(-1);
            pBar.Value -= 1.5;
        }

        /// <summary>
        /// raising the progress in the progress bar by 10 every time the user clicks the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Rectangle_MouseClick(object sender, MouseEventArgs e)
        {
            dTimer.Start();
            //System.Windows.MessageBox.Show(dTimer.IsEnabled.ToString());

            Random rect_rnd = new Random();
            Random rect_height = new Random();
            int rect_position;
            pBar.Value += 10;

            //if the progress bar reaches the maximum value the user has cleared the level
            if(pBar.Value == 100)
            {
                dTimer.Stop();
                rect_pBar.IsEnabled = false;

                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                Level05 level = new Level05();
                level.Show();
                this.Close();
            }
            //an earlier concept for this level that isn't used anymore
            #region else if out of order
            /*
            else if (pBar.Value == 10)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness (rect_position, 340,1035-rect_position, 0 );
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 20)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 30)
            {

                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 40)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 50)
            {

                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 60)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 70)
            {

                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 80)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            else if (pBar.Value == 90)
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
            */
            #endregion
            else
            {
                rect_pBar.IsEnabled = false;
                await Task.Run(() =>
                {
                    Thread.Sleep(500);
                });
                rect_position = rect_rnd.Next(10, 1035);
                rect_pBar.IsEnabled = true;
                rect_pBar.Margin = new Thickness(rect_position, 340, 1035 - rect_position, 0);
                rect_pBar.Height = rect_height.Next(50, 269);
            }
        }
    }
}
