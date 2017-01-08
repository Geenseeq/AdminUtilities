using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewYearsPartyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer bgmMP;
        private MediaPlayer actionMP;

        private List<Employee> employeesList;
        private Ellipse transcriptase;
        private int circleRaius = 20;

        public MainWindow()
        {
            InitializeComponent();


            actionArea.Loaded += new RoutedEventHandler(ActionGrid_Loaded);
            
        }

        private void DrawLine(Point orig, Point dest)
        {
            Line line = new Line
            {
                StrokeThickness = 3,
                Stroke = new SolidColorBrush(Colors.DarkBlue),
                X1 = orig.X,
                Y1 = orig.Y,
                X2 = dest.X,
                Y2 = dest.Y
            };
            actionArea.Children.Add(line);
        }

        private void LoadEmployees()
        {
            double photoWidth = actionArea.ActualWidth / 20;
            double photoHeight = actionArea.ActualHeight / 10;

            DirectoryInfo d = new DirectoryInfo(@"images\photos");
            FileInfo[] Files = d.GetFiles("*.*");
            int nEmps = Files.Count();
            int empsPerStrand = (int) Math.Ceiling( ( (double)nEmps) / 4);
            List<double> xCoordsList = new List<double>();
            List<double> yCoordsList = new List<double>();
            double xMargin = actionArea.ActualWidth / 10;

            double xSeparation = actionArea.ActualWidth * 4 / 5 / empsPerStrand;
            Pen drawingPen = new Pen(Brushes.Black, 1);
            //strand 1
            for (int i=0; i< empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 2/ 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI) * actionArea.ActualHeight / 8 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last() + 20, yCoordsList.Last() + 20), new Point(x + 20, y + 20));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 2 (pairs with strand 1)
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 2 / 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI + Math.PI / 1.2) * actionArea.ActualHeight / 8 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last()+20, yCoordsList.Last()+20), new Point(x+20, y+20));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 3
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 3 / 4;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI) * actionArea.ActualHeight / 8 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last() + 20, yCoordsList.Last() + 20), new Point(x + 20, y + 20));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 4 (pairs with strand 3)
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 3 / 4;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI + Math.PI / 1.2) * actionArea.ActualHeight / 8 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last() + 20, yCoordsList.Last() + 20), new Point(x + 20, y + 20));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }

            employeesList = new List<Employee>();
            for(int i=0; i<nEmps; i++)
            {
                FileInfo file = Files[i];
                Employee emp = new Employee(file.Name.Split('.')[0], file.FullName, xCoordsList[i], yCoordsList[i], photoWidth, photoHeight, circleRaius);
                employeesList.Add(emp);
                actionArea.Children.Add(emp.Grid);
            }
        }

        private void ActionGrid_Loaded(object sender, EventArgs e)
        {
            
            LoadEmployees();

            transcriptase = new Ellipse();
            BitmapImage img = new BitmapImage(new Uri(@"images/transcriptase.png", UriKind.RelativeOrAbsolute));
            transcriptase.Fill = new ImageBrush(img);
            transcriptase.Width = circleRaius * 4;
            transcriptase.Height = circleRaius * 4;

            bgmMP = new MediaPlayer();

            bgmMP.MediaFailed += (o, args) =>
            {
                MessageBox.Show("BGM Media Failed!!");
            };
            bgmMP.MediaEnded += (o, args) =>
            {
                bgmMP.Open(new Uri(@"audio/fly_now.mp3", UriKind.RelativeOrAbsolute));
                bgmMP.Play();
            };
            bgmMP.Open(new Uri(@"audio/fly_now.mp3", UriKind.RelativeOrAbsolute));
            bgmMP.Play();

            


        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.Count <= 0)
                return;

            bgmMP.Pause();
            actionMP = new MediaPlayer();
            actionMP.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };
            actionMP.MediaEnded += (o, args) =>
            {
                bgmMP.Play();
            };
            actionMP.Open(new Uri(@"audio/fight.mp3", UriKind.RelativeOrAbsolute));
            actionMP.Play();

        }
    }
}
