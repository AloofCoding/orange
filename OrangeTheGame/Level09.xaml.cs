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
using System.Drawing.Drawing2D;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using System.Threading;


namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level09.xaml
    /// </summary>
    public partial class Level09 : Window
    {
        public Level09(Sql_handler sql_handler)
        List<string> list_orange = new List<string>();
        int count = 0;
        private Storyboard animation1;
        private Storyboard animation2;
        private Storyboard animation3;
        private Storyboard animation4;

        public Level09()
        {
            handler = sql_handler;
            InitializeComponent();

            //https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8

            lbl_guess.Height = 0;
            lbl_guess.Opacity = 0.0;
            lbl_thanks.Height = 0;
            lbl_thanks.Opacity = 0.0;
            lbl_yellow.Height=0;
            lbl_yellow.Opacity = 0.0;
            lbl_yellow_Copy.Height = 0;
            lbl_yellow_Copy.Opacity = 0.0;


            DoubleAnimation ch_opacity1 = new DoubleAnimation();
            ch_opacity1.From = 0.0;
            ch_opacity1.To = 1.0;
            ch_opacity1.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation1 = new Storyboard();
            animation1.Children.Add(ch_opacity1);
            Storyboard.SetTargetName(ch_opacity1, "lbl_thanks");
            Storyboard.SetTargetProperty(ch_opacity1, new PropertyPath(Label.OpacityProperty));

            DoubleAnimation ch_opacity2 = new DoubleAnimation();
            ch_opacity2.From = 0.0;
            ch_opacity2.To = 1.0;
            ch_opacity2.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation2 = new Storyboard();
            animation2.Children.Add(ch_opacity2);
            Storyboard.SetTargetName(ch_opacity2, "lbl_guess");
            Storyboard.SetTargetProperty(ch_opacity2, new PropertyPath(Label.OpacityProperty));

            DoubleAnimation ch_opacity3 = new DoubleAnimation();
            ch_opacity3.From = 0.0;
            ch_opacity3.To = 1.0;
            ch_opacity3.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation3 = new Storyboard();
            animation3.Children.Add(ch_opacity3);
            Storyboard.SetTargetName(ch_opacity3, "lbl_yellow");
            Storyboard.SetTargetProperty(ch_opacity3, new PropertyPath(Label.OpacityProperty));

            DoubleAnimation ch_opacity4 = new DoubleAnimation();
            ch_opacity4.From = 0.0;
            ch_opacity4.To = 1.0;
            ch_opacity4.Duration = new Duration(TimeSpan.FromSeconds(3));
            animation4 = new Storyboard();
            animation4.Children.Add(ch_opacity4);
            Storyboard.SetTargetName(ch_opacity4, "lbl_yellow_Copy");
            Storyboard.SetTargetProperty(ch_opacity4, new PropertyPath(Label.OpacityProperty));


            grid_content.BringIntoView();
        }

        Sql_handler handler;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            handler.Cmd.Connection = handler.Con;
            handler.Cmd.CommandText = "update login set progress = " + handler.Progress + " where username = '" + handler.Username + "';";
            handler.Cmd.ExecuteNonQuery();
        }
        
        private void lbl_e_MouseDown(object sender, MouseButtonEventArgs e)
        {
            count++;
            Label label = (Label)sender;
            label.Foreground = new SolidColorBrush(Color.FromRgb(206, 115, 0));
            list_orange.Add(label.Content.ToString());

            if (count == 6)
            {
                string keyword = "";
                foreach(string s in list_orange)
                {
                    keyword += s;
                }
                if (keyword.ToLower().Equals("orange"))
                {
                    finished();
                }
                else
                {
                    foreach(object o in grid_content.Children)
                    {
                        if (o.GetType().Equals(lbl_a.GetType()))
                        {
                            Label l = (Label)o;
                            l.Foreground = Brushes.Black;
                        }
                    }
                    list_orange.Clear();
                    count = 0;
                }
            }
        }

        private async void finished()
        {
            grid_content.Visibility = Visibility.Hidden;
            lbl_9.Visibility = Visibility.Hidden;
            lbl_guess.Height = 143;
            lbl_thanks.Height = 130;
            lbl_yellow.Height = 77;
            lbl_yellow_Copy.Height = 77;
            animation1.Begin(this);

            await Task.Run(() =>
            {
                Thread.Sleep(4000);
            });
            animation2.Begin(this);
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            animation3.Begin(this);

            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            animation4.Begin(this);


            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            MainWindow level = new MainWindow();
            level.Show();
            Close();
        }
    }
}
