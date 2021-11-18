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
    /// Interaktionslogik für Level07.xaml
    /// </summary>
    public partial class Level07 : Window
    {
        //https://stackoverflow.com/questions/16037753/wpf-drawing-on-canvas-with-mouse-events
        Point currentPoint = new Point();

        public Level07()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
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
            }
        }
    }
}
