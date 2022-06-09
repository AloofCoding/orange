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
        }


        //Music by <a href="/users/lvymusic-24939435/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=12964">lvymusic</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12964">Pixabay</a>

        public delegate void ThreadStart();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            Level01 level = new Level01();
            this.Close();
            level.Show();
        }

        private void btn_music_Click(object sender, RoutedEventArgs e)
        {
            if (btn_music.Content.ToString().Equals("Music: On"))
            {
                btn_music.Content = "Music: Off";
                player.Stop();
            }
            else
            {
                btn_music.Content = "Music: On";
                player.PlayLooping();
            }
        }

        /// <summary>
        /// async method so the music file is only loaded once and not all the time while playing
        /// </summary>
        private async void playMusic()
        {
            await Task.Run(() =>
            {
                //MessageBox.Show("thread music");
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = System.IO.Path.Combine(projectPath, "Resources\\ambient-easy-house-music-12964.wav");
                player.SoundLocation = filePath;
                //player.Stream = Properties.Resources.ambient_easy_house_music_129641;
                player.LoadAsync();
                //player.Stream.Flush();
                //player.Stream.Close();
                //player.Stream.Dispose();
                player.PlayLooping();
            });
        }

        /// <summary>
        /// Opens new window with ability to change window size which is full-screen by default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_options_Click(object sender, RoutedEventArgs e)
        {
            //ToDo: save entered data and cast it on windows
            Configuration config = new Configuration();
            config.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            config.ShowDialog();
            //var result = MessageBox.Show("Erase game progress?", "Configurations", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            //if (result == MessageBoxResult.Yes)
            //{
            //    //ToDo: Have a record of the game progress and clear it in the case of this answer
            //    MessageBox.Show("Progress erased.");
            //}
            //else
            //{
            //    MessageBox.Show("Progress not erased.");
            //}
        }
    }
}
