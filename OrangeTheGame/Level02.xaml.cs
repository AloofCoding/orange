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
using Xceed.Wpf.Toolkit;

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

        public string hexstring;

        private void iup_hex1_TouchUp(object sender, KeyEventArgs e)
        {
            hexstring = "#FF" + iup_hex1.Value.ToString() + "F" + iup_hex2.Value.ToString() + "2";
            Color color = (Color)ColorConverter.ConvertFromString(hexstring);
            SolidColorBrush myBrush = new SolidColorBrush(color);
            this.Background = myBrush;
            iup_hex1.Background = myBrush;
            iup_hex2.Background = myBrush;
        }
    }
}
