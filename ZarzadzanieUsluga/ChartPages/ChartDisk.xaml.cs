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
    /// Logika interakcji dla klasy ChartDisk.xaml
    /// </summary>
    public partial class ChartDisk : Page
    {
        private List<int> pagingFileUsage = new List<int>();
        private List<int> localDiskPercentFreeSpace = new List<int>();
        private List<int> physicalAvgDiskQueueLength = new List<int>();
        private List<int> physicalDiskReadBytesSec = new List<int>();
        private List<int> physicalDiskWriteBytesSec = new List<int>();
        private List<int> physicalAvgDiskReadSec = new List<int>();
        private List<int> physicalAvgDiskWriteSec = new List<int>();
        private List<int> physicalPercentageDiskTime = new List<int>();

        public ChartDisk()
        {
            InitializeComponent();

            DiskChart.LegendLocation = LegendLocation.Right;
        }

        public void SetChart()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                pagingFileUsage.Add(WMIMonitorPage.HardwareData.PagingFileUsage);
                localDiskPercentFreeSpace.Add(WMIMonitorPage.HardwareData.LogicalDiskPercentFreeSpace);
                physicalAvgDiskQueueLength.Add(WMIMonitorPage.HardwareData.PhysicalAvgDiskQueueLength);
                physicalDiskReadBytesSec.Add(WMIMonitorPage.HardwareData.PhysicalDiskReadBytesSec);
                physicalDiskWriteBytesSec.Add(WMIMonitorPage.HardwareData.PhysicalDiskWriteBytesSec);
                physicalAvgDiskReadSec.Add(WMIMonitorPage.HardwareData.PhysicalAvgDiskReadSec);
                physicalAvgDiskWriteSec.Add(WMIMonitorPage.HardwareData.PhysicalAvgDiskWriteSec);
                physicalPercentageDiskTime.Add(WMIMonitorPage.HardwareData.PhysicalPercentageDiskTime);

                DiskChart.Series.Clear();

                if (MainWindow.configurationPage.PagingFileUsageCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Paging File Usage",
                        Values = new ChartValues<int>(pagingFileUsage)
                    });
                if (MainWindow.configurationPage.LogicalDiskPercentageFreeSpaceCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Localdisk Percentage Free Space",
                        Values = new ChartValues<int>(localDiskPercentFreeSpace)
                    });
                if (MainWindow.configurationPage.PhysicalAvgDiskQueueLengthCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Avg Disk Queue Length",
                        Values = new ChartValues<int>(physicalAvgDiskQueueLength)
                    });
                if (MainWindow.configurationPage.PhysicalDiskReadBytesSecCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Disk Read Bytes Sec",
                        Values = new ChartValues<int>(physicalDiskReadBytesSec)
                    });
                if (MainWindow.configurationPage.PhysicalDiskWriteBytesSecCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Disk Write Bytes Sec",
                        Values = new ChartValues<int>(physicalDiskWriteBytesSec)
                    });
                if (MainWindow.configurationPage.PhysicalAvgDiskReadSecCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Avg Disk Read Sec",
                        Values = new ChartValues<int>(physicalAvgDiskReadSec)
                    });
                if (MainWindow.configurationPage.PhysicalAvgDiskWriteSecCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Avg Disk Write Sec",
                        Values = new ChartValues<int>(physicalAvgDiskWriteSec)
                    });
                if (MainWindow.configurationPage.PhysicalPercentageDiskTimeCheckbox.IsChecked == true)
                    DiskChart.Series.Add(new LineSeries
                    {
                        Title = "Physical Percentage Disk Time",
                        Values = new ChartValues<int>(physicalPercentageDiskTime)
                    });

                if (pagingFileUsage.Count > 10 || localDiskPercentFreeSpace.Count > 10 || physicalAvgDiskQueueLength.Count > 10 ||
                    physicalDiskReadBytesSec.Count > 10 || physicalDiskWriteBytesSec.Count > 10 || physicalAvgDiskReadSec.Count > 10 ||
                    physicalAvgDiskWriteSec.Count > 10 || physicalPercentageDiskTime.Count > 10)
                {
                    pagingFileUsage.Clear();
                    localDiskPercentFreeSpace.Clear();
                    physicalAvgDiskQueueLength.Clear();
                    physicalDiskReadBytesSec.Clear();
                    physicalDiskWriteBytesSec.Clear();
                    physicalAvgDiskReadSec.Clear();
                    physicalAvgDiskWriteSec.Clear();
                    physicalPercentageDiskTime.Clear();
                }
            }));
        }
    }
}
