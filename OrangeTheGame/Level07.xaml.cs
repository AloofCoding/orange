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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;


namespace OrangeTheGame
{
    /// <summary>
    /// Interaktionslogik für Level07.xaml
    /// </summary>
    public partial class Level07 : Window
    {
        //ToDo: identify where the access violation occurs: occurs because of played music, not error in this level
        //Das Programm "[4044] OrangeTheGame.exe" wurde mit Code -1073741819 (0xc0000005) 'Access violation' beendet.


        #region Variables
        System.Windows.Point currentPoint = new System.Windows.Point();
        string path;
        SolidColorBrush myBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 143, 2));
        #endregion

        public Level07()
        {
            InitializeComponent();
        }

        /// <summary>
        /// https://stackoverflow.com/questions/16037753/wpf-drawing-on-canvas-with-mouse-events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/16037753/wpf-drawing-on-canvas-with-mouse-events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //polyLine = new Polyline();
                    //polyLine.Stroke = new SolidColorBrush(Colors.AliceBlue);
                    //polyLine.StrokeThickness = 10;
                    Line line = new Line();
                    line.Stroke = myBrush;
                    line.StrokeThickness = 5;
                    line.X1 = currentPoint.X;
                    line.Y1 = currentPoint.Y;
                    line.X2 = e.GetPosition(this).X;
                    line.Y2 = e.GetPosition(this).Y;

                    currentPoint = e.GetPosition(this);

                    paintSurface.Children.Add(line);
                    //https://stackoverflow.com/questions/624534/get-a-bitmap-from-a-wpf-application-window
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Canvas_MouseMove_1\n"+ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintSurface_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                //Thread.Sleep(100);
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string path = System.IO.Path.Combine(projectPath, "Resources\\temp.bmp");
                //path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temp.bmp");
                CreateBitmapFromVisual(Window.GetWindow(paintSurface), path);
                //MessageBox.Show("Back to 102");
                var bitmap = SetImageSource(path);
                var color = GetAverageColor(bitmap);

                if (color.ToString().Equals("#FFFE8E02"))
                {
                    waitFinished();

                    //bitmap = null;
                    //logo = null;
                    //image.Source = null;
                    //image = null;

                    Level09 level = new Level09();
                    level.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("PaintSurfaceMouseUp\n" + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private BitmapSource SetImageSource(string path)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(path);
            //MessageBox.Show(logo.UriSource.AbsoluteUri.ToString());
            logo.EndInit();
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = logo;
            return logo;
        }

        private async void waitFinished()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }

        /// <summary>
        /// Saves the current window as .bmp to the provided path
        /// https://stackoverflow.com/questions/5124825/generating-a-screenshot-of-a-wpf-window
        /// </summary>
        /// <param name="target">What image is saved</param>
        /// <param name="fileName">path where the image will be stored</param>
        public static void CreateBitmapFromVisual(Visual target, string fileName)
        {
            try
            {
                if (target == null || string.IsNullOrEmpty(fileName))
                {
                    return;
                }

                Rect bounds = VisualTreeHelper.GetDescendantBounds(target);

                RenderTargetBitmap renderTarget = new RenderTargetBitmap((Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Pbgra32);

                DrawingVisual visual = new DrawingVisual();

                using (DrawingContext context = visual.RenderOpen())
                {
                    VisualBrush visualBrush = new VisualBrush(target);
                    context.DrawRectangle(visualBrush, null, new Rect(new System.Windows.Point(), bounds.Size));
                }

                renderTarget.Render(visual);
                PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

                //todo: fix error coming up
                //error probably because writing of the files is too often/too fast

                using (Stream stm = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    bitmapEncoder.Save(stm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CreateBitmapFromVisual\n" + ex.ToString());
                Thread.Sleep(100);
                return;
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/1068373/how-to-calculate-the-average-rgb-color-values-of-a-bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns>returns the average color value of the given BitmapSource</returns>
        public System.Windows.Media.Color GetAverageColor(BitmapSource bitmap)
        {
            try
            {
                var format = bitmap.Format;

                if (format != PixelFormats.Bgr24 &&
                    format != PixelFormats.Bgr32 &&
                    format != PixelFormats.Bgra32 &&
                    format != PixelFormats.Pbgra32)
                {
                    throw new InvalidOperationException("BitmapSource must have Bgr24, Bgr32, Bgra32 or Pbgra32 format");
                }

                var width = bitmap.PixelWidth;
                var height = bitmap.PixelHeight;
                var numPixels = width * height;
                var bytesPerPixel = format.BitsPerPixel / 8;
                var pixelBuffer = new byte[numPixels * bytesPerPixel];

                bitmap.CopyPixels(pixelBuffer, width * bytesPerPixel, 0);

                long blue = 0;
                long green = 0;
                long red = 0;

                for (int i = 0; i < pixelBuffer.Length; i += bytesPerPixel)
                {
                    blue += pixelBuffer[i];
                    green += pixelBuffer[i + 1];
                    red += pixelBuffer[i + 2];
                }

                return System.Windows.Media.Color.FromRgb((byte)(red / numPixels), (byte)(green / numPixels), (byte)(blue / numPixels));

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAverageColor()\n" + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// deletes temp.bmp after the level is finished and the window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Closed(object sender, EventArgs e)
        {
            //await Task.Run(() =>
            //{
            //    Thread.Sleep(5000);
            //});

            //File.Delete(path);
        }
    }
}
