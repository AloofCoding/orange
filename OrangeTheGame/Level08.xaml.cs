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
    /// Interaktionslogik für Level08.xaml
    /// </summary>
    public partial class Level08 : Window
    {
        public Level08()
        {
            InitializeComponent();

            create_button();
        }

        private void create_button()
        {
            Color color = (Color)ColorConverter.ConvertFromString("#CE7300");
            SolidColorBrush brush = new SolidColorBrush(color);

            Random rnd_x = new Random();
            int x = rnd_x.Next(0, 714);

            Random rnd_y = new Random();
            int y = rnd_y.Next(0, 314);

            Button btn_1 = new Button();
            btn_1.Width = 70;
            btn_1.Height = 70;
            btn_1.BorderThickness = new Thickness(0, 0, 0, 0);
            btn_1.Background = brush;
            btn_1.Margin = new Thickness(x, y, 0, 0);
        }
    }
}
