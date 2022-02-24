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
using Xceed.Wpf.Toolkit;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level04.xaml
    /// </summary>
    public partial class Level04 : Window
    {
        public Level04()
        {
            InitializeComponent();
        }

        /// <summary>
        /// raising the progress in the progress bar by 1 every time the mouse enters the shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            pBar.Value += 1;

            if(pBar.Value == 100)
            {
                rect_pBar.IsEnabled = false;

                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                Level06 l6 = new Level06();
                l6.Show();
                this.Close();
            }
        }
    }
}
