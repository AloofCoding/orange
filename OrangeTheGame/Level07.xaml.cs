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
        //ToDo: Edit the path to save temp.bmp to a real temporary folder
        
        //https://stackoverflow.com/questions/16037753/wpf-drawing-on-canvas-with-mouse-events
        Point currentPoint = new Point();
        string path;

        public Level07()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(this);
            }
        }

        private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //polyLine = new Polyline();
                //polyLine.Stroke = new SolidColorBrush(Colors.AliceBlue);
                //polyLine.StrokeThickness = 10;
                Line line = new Line();
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromRgb(255,143,2));
                line.Stroke = myBrush;
                line.StrokeThickness = 5;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                paintSurface.Children.Add(line);
                //https://stackoverflow.com/questions/1068373/how-to-calculate-the-average-rgb-color-values-of-a-bitmap
                //https://stackoverflow.com/questions/624534/get-a-bitmap-from-a-wpf-application-window
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paintSurface_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Thread.Sleep(100);
            path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\temp.bmp");
            CreateBitmapFromVisual(Window.GetWindow(paintSurface), path);

            Image image = new Image();

            //https://stackoverflow.com/questions/350027/setting-wpf-image-source-in-code
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri(path);
            logo.EndInit();

            image.Source = logo;

            var bitmap = (BitmapSource)image.Source;
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

        private async void waitFinished100()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
            });
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
                context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
            }

            renderTarget.Render(visual);
            PngBitmapEncoder bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            using (Stream stm = File.Create(fileName))
            {
                bitmapEncoder.Save(stm);
            }
        }

        /// <summary>
        /// https://stackoverflow.com/questions/29837719/get-average-rgb-values-from-picture-displayed-inside-image-control-in-vb-net
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public Color GetAverageColor(BitmapSource bitmap)
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

            return Color.FromRgb((byte)(red / numPixels), (byte)(green / numPixels), (byte)(blue / numPixels));
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            File.Delete(path);
        }
    }
}
