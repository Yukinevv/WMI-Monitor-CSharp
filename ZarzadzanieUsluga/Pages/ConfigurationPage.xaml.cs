using Biblioteka;
using System.Windows;
using System.Windows.Controls;

namespace ZarzadzanieUsluga.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy BatteryStatusMonitorPage.xaml
    /// </summary>
    public partial class ConfigurationPage : Page
    {
        public ConfigurationPage()
        {
            InitializeComponent();
        }

        public string GetHardwareDataAsString(HardwareInfo hardwareInfo)
        {
            string hardWareData = "";
            hardWareData += ProcessorPercentageUsageCheckbox.IsChecked == true ? "Processor Persentage Usage:                     " + hardwareInfo.ProcessorPercentageUsage.ToString() + " %\n" : "";
            hardWareData += ProcessorPrivilegedTimeCheckbox.IsChecked == true ? "Processor Privileged Time:                         " + hardwareInfo.ProcessorPrivilegedTime.ToString() + " %\n" : "";
            hardWareData += ProcessorInterruptTimeCheckbox.IsChecked == true ? "Processor Interrupt Time:                           " + hardwareInfo.ProcessorInterruptTime.ToString() + " \n" : "";
            hardWareData += ProcessorDPCTimeCheckbox.IsChecked == true ? "Processor DPC Time:                                  " + hardwareInfo.ProcessorDPCTime.ToString() + " %\n" : "";
            hardWareData += MemoryAvaibleMBytesCheckbox.IsChecked == true ? "Memory Avaible MBytes:                           " + hardwareInfo.MemoryAvaibleMBytes.ToString() + " \n" : "";
            hardWareData += MemoryCommitedBytesCheckbox.IsChecked == true ? "Memory Commited Bytes:                         " + hardwareInfo.MemoryCommitedBytes.ToString() + " \n" : "";
            hardWareData += MemoryCommitLimitCheckbox.IsChecked == true ? "Memory Commit Limit:                              " + hardwareInfo.MemoryCommitedBytes.ToString() + " \n" : "";
            hardWareData += MemoryCommitedBytesInUseCheckbox.IsChecked == true ? "Memory Commited Bytes in Use:              " + hardwareInfo.MemoryCommitedBytesInUse.ToString() + " %\n" : "";
            hardWareData += MemoryPoolPagedBytesCheckbox.IsChecked == true ? "Memory Pool Paged Bytes:                       " + hardwareInfo.MemoryPoolPagedBytes.ToString() + " \n" : "";
            hardWareData += MemoryPoolNonPagedBytesCheckbox.IsChecked == true ? "Memory Pool Nonpaged Bytes:                " + hardwareInfo.MemoryPoolNonpagedBytes.ToString() + " \n" : "";
            hardWareData += MemoryCachedBytesCheckbox.IsChecked == true ? "Memory Cached Bytes:                             " + hardwareInfo.MemoryCachedBytes.ToString() + " \n" : "";
            hardWareData += PagingFileUsageCheckbox.IsChecked == true ? "Paging File Usage:                                    " + hardwareInfo.PagingFileUsage.ToString() + " %\n" : "";
            hardWareData += LogicalDiskPercentageFreeSpaceCheckbox.IsChecked == true ? "Logical Disk Percent Free Space:              " + hardwareInfo.LogicalDiskPercentFreeSpace.ToString() + " %\n" : "";
            hardWareData += PhysicalAvgDiskQueueLengthCheckbox.IsChecked == true ? "Physical Disk Avg Disk Queue Length:      " + hardwareInfo.PhysicalAvgDiskQueueLength.ToString() + " \n" : "";
            hardWareData += PhysicalDiskReadBytesSecCheckbox.IsChecked == true ? "Physical Disk Read Bytes Sec:                   " + hardwareInfo.PhysicalDiskReadBytesSec.ToString() + " \n" : "";
            hardWareData += PhysicalDiskWriteBytesSecCheckbox.IsChecked == true ? "Physical Disk Write Bytes Sec:                  " + hardwareInfo.PhysicalDiskWriteBytesSec.ToString() + " \n" : "";
            hardWareData += PhysicalAvgDiskReadSecCheckbox.IsChecked == true ? "Physical Disk Avg Disk Read Sec:              " + hardwareInfo.PhysicalAvgDiskReadSec.ToString() + " \n" : "";
            hardWareData += PhysicalAvgDiskWriteSecCheckbox.IsChecked == true ? "Physical Disk Avg Disk Write Sec:             " + hardwareInfo.PhysicalAvgDiskWriteSec.ToString() + " \n" : "";
            hardWareData += PhysicalPercentageDiskTimeCheckbox.IsChecked == true ? "Physical Disk Percentage Disk Time:         " + hardwareInfo.PhysicalPercentageDiskTime.ToString() + " %\n" : "";
            hardWareData += ProcessHandleCountCheckbox.IsChecked == true ? "Process Handle Count:                             " + hardwareInfo.ProcessHandleCount.ToString() + " \n" : "";
            hardWareData += ProcessThreadCountCheckbox.IsChecked == true ? "Process Thread Count:                             " + hardwareInfo.ProcessThreadCount.ToString() + " \n" : "";
            hardWareData += SystemContextSwitchesSecCheckbox.IsChecked == true ? "System Context Switches Sec:                  " + hardwareInfo.SystemContextSwitchesSec.ToString() + " \n" : "";
            hardWareData += SystemCallSecCheckbox.IsChecked == true ? "System Call Sec:                                       " + hardwareInfo.SystemCallSec.ToString() + " \n" : "";
            hardWareData += SystemProcessorQueueLengthCheckbox.IsChecked == true ? "System Processor Queue Length:            " + hardwareInfo.SystemCallSec.ToString() + " \n" : "";
            return hardWareData;
        }

        private void WyczyscButton_Click(object sender, RoutedEventArgs e)
        {
            this.InfoListBox.Items.Clear();
        }

        private void OdznaczWszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessorPercentageUsageCheckbox.IsChecked = false;
            ProcessorPrivilegedTimeCheckbox.IsChecked = false;
            ProcessorInterruptTimeCheckbox.IsChecked = false;
            ProcessorDPCTimeCheckbox.IsChecked = false;
            MemoryAvaibleMBytesCheckbox.IsChecked = false;
            MemoryCommitedBytesCheckbox.IsChecked = false;
            MemoryCommitLimitCheckbox.IsChecked = false;
            MemoryCommitedBytesInUseCheckbox.IsChecked = false;
            MemoryPoolPagedBytesCheckbox.IsChecked = false;
            MemoryPoolNonPagedBytesCheckbox.IsChecked = false;
            MemoryCachedBytesCheckbox.IsChecked = false;
            PagingFileUsageCheckbox.IsChecked = false;
            LogicalDiskPercentageFreeSpaceCheckbox.IsChecked = false;
            PhysicalAvgDiskQueueLengthCheckbox.IsChecked = false;
            PhysicalDiskReadBytesSecCheckbox.IsChecked = false;
            PhysicalDiskWriteBytesSecCheckbox.IsChecked = false;
            PhysicalAvgDiskReadSecCheckbox.IsChecked = false;
            PhysicalAvgDiskWriteSecCheckbox.IsChecked = false;
            PhysicalPercentageDiskTimeCheckbox.IsChecked = false;
            ProcessHandleCountCheckbox.IsChecked = false;
            ProcessThreadCountCheckbox.IsChecked = false;
            SystemContextSwitchesSecCheckbox.IsChecked = false;
            SystemCallSecCheckbox.IsChecked = false;
            SystemProcessorQueueLengthCheckbox.IsChecked = false;
        }

        private void ZaznaczWszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessorPercentageUsageCheckbox.IsChecked = true;
            ProcessorPrivilegedTimeCheckbox.IsChecked = true;
            ProcessorInterruptTimeCheckbox.IsChecked = true;
            ProcessorDPCTimeCheckbox.IsChecked = true;
            MemoryAvaibleMBytesCheckbox.IsChecked = true;
            MemoryCommitedBytesCheckbox.IsChecked = true;
            MemoryCommitLimitCheckbox.IsChecked = true;
            MemoryCommitedBytesInUseCheckbox.IsChecked = true;
            MemoryPoolPagedBytesCheckbox.IsChecked = true;
            MemoryPoolNonPagedBytesCheckbox.IsChecked = true;
            MemoryCachedBytesCheckbox.IsChecked = true;
            PagingFileUsageCheckbox.IsChecked = true;
            LogicalDiskPercentageFreeSpaceCheckbox.IsChecked = true;
            PhysicalAvgDiskQueueLengthCheckbox.IsChecked = true;
            PhysicalDiskReadBytesSecCheckbox.IsChecked = true;
            PhysicalDiskWriteBytesSecCheckbox.IsChecked = true;
            PhysicalAvgDiskReadSecCheckbox.IsChecked = true;
            PhysicalAvgDiskWriteSecCheckbox.IsChecked = true;
            PhysicalPercentageDiskTimeCheckbox.IsChecked = true;
            ProcessHandleCountCheckbox.IsChecked = true;
            ProcessThreadCountCheckbox.IsChecked = true;
            SystemContextSwitchesSecCheckbox.IsChecked = true;
            SystemCallSecCheckbox.IsChecked = true;
            SystemProcessorQueueLengthCheckbox.IsChecked = true;
        }
    }
}
