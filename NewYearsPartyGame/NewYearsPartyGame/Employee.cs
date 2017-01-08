using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media;

namespace NewYearsPartyGame
{
    class Employee
    {
        private string _name;
        private double _x;
        private double _y;
        private Grid _grid;
        private Random rnd = new Random();

        public string Name { get { return _name; } }
        public double X { get { return _x; } }
        public double Y { get { return _y; } }
        public Grid Grid { get { return _grid; } }

        public Employee(string name, string photoPath, double x, double y, double gridWidth, double gridHeight, int circleRadius)
        {
            _name = name;
            _x = x;
            _y = y;
            _grid = new Grid();
            _grid.Height = gridHeight;
            _grid.Width = gridWidth;


            BitmapImage img;
            try
            {
                img = new BitmapImage(new Uri(photoPath, UriKind.Absolute));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                img = new BitmapImage(new Uri(@"images/中国结.jpg", UriKind.RelativeOrAbsolute));
            }

            Ellipse circle = new Ellipse();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb((byte)rnd.Next(120, 256), (byte)rnd.Next(120, 256), (byte)rnd.Next(120, 256), (byte)rnd.Next(120, 256));
            circle.Fill = brush;
            circle.Stroke = Brushes.Black;
            circle.Width = circleRadius*2;
            circle.Height = circleRadius*2;
            circle.HorizontalAlignment = HorizontalAlignment.Left;
            circle.VerticalAlignment = VerticalAlignment.Top;
            circle.Margin = new Thickness(0, 0, 0, 0);
            _grid.Children.Add(circle);

            Ellipse photoEllipse = new Ellipse();
            photoEllipse.Visibility = Visibility.Hidden;
            photoEllipse.Fill = new ImageBrush(img);
            photoEllipse.Width = gridWidth;
            photoEllipse.Height = gridHeight;
            photoEllipse.HorizontalAlignment = HorizontalAlignment.Center;
            photoEllipse.VerticalAlignment = VerticalAlignment.Top;
            _grid.Children.Add(photoEllipse);


            TextBox txbx = new TextBox();
            txbx.Visibility = Visibility.Hidden;
            txbx.Height = gridHeight / 4;
            txbx.Width = gridWidth;
            txbx.Text = name;
            txbx.TextAlignment = TextAlignment.Center;
            txbx.HorizontalAlignment = HorizontalAlignment.Center;
            txbx.VerticalAlignment = VerticalAlignment.Bottom;
            _grid.Children.Add(txbx);


            _grid.HorizontalAlignment = HorizontalAlignment.Left;
            _grid.VerticalAlignment = VerticalAlignment.Top;
            _grid.Margin = new Thickness(x, y, 0, 0);
        }
    }
}
