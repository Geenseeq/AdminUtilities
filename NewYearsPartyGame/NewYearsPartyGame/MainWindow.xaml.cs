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
using System.Windows.Threading;

namespace NewYearsPartyGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer bgmMP = new MediaPlayer();
        private MediaPlayer actionMP = new MediaPlayer();
        private int empsPerRound = 20;
        private int totalCountdownTime = 15;
        private string[] bgmFileNames = { "audio/bgm_0.mp3", "audio/bgm_1.mp3", "audio/bgm_2.mp3" };
        private int currentBgmIndex = 0;
        Random rnd = new Random();

        DispatcherTimer cycleTimer = new DispatcherTimer();
        DispatcherTimer runningTimer = new DispatcherTimer();
        private bool inActionAnimation = false;
        private bool inCycleAnimation = false;

        private List<Employee> employeesList = new List<Employee>();
        private List<Employee> displayedEmpList = new List<Employee>();
        private List<Grid> employeesChosenGridList = new List<Grid>();
        Employee currEmp = null;
        private double photoWidth = 1;
        private double photoHeight = 1;
        private Duration translateDuration = new Duration(new TimeSpan(0, 0, 0, 5, 0));
        private List<double> chosenEmpsXCoords = new List<double>();
        private double[] chosenEmpsYCoords;

        public MainWindow()
        {
            InitializeComponent();


            actionArea.Loaded += new RoutedEventHandler(ActionGrid_Loaded);

        }

        private void LoadEmployees()
        {
            DirectoryInfo d = new DirectoryInfo(@"photos");
            FileInfo[] files = d.GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                Employee emp = new Employee(file.Name.Split('.')[0], file.FullName);
                employeesList.Add(emp);
            }
        }

        private void ActionGrid_Loaded(object sender, EventArgs e)
        {
            photoWidth = actionArea.ActualWidth / 9;
            photoHeight = actionArea.ActualHeight / 4;
            LoadEmployees();

            InitializeVisuals();

            timerTextBox.Text = "";
            timerTextBox.FontSize = 100;
            timerTextBox.FontWeight = FontWeights.ExtraBold;
            timerTextBox.Width = photoWidth;
            timerTextBox.Height = photoHeight;
            timerTextBox.TextAlignment = TextAlignment.Center;

            bgmMP.MediaEnded += (o, args) =>
            {
                bgmMP.Open(new Uri(bgmFileNames[currentBgmIndex], UriKind.RelativeOrAbsolute));
                currentBgmIndex++;
                if (currentBgmIndex >= bgmFileNames.Count())
                    currentBgmIndex = 0;
                bgmMP.Play();
            };
            //bgmMP.MediaOpened += new EventHandler(CycleEmployeePhotos);
            bgmMP.Open(new Uri(bgmFileNames[currentBgmIndex], UriKind.RelativeOrAbsolute));
            currentBgmIndex++;
            bgmMP.Play();
        }

        private void CycleEmployeePhotos(object sender, EventArgs e)
        {
            displayedEmpList.Clear();
            while (displayedEmpList.Count() < empsPerRound)
            {
                int randomIndex = rnd.Next(employeesList.Count());
                currEmp = employeesList[randomIndex];
                if (!displayedEmpList.Contains(currEmp))
                    displayedEmpList.Add(currEmp);
            }

            for (int i = 0; i < empsPerRound; i++)
            {

                currEmp = displayedEmpList[i];
                (employeesChosenGridList[i].Children[0] as Image).Source = currEmp.Photo;
                (employeesChosenGridList[i].Children[1] as TextBox).Text = currEmp.Name;
                employeesChosenGridList[i].Visibility = Visibility.Visible;
            }
        }


        private void InitializeVisuals()
        {
            double xMargin = actionArea.ActualWidth / 23;
            double xSeparation = xMargin / 2;
            double ySeparation = xMargin / 2;

            //make three rows of seven pics each; bottom right one is for timer
            for (int i = 0; i < 7; i++)
                chosenEmpsXCoords.Add(xMargin + (photoWidth + xSeparation) * i);
            chosenEmpsYCoords = new Double[] { ySeparation, ySeparation + photoHeight + ySeparation, ySeparation + (photoHeight + ySeparation) * 2 };


            employeesChosenGridList = new List<Grid>();
            foreach (Double y in chosenEmpsYCoords)
            {
                foreach (Double x in chosenEmpsXCoords)
                {
                    if (chosenEmpsXCoords.IndexOf(x) == 6 && chosenEmpsYCoords.ElementAt(2) == y)
                    {
                        timerTextBox.Margin = new Thickness(x, y, 0, 0);
                        continue;
                    }
                    Grid _grid = new Grid();
                    Image photo = new Image();
                    photo.Name = "photo";
                    photo.Width = photoWidth * .93;
                    photo.Height = photoHeight;
                    photo.HorizontalAlignment = HorizontalAlignment.Center;
                    photo.VerticalAlignment = VerticalAlignment.Top;
                    _grid.Children.Add(photo);


                    TextBox txbx = new TextBox();
                    txbx.Name = "name";
                    txbx.Height = photoHeight / 6;
                    txbx.Width = photoWidth;
                    txbx.FontSize = 20;
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
                    _grid.Margin = new Thickness(x, y, 0, 0);
                    actionArea.Children.Add(_grid);
                    employeesChosenGridList.Add(_grid);
                }
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            if (inActionAnimation || employeesList.Count <= 0)
                return;

            slider.Visibility = Visibility.Hidden;
            inActionAnimation = true;
            cycleTimer.Stop();

            foreach (Employee emp in displayedEmpList)
                employeesList.Remove(emp);

            int _time = totalCountdownTime;
            timerTextBox.Text = _time.ToString();

            runningTimer = new DispatcherTimer();
            runningTimer.Interval = TimeSpan.FromSeconds(1);
            runningTimer.Tick += (o, args) =>
              {
                  timerTextBox.Text = _time.ToString();
                  if (_time <= 0)
                  {
                      runningTimer.Stop();
                      //cycleTimer.Start();
                      timerTextBox.Text = "";
                      inCycleAnimation = false;
                      inActionAnimation = false;
                      actionMP.Stop();
                      bgmMP.Play();
                      slider.Visibility = Visibility.Visible;
                  }
                  _time--;
              };

            runningTimer.Start();

            bgmMP.Pause();
            actionMP.Open(new Uri(@"audio/stadium.mp3", UriKind.RelativeOrAbsolute));
            actionMP.Play();

            actionMP.MediaEnded += (o, args) =>
            {
                bgmMP.Play();
            };
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (inCycleAnimation || inActionAnimation || employeesList.Count <= 0)
                return;

            if (employeesList.Count() < empsPerRound)
            {
                empsPerRound = employeesList.Count();
            }
            for (int i = empsPerRound; i < 20; i++)
                employeesChosenGridList[i].Visibility = Visibility.Hidden;

            for (int i = 0; i < empsPerRound; i++)
                employeesChosenGridList[i].Visibility = Visibility.Visible;


            slider.Visibility = Visibility.Hidden;
            inCycleAnimation = true;
            cycleTimer = new DispatcherTimer(DispatcherPriority.Render);
            cycleTimer.Interval = TimeSpan.FromSeconds(.1);
            cycleTimer.Tick += CycleEmployeePhotos;
            cycleTimer.Start();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            empsPerRound = (int) slider.Value;
        }

        private void muteButton_Click(object sender, RoutedEventArgs e)
        {
            bgmMP.IsMuted = !bgmMP.IsMuted;
            actionMP.IsMuted = !actionMP.IsMuted;
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.WindowState = WindowState.Minimized;
        }
    }
}
