using Biblioteka;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace Usluga
{
    public partial class Service1 : ServiceBase
    {
        private static EventLog Dziennik;
        public const string NazwaDziennika = "LogWMI";
        public const string NazwaZrodla = "ZrodloWMI";

        private ServiceHost serviceHost = null;

        public Service1()
        {
            InitializeComponent();

            // Utworzenie dziennika zdarzen
            if (!EventLog.SourceExists(NazwaZrodla))
            {
                EventLog.CreateEventSource(NazwaZrodla, NazwaDziennika);
            }
            Dziennik = new EventLog(NazwaDziennika, ".", NazwaZrodla);
        }

        protected override void OnStart(string[] args)
        {
            serviceHost?.Close();
            serviceHost = new ServiceHost(typeof(MessageService));
            // Otwarcie polaczenia przez WCF
            serviceHost.Open();

            Dziennik.WriteEntry("Uruchomienie usługi");

            Task.Factory.StartNew(() =>
            {
                while (1 == 1)
                {
                    this.GetHardwareData();
                    Thread.Sleep(3000);
                }
            });
        }

        private void GetHardwareData()
        {
            // Pobieram dane dotyczace sprzetu z PerformanceCounters
            Hardware.HardwareData.ProcessorPercentageUsage = (int)Counters.processorTime.NextValue();
            Hardware.HardwareData.ProcessorPrivilegedTime = (int)Counters.processorPrivilegedTime.NextValue();
            Hardware.HardwareData.ProcessorInterruptTime = (int)Counters.processorInterruptTime.NextValue();
            Hardware.HardwareData.ProcessorDPCTime = (int)Counters.processorDPCTime.NextValue();
            Hardware.HardwareData.MemoryAvaibleMBytes = (int)Counters.memoryAvaibleMBytes.NextValue();
            Hardware.HardwareData.MemoryCommitedBytes = (long)Counters.memoryComittedBytes.NextValue();
            Hardware.HardwareData.MemoryCommitLimit = (long)Counters.memoryCommitLimit.NextValue();
            Hardware.HardwareData.MemoryCommitedBytesInUse = (int)Counters.memoryComittedBytesInUse.NextValue();
            Hardware.HardwareData.MemoryPoolPagedBytes = (int)Counters.memoryPoolPagedBytes.NextValue();
            Hardware.HardwareData.MemoryPoolNonpagedBytes = (int)Counters.memoryPoolNonpagedBytes.NextValue();
            Hardware.HardwareData.MemoryCachedBytes = (int)Counters.memoryCacheBytes.NextValue();
            Hardware.HardwareData.PagingFileUsage = (int)Counters.pagingFileUsage.NextValue();
            Hardware.HardwareData.LogicalDiskPercentFreeSpace = (int)Counters.logicalDiskPercentFreeSpace.NextValue();
            Hardware.HardwareData.PhysicalAvgDiskQueueLength = (int)Counters.physicalDiskAvgDiskQueueLength.NextValue();
            Hardware.HardwareData.PhysicalDiskReadBytesSec = (int)Counters.physicalDiskReadBytesSec.NextValue();
            Hardware.HardwareData.PhysicalDiskWriteBytesSec = (int)Counters.physicalDiskWriteBytesSec.NextValue();
            Hardware.HardwareData.PhysicalAvgDiskReadSec = (int)Counters.physicalDiskAvgDiskReadSec.NextValue();
            Hardware.HardwareData.PhysicalAvgDiskWriteSec = (int)Counters.physicalDiskAvgDiskWriteSec.NextValue();
            Hardware.HardwareData.PhysicalPercentageDiskTime = (int)Counters.physicalDiskPercentageDiskTime.NextValue();
            Hardware.HardwareData.ProcessHandleCount = (int)Counters.processHandleCount.NextValue();
            Hardware.HardwareData.ProcessThreadCount = (int)Counters.processThreadCount.NextValue();
            Hardware.HardwareData.SystemContextSwitchesSec = (int)Counters.systemContextSwitchesSec.NextValue();
            Hardware.HardwareData.SystemCallSec = (int)Counters.systemCallsSec.NextValue();
            Hardware.HardwareData.SystemProcessorQueueLength = (int)Counters.systemProcessorQueueLength.NextValue();
        }

        protected override void OnStop()
        {
            Dziennik.WriteEntry("Zatrzymanie usługi");

            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
