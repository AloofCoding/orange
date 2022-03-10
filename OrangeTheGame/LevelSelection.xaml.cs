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

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für LevelSelection.xaml
    /// </summary>
    public partial class LevelSelection : Window
    {
        public LevelSelection()
        {
            InitializeComponent();
        }

        private void btn_Level1_Click(object sender, RoutedEventArgs e)
        {
            //load level 1 window
        }

        private void btn_Level2_Click(object sender, RoutedEventArgs e)
        {           
            Level02 l2 = new Level02();
            l2.Show();
            this.Close();
        }

        private void btn_Level4_Click(object sender, RoutedEventArgs e)
        {
            Level04 l4 = new Level04();
            l4.Show();
            this.Close();
        }

        private void btn_Level6_Click(object sender, RoutedEventArgs e)
        {
            Level06 l6 = new Level06();
            l6.Show();
            this.Close();
        }

        private void btn_Level8_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Generating buttons may take a while. Please be patient.", "No need to spam the button.");
            Level08 l8 = new Level08();
            l8.Show();
            this.Close();
        }
    }
}
