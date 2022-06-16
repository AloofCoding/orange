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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        Sql_handler handler = new Sql_handler();

        public Configuration(Sql_handler sql_handler)
        {
            handler = sql_handler;
            InitializeComponent();
            //todo: import/read currently active settings
            //if(Resources.)
            //btn_close.Content = " Save & Close ";
            lbl_pixelsettings.Content = "Change window size:\n(Min: 800x450)";
            txt_width.Text = handler.Size_Width.ToString();
            txt_height.Text = handler.Size_Height.ToString();
            if (handler.Username is null)
            {
                txt_username.Text = "Username";
            }
            else
            {
                txt_username.Text = handler.Username.ToString();
            }
            if (handler.Fullscreen)
            {
                chk_fullscreen.IsChecked = true;
            }
            else
            {
                chk_fullscreen.IsChecked = false;
            }
        }

        #region https://iditect.com/guide/csharp/csharp_howto_make_a_textbox_only_accept_numbers_in_wpf.html
        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void PasteNumericValidation(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String input = (String)e.DataObject.GetData(typeof(String));
                if (new Regex("[^0-9]+").IsMatch(input))
                {
                    e.CancelCommand();
                }
            }
            else e.CancelCommand();
        }
        #endregion

        /// <summary>
        /// saving the settings into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (Boolean.Parse(cb_signup.IsChecked.ToString()))
            {
                if (pb_password.Password.Equals(pb_repeat.Password) && !string.IsNullOrWhiteSpace(txt_username.Text) && !string.IsNullOrWhiteSpace(pb_password.Password))
                {
                    handler.Con = new SqlConnection("server=(localdb)\\MSSQLLocalDB; Integrated Security = true;");
                    handler.Con.Open();
                    handler.create_db(handler.Con);
                    MessageBox.Show(handler.signup(txt_username.Text, pb_password.Password, handler.Progress, Int32.Parse(txt_width.Text.ToString()), Int32.Parse(txt_height.Text.ToString()), chk_fullscreen.IsChecked.Value, handler.Music));
                }
                else
                {
                    MessageBox.Show("Die eingegebenen Passwörter stimmen nicht überein.", "Achtung");
                } 
            }
            else
            {
                handler.Con = new SqlConnection("server=(localdb)\\MSSQLLocalDB; Integrated Security = true;");
                if (!txt_username.Text.Equals("") && !pb_password.Password.Equals(""))
                {
                    if (handler.signin(txt_username.Text, pb_password.Password, handler.Con))
                    {
                        handler.Cmd.CommandText = "select width from login where username = '" + txt_username.Text + "';";
                        SqlDataReader reader = handler.Cmd.ExecuteReader();
                        reader.Read();
                        txt_width.Text = reader.GetInt32(0).ToString();
                        reader.Close();

                        handler.Cmd.CommandText = "select height from login where username = '" + txt_username.Text + "';";
                        reader = handler.Cmd.ExecuteReader();
                        reader.Read();
                        txt_height.Text = reader.GetInt32(0).ToString();
                        reader.Close();

                        handler.Cmd.CommandText = "select fullscreen from login where username = '" + txt_username.Text + "';";
                        reader = handler.Cmd.ExecuteReader();
                        reader.Read();
                        handler.Fullscreen = Boolean.Parse(reader.GetString(0));
                        //MessageBox.Show(handler.Fullscreen.ToString());
                        if (handler.Fullscreen)
                        {
                            chk_fullscreen.IsChecked = true;
                        }
                        else
                        {
                            chk_fullscreen.IsChecked = false;
                        }
                        reader.Close();

                        handler.Cmd.CommandText = "select music from login where username = '" + txt_username.Text + "';";
                        reader = handler.Cmd.ExecuteReader();
                        reader.Read();
                        handler.Music = Boolean.Parse(reader.GetString(0));
                        reader.Close();
                    }
                }
            }

            int width;
            int height;
            if (!chk_fullscreen.IsChecked.Value)
            {
                if (!Int32.TryParse(txt_width.Text.ToString(), out width)
                        || width < 800
                        || !Int32.TryParse(txt_height.Text.ToString(), out height)
                        || height < 450)
                {
                    MessageBox.Show("Please fill out the two textboxes with valid numbers without any decimals.\n" +
                        "Please make sure that your chosen size is >= 800x450.");
                }
                else
                {
                    //MessageBox.Show("New size: " + width + "x" + height, "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    //this.Close();
                }

            }
            else
            {
                //MessageBox.Show("You chose to have fullscreen windows", "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
                //Close();
            }

            handler.Size_Width = Int32.Parse(txt_width.Text);
            handler.Size_Height = Int32.Parse(txt_height.Text);
            handler.Username = txt_username.Text;
        }

        private void chk_fullscreen_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_pixelsettings.IsEnabled = true;
            lbl_x.IsEnabled = true;
            txt_height.IsEnabled = true;
            txt_width.IsEnabled = true;
        }

        private void chk_fullscreen_Checked(object sender, RoutedEventArgs e)
        {
            lbl_pixelsettings.IsEnabled = false;
            lbl_x.IsEnabled = false;
            txt_height.IsEnabled = false;
            txt_width.IsEnabled = false;
        }

        private void cb_signup_Checked(object sender, RoutedEventArgs e)
        {
            lbl_login.Content = "Sign up:";
            pb_repeat.Visibility = Visibility.Visible;
        }

        private void cb_signup_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_login.Content = "Login:";
            pb_repeat.Visibility = Visibility.Hidden;
        }

        private void txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
