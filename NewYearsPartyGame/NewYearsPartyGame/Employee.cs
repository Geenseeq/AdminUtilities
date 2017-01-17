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
        private BitmapImage _photo;
        //private Color[] colorPalette = {Colors.AliceBlue, Colors.Aquamarine, Colors.Azure, Colors.Blue, Colors.Chartreuse, Colors.Red, Colors.Yellow, Colors.ForestGreen,
        //Colors.Pink, Colors.Plum, Colors.Purple, Colors.Silver, Colors.Orange};

        public string Name { get { return _name; } }
        public BitmapImage Photo { get { return _photo; } }

        public Employee(string name, string photoPath)
        {
            _name = name;
            try
            {
                _photo = new BitmapImage(new Uri(photoPath, UriKind.RelativeOrAbsolute));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                _photo = new BitmapImage(new Uri(@"images/中国结.jpg", UriKind.RelativeOrAbsolute));
            }


        }
    }
}
