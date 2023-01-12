using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZarzadzanieUsluga.Pages;

namespace ZarzadzanieUsluga.ChartPages
{
    /// <summary>
    /// Logika interakcji dla klasy ChartSystem.xaml
    /// </summary>
    public partial class ChartSystem : Page
    {
        private List<int> processHandleCount = new List<int>();
        private List<int> processThreadCount = new List<int>();
        private List<int> systemContextSwitchesSec = new List<int>();
        private List<int> systemCallSec = new List<int>();
        private List<int> systemProcessorQueueLength = new List<int>();

        public ChartSystem()
        {
            InitializeComponent();

            SystemChart.LegendLocation = LegendLocation.Right;
        }

        public void SetChart()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                processHandleCount.Add(WMIMonitorPage.HardwareData.ProcessHandleCount);
                processThreadCount.Add(WMIMonitorPage.HardwareData.ProcessThreadCount);
                systemContextSwitchesSec.Add(WMIMonitorPage.HardwareData.SystemContextSwitchesSec);
                systemCallSec.Add(WMIMonitorPage.HardwareData.SystemCallSec);
                systemProcessorQueueLength.Add(WMIMonitorPage.HardwareData.SystemProcessorQueueLength);

                SystemChart.Series.Clear();

                if (MainWindow.configurationPage.ProcessHandleCountCheckbox.IsChecked == true)
                    SystemChart.Series.Add(new LineSeries
                    {
                        Title = "Process Handle Count",
                        Values = new ChartValues<int>(processHandleCount)
                    });
                if (MainWindow.configurationPage.ProcessThreadCountCheckbox.IsChecked == true)
                    SystemChart.Series.Add(new LineSeries
                    {
                        Title = "Process Thread Count",
                        Values = new ChartValues<int>(processThreadCount)
                    });
                if (MainWindow.configurationPage.SystemContextSwitchesSecCheckbox.IsChecked == true)
                    SystemChart.Series.Add(new LineSeries
                    {
                        Title = "System Context Switches Sec",
                        Values = new ChartValues<int>(systemContextSwitchesSec)
                    });
                if (MainWindow.configurationPage.SystemCallSecCheckbox.IsChecked == true)
                    SystemChart.Series.Add(new LineSeries
                    {
                        Title = "System Call Sec",
                        Values = new ChartValues<int>(systemCallSec)
                    });
                if (MainWindow.configurationPage.SystemProcessorQueueLengthCheckbox.IsChecked == true)
                    SystemChart.Series.Add(new LineSeries
                    {
                        Title = "System Processor Queue Length",
                        Values = new ChartValues<int>(systemProcessorQueueLength)
                    });

                if (processHandleCount.Count > 10 || processThreadCount.Count > 10 || systemContextSwitchesSec.Count > 10 ||
                    systemCallSec.Count > 10 || systemProcessorQueueLength.Count > 10)
                {
                    processHandleCount.Clear();
                    processThreadCount.Clear();
                    systemContextSwitchesSec.Clear();
                    systemCallSec.Clear();
                    systemProcessorQueueLength.Clear();
                }
            }));
        }
    }
}
