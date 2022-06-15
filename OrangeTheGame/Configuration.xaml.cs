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

namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        public Configuration()
        {
            InitializeComponent();
            //todo: import/read currently active settings
            //if(Resources.)
            btn_close.Content = " Save & Close ";
            lbl_pixelsettings.Content = "Change window size:\n(Min: 800x450)";
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

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            //todo: export/save new settings
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
                    MessageBox.Show("New size: " + width + "x" + height, "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("You chose to have fullscreen windows", "Settings saved", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
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
            txt_repeat.Visibility = Visibility.Visible;
        }

        private void cb_signup_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl_login.Content = "Login:";
            txt_repeat.Visibility = Visibility.Hidden;
        }

        private void txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
