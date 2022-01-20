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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            // showing level selection screen
            // playing a sound effect
            lbl_titleOnStartingScreen.Visibility = Visibility.Hidden;
            btn_startGame.Visibility = Visibility.Hidden;
            LevelSelection level = new LevelSelection();
            this.Close();
            level.Show();
        }
    }
}
