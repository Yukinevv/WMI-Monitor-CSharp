using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZarzadzanieUsluga.Pages;

namespace ZarzadzanieUsluga.ChartPages
{
    /// <summary>
    /// Logika interakcji dla klasy ChartProcessor.xaml
    /// </summary>
    public partial class ChartProcessor : Page
    {
        private List<int> processorPercentageUsage = new List<int>();
        private List<int> processorPrivilegedTimes = new List<int>();
        private List<int> processorInterruptTime = new List<int>();
        private List<int> processorDPCTime = new List<int>();

        public ChartProcessor()
        {
            InitializeComponent();

            ProcessorChart.LegendLocation = LegendLocation.Right;
        }

        public void SetChart()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                processorPercentageUsage.Add(WMIMonitorPage.HardwareData.ProcessorPercentageUsage);
                processorPrivilegedTimes.Add(WMIMonitorPage.HardwareData.ProcessorPrivilegedTime);
                processorInterruptTime.Add(WMIMonitorPage.HardwareData.ProcessorInterruptTime);
                processorDPCTime.Add(WMIMonitorPage.HardwareData.ProcessorDPCTime);

                ProcessorChart.Series.Clear();

                if (MainWindow.configurationPage.ProcessorPercentageUsageCheckbox.IsChecked == true)
                    ProcessorChart.Series.Add(new LineSeries
                    {
                        Title = "Processor Persentage Usage",
                        Values = new ChartValues<int>(processorPercentageUsage)
                    });
                if (MainWindow.configurationPage.ProcessorPrivilegedTimeCheckbox.IsChecked == true)
                    ProcessorChart.Series.Add(new LineSeries
                    {
                        Title = "Processor Privileged Times",
                        Values = new ChartValues<int>(processorPrivilegedTimes)
                    });
                if (MainWindow.configurationPage.ProcessorInterruptTimeCheckbox.IsChecked == true)
                    ProcessorChart.Series.Add(new LineSeries
                    {
                        Title = "Processor Interrupt Time",
                        Values = new ChartValues<int>(processorInterruptTime)
                    });
                if (MainWindow.configurationPage.ProcessorDPCTimeCheckbox.IsChecked == true)
                    ProcessorChart.Series.Add(new LineSeries
                    {
                        Title = "Processor DPC Time",
                        Values = new ChartValues<int>(processorDPCTime)
                    });

                if (processorPercentageUsage.Count > 10 || processorPrivilegedTimes.Count > 10 || processorInterruptTime.Count > 10 ||
                    processorDPCTime.Count > 10)
                {
                    processorPercentageUsage.Clear();
                    processorPrivilegedTimes.Clear();
                    processorInterruptTime.Clear();
                    processorDPCTime.Clear();
                }
            }));
        }
    }
}
