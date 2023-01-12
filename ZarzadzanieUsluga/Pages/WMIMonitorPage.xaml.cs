using Biblioteka;
using Newtonsoft.Json;
using System;
using System.Management;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ZarzadzanieUsluga.ChartPages;

namespace ZarzadzanieUsluga.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy CPUMonitorPage.xaml
    /// </summary>
    public partial class WMIMonitorPage : Page
    {
        public static HardwareInfo HardwareData { get; set; } = new HardwareInfo(); // przychodzi z uslugi przez WCF

        private bool polaczono = false;

        private IMessageService Proxy = null;

        private ChartProcessor chartProcessor = new ChartProcessor();
        private ChartMemory chartMemory = new ChartMemory();
        private ChartDisk chartDisk = new ChartDisk();
        private ChartSystem chartSystem = new ChartSystem();

        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string GetMessage();
        }

        public WMIMonitorPage()
        {
            this.InitializeComponent();

            ChartFrame.Content = chartProcessor;

            // Jezeli usluga dziala to ustawiam dane do diagramow i wykresow
            try
            {
                ServiceController usluga = new ServiceController("UslugaWMIb");
                ServiceControllerStatus stanUslugiController = usluga.Status;
                if (stanUslugiController == ServiceControllerStatus.Running)
                {
                    this.SetHardwareData();
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetHardwareData()
        {
            if (polaczono == false)
            {
                string uri = "net.tcp://localhost:6565/MessageService";
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                var channel = new ChannelFactory<IMessageService>(binding);
                var endPoint = new EndpointAddress(uri);
                Proxy = channel.CreateChannel(endPoint);

                polaczono = true;
            }

            string result;

            ManagementObjectSearcher search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            long ramMBytes = 0;
            foreach (ManagementObject mObject in search.Get())
            {
                ramMBytes = Convert.ToInt64(mObject["TotalPhysicalMemory"]) / 1048576;
            }

            Task.Factory.StartNew(() =>
            {
                while (1 == 1)
                {
                    result = Proxy?.GetMessage();
                    if (result != null)
                    {
                        HardwareData = JsonConvert.DeserializeObject<HardwareInfo>(result);

                        // Ustawiam wartosci do Progressbar'ow
                        CircularProgressBar.SetProgress(HardwareData.ProcessorPercentageUsage, 100);
                        CircularProgressBar2.SetProgress(ramMBytes - HardwareData.MemoryAvaibleMBytes, ramMBytes);
                        CircularProgressBar3.SetProgress(HardwareData.PhysicalPercentageDiskTime, 100);
                        CircularProgressBar4.SetProgress(HardwareData.MemoryCommitedBytesInUse, 100);

                        chartProcessor.SetChart();
                        chartMemory.SetChart();
                        chartDisk.SetChart();
                        chartSystem.SetChart();

                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            MainWindow.configurationPage.InfoListBox.Items.Insert(0, MainWindow.configurationPage.GetHardwareDataAsString(HardwareData));
                            if (MainWindow.configurationPage.InfoListBox.Items.Count > 0)
                            {
                                MainWindow.configurationPage.InfoListBox.ScrollIntoView(MainWindow.configurationPage.InfoListBox.Items[0]);
                            }
                        }));
                    }
                    Thread.Sleep(3000);
                }
            });
        }

        private void ProcessorChartButton_Click(object sender, RoutedEventArgs e)
        {
            ChartFrame.Content = chartProcessor;
        }

        private void MemoryChartButton_Click(object sender, RoutedEventArgs e)
        {
            ChartFrame.Content = chartMemory;
        }

        private void DiskChartButton_Click(object sender, RoutedEventArgs e)
        {
            ChartFrame.Content = chartDisk;
        }

        private void SystemChartButton_Click(object sender, RoutedEventArgs e)
        {
            ChartFrame.Content = chartSystem;
        }
    }
}
