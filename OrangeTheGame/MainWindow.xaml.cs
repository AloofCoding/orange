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

        //Music by <a href="/users/lvymusic-24939435/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=12964">lvymusic</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12964">Pixabay</a>

        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            // showing level selection screen
            // playing a sound effect
            lbl_titleOnStartingScreen.Visibility = Visibility.Hidden;
            btn_startGame.Visibility = Visibility.Hidden;
            Level03 level = new Level03();
            this.Close();
            level.Show();
        }
    }
}
