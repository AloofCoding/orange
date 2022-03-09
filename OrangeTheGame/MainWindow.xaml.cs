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
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Thread music;

        public MainWindow()
        {
            InitializeComponent();
            playMusic();
            //music.Start();

            //ToDo: Fix access violation coming up with level 07
        }


        //Music by <a href="/users/lvymusic-24939435/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=12964">lvymusic</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12964">Pixabay</a>

        public delegate void ThreadStart();

        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            Level07 level = new Level07();
            this.Close();
            level.Show();
        }

        private void btn_music_Click(object sender, RoutedEventArgs e)
        {
            if (btn_music.Content.ToString().Equals("Music: On"))
            {
                btn_music.Content = "Music: Off";
                //music.Suspend();
            }
            else
            {
                btn_music.Content = "Music: On";
                //music.Start();
            }
        }

        private async void playMusic()
        {
            await Task.Run(() =>
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();

                //MessageBox.Show("thread music");
                //Todo: making relative
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = System.IO.Path.Combine(projectPath, "Resources\\ambient-easy-house-music-12964.wav");

                player.SoundLocation = filePath; // @"C:\Users\christoph.steiner\source\repos\AloofCoding\orange\OrangeTheGame\Resources\ambient-easy-house-music-12964.wav";
                //player.Stream = Properties.Resources.ambient_easy_house_music_129641;
                player.LoadAsync();
                //player.Stream.Flush();
                //player.Stream.Close();
                //player.Stream.Dispose();
                player.PlayLooping();
            });
        }
    }
}
