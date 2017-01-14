using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        private int empsPerRound = 20;
        private bool inChoosingEmps = false;
        private string[] bgmFileNames = { "audio/bgm_0.mp3", "audio/bgm_1.mp3", "audio/bgm_2.mp3" };
        private int currentBgmIndex = 0;

        private List<Employee> employeesList = new List<Employee>();
        private int empsChosen = 0;
        private List<Grid> employeesChosenGridList = new List<Grid>();
        Employee currEmp = null;
        //private Ellipse transcriptase;
        private int circleRaius = 17;
        private double photoWidth;
        private double photoHeight;
        private Duration translateDuration = new Duration(new TimeSpan(0, 0, 0, 5, 0));
        private List<double> chosenEmpsXCoords;
        private double[] chosenEmpsYCoord;

        //TranslateTransform ttx = new TranslateTransform();
        //TranslateTransform tty = new TranslateTransform();
        //DoubleAnimation dax = new DoubleAnimation();
        //DoubleAnimation day = new DoubleAnimation();
        //TransformGroup tg = new TransformGroup();

        public MainWindow()
        {
            InitializeComponent();


            actionArea.Loaded += new RoutedEventHandler(ActionGrid_Loaded);

        }

        private void DrawLine(Point orig, Point dest)
        {
            DoubleCollection dashes = new DoubleCollection();
            dashes.Add(1);
            dashes.Add(1);
            Line line = new Line
            {
                StrokeThickness = 3,
                StrokeDashArray = dashes,
                Stroke = new SolidColorBrush(Colors.DarkBlue),
                X1 = orig.X + circleRaius,
                Y1 = orig.Y + circleRaius,
                X2 = dest.X + circleRaius,
                Y2 = dest.Y + circleRaius
            };
            actionArea.Children.Add(line);
        }

        private void LoadEmployees()
        {
            photoWidth = actionArea.ActualWidth / 13;
            photoHeight = actionArea.ActualHeight / 6;

            DirectoryInfo d = new DirectoryInfo(@"images\photos");
            FileInfo[] Files = d.GetFiles("*.*");
            int nEmps = Files.Count();
            int empsPerStrand = (int)Math.Ceiling(((double)nEmps) / 4);
            List<double> xCoordsList = new List<double>();
            List<double> yCoordsList = new List<double>();
            double xMargin = actionArea.ActualWidth / 20;

            double xSeparation = actionArea.ActualWidth * 9 / 10 / empsPerStrand;
            Pen drawingPen = new Pen(Brushes.Black, 1);
            //strand 1
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 3 / 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI) * actionArea.ActualHeight / 12 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last(), yCoordsList.Last()), new Point(x, y));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 2 (pairs with strand 1)
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 3 / 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI + Math.PI / 1.2) * actionArea.ActualHeight / 12 + yCenter;

                DrawLine(new Point(x, y), new Point(xCoordsList[i], yCoordsList[i]));
                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last(), yCoordsList.Last()), new Point(x, y));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 3
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 4 / 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI + Math.PI / 2) * actionArea.ActualHeight / 12 + yCenter;

                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last(), yCoordsList.Last()), new Point(x, y));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }
            //strand 4 (pairs with strand 3)
            for (int i = 0; i < empsPerStrand; i++)
            {
                double yCenter = actionArea.ActualHeight * 4 / 5;
                double x = xMargin + xSeparation * i;
                double y = Math.Sin((double)i / empsPerStrand * 10 * Math.PI + Math.PI / 1.2 + Math.PI / 2) * actionArea.ActualHeight / 12 + yCenter;

                DrawLine(new Point(x, y), new Point(xCoordsList[i + empsPerStrand * 2], yCoordsList[i + empsPerStrand * 2]));
                if (i != 0)
                    DrawLine(new Point(xCoordsList.Last(), yCoordsList.Last()), new Point(x, y));

                xCoordsList.Add(x);
                yCoordsList.Add(y);
            }

            for (int i = 0; i < nEmps; i++)
            {
                FileInfo file = Files[i];
                Employee emp = new Employee(file.Name.Split('.')[0], file.FullName, xCoordsList[i], yCoordsList[i], photoWidth, photoHeight, circleRaius);
                Thread.Sleep(1);
                employeesList.Add(emp);
                actionArea.Children.Add(emp.Grid);
            }
        }

        private void ActionGrid_Loaded(object sender, EventArgs e)
        {

            LoadEmployees();

            InitializeVisuals();

            bgmMP = new MediaPlayer();

            bgmMP.MediaFailed += (o, args) =>
            {
                MessageBox.Show("BGM Media Failed!!");
            };
            bgmMP.MediaEnded += (o, args) =>
            {
                bgmMP.Open(new Uri(bgmFileNames[currentBgmIndex], UriKind.RelativeOrAbsolute));
                currentBgmIndex++;
                if (currentBgmIndex >= bgmFileNames.Count())
                    currentBgmIndex = 0;
                bgmMP.Play();
            };
            bgmMP.Open(new Uri(bgmFileNames[currentBgmIndex], UriKind.RelativeOrAbsolute));
            currentBgmIndex++;
            bgmMP.Play();

        }

        private void InitializeVisuals()
        {
            //transcriptase = new Ellipse();
            //BitmapImage img = new BitmapImage(new Uri(@"images/transcriptase.png", UriKind.RelativeOrAbsolute));
            //transcriptase.Fill = new ImageBrush(img);
            //transcriptase.Width = circleRaius * 6;
            //transcriptase.Height = circleRaius * 6;
            ////Canvas.SetLeft(transcriptase, actionArea.ActualWidth / 2);
            ////Canvas.SetTop(transcriptase, 0 - actionArea.ActualHeight / 2);
            //transcriptase.VerticalAlignment = VerticalAlignment.Top;
            //transcriptase.HorizontalAlignment = HorizontalAlignment.Center;
            //actionArea.Children.Add(transcriptase);

            chosenEmpsXCoords = new List<double>();
            double xMargin = actionArea.ActualWidth / 20;
            double xSeparation = actionArea.ActualWidth * 9 / 5 / empsPerRound;
            //make two rows
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < empsPerRound / 2; i++)
                {
                    chosenEmpsXCoords.Add(xMargin + i * xSeparation);
                }
            }
            chosenEmpsYCoord = new Double[] { actionArea.ActualHeight / 20, actionArea.ActualHeight / 3.5 };


            employeesChosenGridList = new List<Grid>();
            for(int i=0; i<empsPerRound; i++)
            {
                Grid _grid = new Grid();
                Ellipse photoEllipse = new Ellipse();
                photoEllipse.Name = "photo";
                photoEllipse.Width = photoWidth * .93;
                photoEllipse.Height = photoHeight;
                photoEllipse.HorizontalAlignment = HorizontalAlignment.Center;
                photoEllipse.VerticalAlignment = VerticalAlignment.Top;
                _grid.Children.Add(photoEllipse);


                TextBox txbx = new TextBox();
                txbx.Name = "name";
                txbx.Height = photoHeight / 5;
                txbx.Width = photoWidth;
                txbx.FontSize = 18;
                txbx.FontWeight = FontWeights.Bold;
                txbx.Background = Brushes.DeepSkyBlue;
                txbx.Foreground = Brushes.White;
                txbx.TextAlignment = TextAlignment.Center;
                txbx.HorizontalAlignment = HorizontalAlignment.Center;
                txbx.VerticalAlignment = VerticalAlignment.Bottom;
                _grid.Children.Add(txbx);

                _grid.Visibility = Visibility.Hidden;
                _grid.HorizontalAlignment = HorizontalAlignment.Left;
                _grid.VerticalAlignment = VerticalAlignment.Top;
                if (i<empsPerRound/2)
                    _grid.Margin = new Thickness(chosenEmpsXCoords[i], chosenEmpsYCoord[0], 0, 0);
                else
                    _grid.Margin = new Thickness(chosenEmpsXCoords[i], chosenEmpsYCoord[1], 0, 0);
                actionArea.Children.Add(_grid);
                employeesChosenGridList.Add(_grid);
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            if (inChoosingEmps)
                return;

            inChoosingEmps = true;
            Random rnd = new Random();

            if (employeesList.Count <= 0)
                return;

            foreach(Grid g in employeesChosenGridList)
            {
                g.Visibility = Visibility.Hidden;
            }

            bgmMP.Pause();
            actionMP = new MediaPlayer();
            actionMP.Open(new Uri(@"audio/stadium.mp3", UriKind.RelativeOrAbsolute));
            actionMP.Play();

            actionMP.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed!!");
            };

            actionMP.MediaOpened += new EventHandler(ShowEmp);

            actionMP.MediaEnded += (o, args) =>
            {
                bgmMP.Play();
            };
        }

        private void ShowEmp(object sender, EventArgs e)
        {
            //if (currEmp != null)
            //{
            //}
            if (empsChosen >= empsPerRound || employeesList.Count()==0)
            {
                currEmp = null;
                inChoosingEmps = false;
                empsChosen = 0;
                return;
            }

            Random rnd = new Random();
            int indexChosen = rnd.Next(0, employeesList.Count());
            currEmp = employeesList[indexChosen];

            double deltaX = chosenEmpsXCoords[empsChosen] - currEmp.X;
            double deltaY;
            if (empsChosen < empsPerRound / 2)
                deltaY = chosenEmpsYCoord[0] - currEmp.Y;
            else
                deltaY = chosenEmpsYCoord[1] - currEmp.Y;


            TranslateTransform ttx = new TranslateTransform();
            TranslateTransform tty = new TranslateTransform();
            DoubleAnimation dax = new DoubleAnimation();
            DoubleAnimation day = new DoubleAnimation();
            //dax = new DoubleAnimation(currEmp.X, chosenEmpsXCoords[empsChosen], new Duration(TimeSpan.FromSeconds(1)));
            dax = new DoubleAnimation(deltaX, new Duration(TimeSpan.FromSeconds(.5)));
            //if (empsChosen < empsPerRound / 2)
            //    day = new DoubleAnimation(currEmp.Y, chosenEmpsYCoord[0], new Duration(TimeSpan.FromSeconds(1)));
            //else
            //    day = new DoubleAnimation(currEmp.Y, chosenEmpsYCoord[1], new Duration(TimeSpan.FromSeconds(1)));
            day = new DoubleAnimation(deltaY, new Duration(TimeSpan.FromSeconds(.5)));
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(ttx);
            tg.Children.Add(tty);

            dax.Completed += (o, args) =>
            {
                BitmapImage img;
                try
                {
                    img = new BitmapImage(new Uri(currEmp.PhotoPath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    img = new BitmapImage(new Uri(@"images/中国结.jpg", UriKind.RelativeOrAbsolute));
                }

                //(currEmp.Grid.Children[1] as Ellipse).Fill = new ImageBrush(img);
                (employeesChosenGridList[empsChosen].Children[0] as Ellipse).Fill = new ImageBrush(img);
                (employeesChosenGridList[empsChosen].Children[1] as TextBox).Text = currEmp.Name;
                currEmp.Grid.Children[0].Visibility = Visibility.Hidden;//circle
                employeesChosenGridList[empsChosen].Visibility = Visibility.Visible;
                //employeesChosenGridList[empsChosen].Children[0].Visibility = Visibility.Visible;//ellipse
                //employeesChosenGridList[empsChosen].Children[1].Visibility = Visibility.Visible;//textbox
                empsChosen++;
                employeesList.Remove(currEmp);

            };
            dax.Completed += new EventHandler(ShowEmp);

            currEmp.Grid.RenderTransform = tg;
            ttx.BeginAnimation(TranslateTransform.XProperty, dax);
            tty.BeginAnimation(TranslateTransform.YProperty, day);

        }

        /*
        private void TranscriptaseGrabEmp(object sender, EventArgs e)
        {
            if (employeesChosenList.Count() >= empsPerRound)
            {
                //bgmMP.Play();
                inChoosingEmps = false;
                return;
            }

            Random rnd = new Random();
            int indexChosen = rnd.Next(0, employeesList.Count());
            currEmp = employeesList[indexChosen];

            Point transcriptasePoint = transcriptase.TransformToAncestor(actionArea).Transform(new Point(0, 0));
            double deltaX = currEmp.X - transcriptasePoint.X;
            double deltaY = currEmp.Y - transcriptasePoint.Y;

            ttx = new TranslateTransform();
            tty = new TranslateTransform();
            //dax = new DoubleAnimation(transcriptasePoint.X, currEmp.X, new Duration(TimeSpan.FromSeconds(1)));
            //day = new DoubleAnimation(transcriptasePoint.Y, currEmp.Y, new Duration(TimeSpan.FromSeconds(1)));
            dax = new DoubleAnimation(deltaX, new Duration(TimeSpan.FromSeconds(1)));
            day = new DoubleAnimation(deltaY, new Duration(TimeSpan.FromSeconds(1)));
            tg = new TransformGroup();
            tg.Children.Add(ttx);
            tg.Children.Add(tty);

            dax.Completed += new EventHandler(TranscriptaseMoveEmp);

            transcriptase.RenderTransform = tg;
            ttx.BeginAnimation(TranslateTransform.XProperty, dax);
            tty.BeginAnimation(TranslateTransform.YProperty, day);

        }

        private void TranscriptaseMoveEmp(object sender, EventArgs e)
        {
            //Canvas.SetLeft(transcriptase, currEmp.X);
            //Canvas.SetTop(transcriptase, currEmp.Y);

            int empsChosen = employeesChosenList.Count();
            BitmapImage img;
            try
            {
                img = new BitmapImage(new Uri(currEmp.PhotoPath, UriKind.RelativeOrAbsolute));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                img = new BitmapImage(new Uri(@"images/中国结.jpg", UriKind.RelativeOrAbsolute));
            }
            (currEmp.Grid.Children[1] as Ellipse).Fill = new ImageBrush(img);

            currEmp.Grid.Children[0].Visibility = Visibility.Hidden;//circle
            currEmp.Grid.Children[1].Visibility = Visibility.Visible;//ellipse
            currEmp.Grid.Children[2].Visibility = Visibility.Visible;//textbox

            double deltaX = chosenEmpsXCoords[empsChosen] - currEmp.X;
            double deltaY;
            if (empsChosen < empsPerRound / 2)
                deltaY = chosenEmpsYCoord[0] - currEmp.Y;
            else
                deltaY = chosenEmpsYCoord[1] - currEmp.Y;


            TranslateTransform ttx = new TranslateTransform();
            TranslateTransform tty = new TranslateTransform();
            DoubleAnimation dax = new DoubleAnimation();
            DoubleAnimation day = new DoubleAnimation();
            //dax = new DoubleAnimation(currEmp.X, chosenEmpsXCoords[empsChosen], new Duration(TimeSpan.FromSeconds(1)));
            dax = new DoubleAnimation(deltaX, new Duration(TimeSpan.FromSeconds(1)));
            //if (empsChosen < empsPerRound / 2)
            //    day = new DoubleAnimation(currEmp.Y, chosenEmpsYCoord[0], new Duration(TimeSpan.FromSeconds(1)));
            //else
            //    day = new DoubleAnimation(currEmp.Y, chosenEmpsYCoord[1], new Duration(TimeSpan.FromSeconds(1)));
            day = new DoubleAnimation(deltaY, new Duration(TimeSpan.FromSeconds(1)));
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(ttx);
            tg.Children.Add(tty);

            dax.Completed += new EventHandler(TranscriptaseGrabEmp);

            currEmp.Grid.RenderTransform = tg;
            transcriptase.RenderTransform = tg;
            ttx.BeginAnimation(TranslateTransform.XProperty, dax);
            tty.BeginAnimation(TranslateTransform.YProperty, day);

            employeesChosenList.Add(currEmp);
            employeesList.Remove(currEmp);
        }
        */
    }
}
