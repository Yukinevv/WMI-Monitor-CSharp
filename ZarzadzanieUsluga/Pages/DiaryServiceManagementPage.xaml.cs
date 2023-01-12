using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ZarzadzanieUsluga.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy DiaryServiceManagementPage.xaml
    /// </summary>
    public partial class DiaryServiceManagementPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

        private ServiceController usluga;
        private ServiceControllerStatus stanUslugiController;

        private EventLog dziennik;

        public DiaryServiceManagementPage()
        {
            InitializeComponent();

            usluga = new ServiceController("UslugaWMIb");
            StanTextBlock.Text = "Service status: Service not Installed";

            // Dostepnosc przyciskow w zaleznosci od stanu uslugi
            if (stanUslugiController == ServiceControllerStatus.Running)
            {
                StopButton.IsEnabled = true;
                StartButton.IsEnabled = false;
            }
            if (stanUslugiController == ServiceControllerStatus.Stopped)
            {
                StartButton.IsEnabled = true;
                StopButton.IsEnabled = false;
            }

            dziennik = new EventLog("LogWMI");

            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GetTime();

            try
            {
                usluga.Refresh();
                ServiceControllerStatus nowyStatus = usluga.Status;

                if (nowyStatus != stanUslugiController)
                {
                    stanUslugiController = nowyStatus;
                    StanTextBlock.Text = "Service status: " + nowyStatus.ToString();

                    StartButton.IsEnabled = nowyStatus == ServiceControllerStatus.Stopped;
                    StopButton.IsEnabled = nowyStatus == ServiceControllerStatus.Running;
                }
            }
            catch (Exception)
            {
            }
        }

        private void GetTime()
        {
            DateTime date = DateTime.Now;
            TimeTextBlock.Text = date.ToLongTimeString() + " | " + date.ToLongDateString();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                usluga.Start();

                StartButton.IsEnabled = false;
                await Task.Factory.StartNew(() =>
                {
                    usluga.WaitForStatus(ServiceControllerStatus.Running);
                });

                StanTextBlock.Text = "Service status: " + usluga.Status.ToString();
                StopButton.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                usluga.Stop();

                StopButton.IsEnabled = false;
                await Task.Factory.StartNew(() =>
                {
                    usluga.WaitForStatus(ServiceControllerStatus.Stopped);
                });

                StanTextBlock.Text = "Service status: " + usluga.Status.ToString();
                StartButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            DiaryListView.Items.Clear();

            foreach (EventLogEntry wpis in dziennik.Entries)
            {
                LogEntry wpisDziennika = new LogEntry()
                {
                    Title = wpis.Message,
                    Time = wpis.TimeWritten
                };
                DiaryListView.Items.Add(wpisDziennika);
            }
        }

        private void DeleteEntriesButton_Click(object sender, RoutedEventArgs e)
        {
            DiaryListView.Items.Clear();
        }
    }
}
