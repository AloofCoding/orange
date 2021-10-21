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
    /// Interaktionslogik für Level02.xaml
    /// </summary>
    public partial class Level02 : Window
    {
        public Level02()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_hexcode1.SelectedIndex == 8 && cmb_hexcode2.SelectedIndex == 0)
            {
                MessageBox.Show("Level completed");
            }
        }
    }
}
