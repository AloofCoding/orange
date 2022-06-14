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
    /// opens/starts the level the user chose
    /// </summary>
    public partial class LevelSelection : Window
    {
        public LevelSelection()
        {
            InitializeComponent();
        }

        //opens the prefered level of the user and closes the level selection
        //every button does literally the same
        private void btn_Level1_Click(object sender, RoutedEventArgs e)
        {
            Level01 level = new Level01();
            level.Show();
            this.Close();
        }

        private void btn_Level2_Click(object sender, RoutedEventArgs e)
        {           
            Level02 level = new Level02();
            level.Show();
            this.Close();
        }

        private void btn_Level3_Click(object sender, RoutedEventArgs e)
        {
            Level03 level = new Level03();
            level.Show();
            this.Close();
        }

        private void btn_Level4_Click(object sender, RoutedEventArgs e)
        {
            Level04 level = new Level04();
            level.Show();
            this.Close();
        }

        private void btn_Level5_Click(object sender, RoutedEventArgs e)
        {
            Level05 level = new Level05();
            level.Show();
            this.Close();
        }

        private void btn_Level6_Click(object sender, RoutedEventArgs e)
        {
            Level06 level = new Level06();
            level.Show();
            this.Close();
        }

        private void btn_Level7_Click(object sender, RoutedEventArgs e)
        {
            Level07 level = new Level07();
            level.Show();
            this.Close();
        }
        private void btn_Level8_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This level is currently under construction.");

            //Level08 level = new Level08();
            //level.Show();
            //this.Close();
        }

        private void btn_Level9_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This level is currently under construction.");

            //Level09 level = new Level09();
            //level.Show();
            //this.Close();
        }
    }
}
