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

            handler.Music = true;
        }

        Sql_handler handler = new Sql_handler();

        //Music by <a href="/users/lvymusic-24939435/?tab=audio&amp;utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=audio&amp;utm_content=12964">lvymusic</a> from <a href="https://pixabay.com/music/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12964">Pixabay</a>

        public delegate void ThreadStart();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        private void btn_startGame_Click(object sender, RoutedEventArgs e)
        {
            if (handler.Username != null)
            {
                // showing level selection screen
                // playing a sound effect
                lbl_titleOnStartingScreen.Visibility = Visibility.Hidden;
                btn_startGame.Visibility = Visibility.Hidden;
                LevelSelection level = new LevelSelection(handler);
                if (handler.Fullscreen)
                {
                    level.WindowState = WindowState.Maximized;
                }
                else
                {
                    level.WindowState = WindowState.Normal;
                    level.Width = handler.Size_Width;
                    level.Height = handler.Size_Height;
                }
                this.Close();
                level.Show(); 
            }
            else
            {
                MessageBox.Show("Please log in first!");
            }
        }

        private void btn_music_Click(object sender, RoutedEventArgs e)
        {
            if (btn_music.Content.ToString().Equals("Music: On"))
            {
                btn_music.Content = "Music: Off";
                player.Stop();
                handler.Music = false;
            }
            else
            {
                btn_music.Content = "Music: On";
                player.PlayLooping();
                handler.Music = true;
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
            Configuration config = new Configuration(handler);

            config.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            config.ShowDialog();

            if (handler.Music)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }

            //MessageBox.Show(handler.Music.ToString());

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
