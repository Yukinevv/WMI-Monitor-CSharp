using System;
using System.ServiceProcess;
using System.Windows;
using ZarzadzanieUsluga.Pages;

namespace ZarzadzanieUsluga
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ConfigurationPage configurationPage = new ConfigurationPage();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ServiceController usluga = new ServiceController("UslugaWMIb");
                ServiceControllerStatus stanUslugiController = usluga.Status;

                if (stanUslugiController == ServiceControllerStatus.Running)
                {
                    Main.Content = new WMIMonitorPage();
                }
                if (stanUslugiController == ServiceControllerStatus.Stopped)
                {
                    Main.Content = new DiaryServiceManagementPage();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Main.Content = new DiaryServiceManagementPage();
            }
        }

        private void WMIMonitorPageButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new WMIMonitorPage();
        }

        private void ConfigurationPageButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = configurationPage;
        }

        private void DiaryManagementPageButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DiaryServiceManagementPage();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
