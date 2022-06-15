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


namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level09.xaml
    /// </summary>
    public partial class Level09 : Window
    {
        public Level09()
        {
            InitializeComponent();
        }

        private void btn_finish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        //ToDo: currently no difference to program before adding snake code
        #region var && cons
        private const int HeadWidth = 10;
        private int Move = 0;
        // position
        private int HeadX = 0;
        private int HeadY = 0;
        private int FoodX = 10;
        private int FoodY = 10;
        #endregion

        #region counter
        private int Archive = 0;
        private int CountScore = 0;
        private int CountMove = 0;
        private List<int> PosX = new List<int>();
        private List<int> PosY = new List<int>();
        private List<int> CountArchive = new List<int>();
        #endregion

        System.Timers.Timer tim_speed = new System.Timers.Timer();

        private void Tim_speed_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            tim_speed.Enabled = true;

            //lbl_x.Text = Convert.ToString(HeadX)+":"+ Convert.ToString(HeadY);
            //lbl_y.Text = Convert.ToString(FoodX)+":"+ Convert.ToString(FoodY);

            #region Movement
            if (Move == 0)
            {
                HeadY += HeadWidth;
            }
            if (Move == 1)
            {
                HeadX += HeadWidth;
            }
            if (Move == 2)
            {
                HeadY -= HeadWidth;
            }
            if (Move == 3)
            {
                HeadX -= HeadWidth;
            }
            #endregion

            #region point / food eaten
            if (FoodX == HeadX && FoodY == HeadY)
            {
                CountScore += 1;
                CountArchive.Add(CountScore);
                //lbl_score_number.Text = Convert.ToString(CountScore);
                do
                {
                    FoodX = rnd.Next(10, 800 - HeadWidth);
                } while (FoodX % HeadWidth != 0);
                do
                {
                    FoodY = rnd.Next(10, 450- HeadWidth);
                } while (FoodY % HeadWidth != 0);
            }
            #endregion

            CountMove += 1;
            PosX.Add(HeadX);
            PosY.Add(HeadY);

            ///////////////
            // Game over //
            ///////////////
            // Case 1
            if (CountScore > 0)
            {
                List<int> sublistX = PosX.GetRange(PosX.Count - CountScore, CountScore - 1);
                List<int> sublistY = PosY.GetRange(PosY.Count - CountScore, CountScore - 1);


                if (sublistX.Contains(HeadX) && sublistY.Contains(HeadY))
                {
                    for (int i = 0; i < sublistX.Count; i++)
                    {
                        if (sublistX[i] == HeadX && sublistY[i] == HeadY)
                        {
                            //tim_speed.Enabled = false;
                            //MessageBox.Show("Sie haben sich selbst gefressen!", "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //StreamWriter datei = new StreamWriter(@"scorelog.txt", true);
                            //datei.WriteLine(CountScore);
                            //datei.Flush();
                            //datei.Close();
                            //datei.Dispose();

                            //ToDo: Restart level with set code
                            //Application.Restart();
                        }
                    }
                }
            }
            // Case 2
            if (HeadX < 0 || HeadY < 0 || HeadX > 800 || HeadY > 450)
            {
                //tim_speed.Enabled = false;
                //MessageBox.Show("Sie haben die Wand berührt!", "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //StreamWriter datei = new StreamWriter(@"scorelog.txt", true);
                //datei.WriteLine(CountScore);
                //datei.Flush();
                //datei.Close();
                //datei.Dispose();
                //ToDo: Restart level with set code, maybe use a method
                //Application.Restart();
            }
            UpdateLayout();
        }

        private void Snake_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        //ToDo: find right eventargs/change the code so it works
        private void Snake_Paint(object sender, EventArgs e)
        {
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //e.Graphics.FillEllipse(Brushes.Black, HeadX, HeadY, HeadWidth, HeadWidth);

            Ellipse ellipse = new Ellipse();
            ellipse.Width = HeadWidth;
            ellipse.Height = HeadWidth;
            ellipse.Fill = Brushes.DarkOrange;
            this.AddChild(ellipse);

            //e.Graphics.FillRectangle(Brushes.Red, FoodX, FoodY, HeadWidth, HeadWidth);
            Ellipse food = new Ellipse();
            
            food.Width = HeadWidth;
            food.Height = HeadWidth;
            food.Fill = Brushes.Black;
            

            for (int i = 0; i < CountArchive.Count; i++)
            {
                //e.Graphics.FillEllipse(Brushes.Green, PosX[CountMove - CountArchive[i] - 1], PosY[CountMove - CountArchive[i] - 1], HeadWidth, HeadWidth);
            }
            Archive = CountScore;
        }

        private void Snake_Load(object sender, EventArgs e)
        {


            //StreamReader top = new StreamReader(@"scorelog.txt", true);
            //string line;
            //List<int> highscore = new List<int>();
            //while ((line = top.ReadLine()) != null)
            //{
            //    highscore.Add(Convert.ToInt16(line));
            //}
            //lbl_highscore_number.Text = Convert.ToString(highscore.Max());
            //top.Close();

            UpdateLayout();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (Move == 0 || Move == 2)
            {
                if (e.Key == Key.Right)
                {
                    Move = 1;
                }
                if (e.Key == Key.Left)
                {
                    Move = 3;
                }
            }
            if (Move == 1 || Move == 3)
            {
                if (e.Key == Key.Down)
                {
                    Move = 0;
                }
                if (e.Key == Key.Up)
                {
                    Move = 2;
                }
            }

            //if (e.KeyCode == Keys.P)
            //{
            //    if (tim_speed.Enabled)
            //    {
            //        tim_speed.Enabled = false;
            //        lbl_pause.Text = "-Pause-";
            //    }
            //    else
            //    {
            //        tim_speed.Enabled = true;
            //        lbl_pause.Text = null;
            //    }
            //}
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            do
            {
                FoodX = rnd.Next(10, 800- HeadWidth);
            } while (FoodX % HeadWidth != 0);

            do
            {
                FoodY = rnd.Next(10, 450 - HeadWidth);
            } while (FoodY % HeadWidth != 0);
        }
    }
}
