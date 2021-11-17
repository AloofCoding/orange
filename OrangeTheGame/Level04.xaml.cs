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

        private async void colorpicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            //System.Windows.MessageBox.Show(colorpicker.SelectedColor.Value.ToString());
            if (colorpicker.SelectedColor.Value.ToString().Equals("#FFFF8F02"))
            {
                System.Windows.MessageBox.Show("'" + colorpicker.SelectedColor.Value.ToString() + "' is the right anwser");
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                Thread.Sleep(500);
                this.Close();
                LevelSelection ls = new LevelSelection();
                ls.ShowDialog();
            }
        }
    }
}
