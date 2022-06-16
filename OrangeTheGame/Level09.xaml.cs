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
    /// Interaktionslogik für Level09.xaml
    /// </summary>
    public partial class Level09 : Window
    {
        public Level09(Sql_handler sql_handler)
        {
            handler = sql_handler;
            InitializeComponent();
        }

        Sql_handler handler;

        private void btn_finish_Click(object sender, RoutedEventArgs e)
        {
            LevelSelection level = new LevelSelection(handler);
            level.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            handler.Cmd.Connection = handler.Con;
            handler.Cmd.CommandText = "update login set progress = " + handler.Progress + " where username = '" + handler.Username + "';";
            handler.Cmd.ExecuteNonQuery();
        }
    }
}
