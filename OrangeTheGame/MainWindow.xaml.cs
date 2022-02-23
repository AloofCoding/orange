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
            //ToDo: Fix access violation coming up with level 07
            //player.Stream = Properties.Resources.ambient_easy_house_music_129641;
            //player.Load();
            //player.Stream.Flush();
            //player.Stream.Close();
            //player.Stream.Dispose();
            //player.PlayLooping();
        }

        //private System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        //Music by <a href="/users/lvymusic-24939435/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=12964">lvymusic</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12964">Pixabay</a>


        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            Level07 level = new Level07();
            this.Close();
            level.Show();
        }

        private void btn_music_Click(object sender, RoutedEventArgs e)
        {
            //if (btn_music.Content.ToString().Equals("Music: On"))
            //{
            //    btn_music.Content = "Music: Off";
            //    player.Stop();
            //}
            //else
            //{
            //    btn_music.Content = "Music: On";
            //    player.PlayLooping();
            //}
        }
    }
}
