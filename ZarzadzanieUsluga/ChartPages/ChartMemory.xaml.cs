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
    /// Logika interakcji dla klasy ChartMemory.xaml
    /// </summary>
    public partial class ChartMemory : Page
    {
        private List<int> memoryAvaibleMBytes = new List<int>();
        private List<long> memoryCommitedBytes = new List<long>();
        private List<long> memoryCommitLimit = new List<long>();
        private List<int> memoryCommitedBytesInUse = new List<int>();
        private List<int> memoryPoolPagedBytes = new List<int>();
        private List<int> memoryPoolNonPagedBytes = new List<int>();
        private List<int> memoryCachedBytes = new List<int>();

        public ChartMemory()
        {
            InitializeComponent();

            MemoryChart.LegendLocation = LegendLocation.Right;
        }

        public void SetChart()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                memoryAvaibleMBytes.Add(WMIMonitorPage.HardwareData.MemoryAvaibleMBytes);
                memoryCommitedBytes.Add(WMIMonitorPage.HardwareData.MemoryCommitedBytes);
                memoryCommitLimit.Add(WMIMonitorPage.HardwareData.MemoryCommitLimit);
                memoryCommitedBytesInUse.Add(WMIMonitorPage.HardwareData.MemoryCommitedBytesInUse);
                memoryPoolPagedBytes.Add(WMIMonitorPage.HardwareData.MemoryPoolPagedBytes);
                memoryPoolNonPagedBytes.Add(WMIMonitorPage.HardwareData.MemoryPoolNonpagedBytes);
                memoryCachedBytes.Add(WMIMonitorPage.HardwareData.MemoryCachedBytes);

                MemoryChart.Series.Clear();

                if (MainWindow.configurationPage.MemoryAvaibleMBytesCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Avaible MBytes",
                        Values = new ChartValues<int>(memoryAvaibleMBytes)
                    });
                if (MainWindow.configurationPage.MemoryCommitedBytesCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Commmited Bytes",
                        Values = new ChartValues<long>(memoryCommitedBytes)
                    });
                if (MainWindow.configurationPage.MemoryCommitLimitCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Commit Limit",
                        Values = new ChartValues<long>(memoryCommitLimit)
                    });
                if (MainWindow.configurationPage.MemoryCommitedBytesInUseCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Commited Bytes In Use",
                        Values = new ChartValues<int>(memoryCommitedBytesInUse)
                    });
                if (MainWindow.configurationPage.MemoryPoolPagedBytesCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Pool Paged Bytes",
                        Values = new ChartValues<int>(memoryPoolPagedBytes)
                    });
                if (MainWindow.configurationPage.MemoryPoolNonPagedBytesCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Pool Non Paged Bytes",
                        Values = new ChartValues<int>(memoryPoolNonPagedBytes)
                    });
                if (MainWindow.configurationPage.MemoryCachedBytesCheckbox.IsChecked == true)
                    MemoryChart.Series.Add(new LineSeries
                    {
                        Title = "Memory Cached Bytes",
                        Values = new ChartValues<int>(memoryCachedBytes)
                    });

                if (memoryAvaibleMBytes.Count > 10 || memoryCommitedBytes.Count > 10 || memoryCommitLimit.Count > 10 ||
                    memoryCommitedBytesInUse.Count > 10 || memoryPoolPagedBytes.Count > 10 || memoryPoolNonPagedBytes.Count > 10 ||
                    memoryCachedBytes.Count > 10)
                {
                    memoryAvaibleMBytes.Clear();
                    memoryCommitedBytes.Clear();
                    memoryCommitLimit.Clear();
                    memoryCommitedBytesInUse.Clear();
                    memoryPoolPagedBytes.Clear();
                    memoryPoolNonPagedBytes.Clear();
                    memoryCachedBytes.Clear();
                }
            }));
        }
    }
}
