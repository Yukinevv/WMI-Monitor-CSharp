using Biblioteka;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace Usluga
{
    public partial class Service1 : ServiceBase
    {
        private static EventLog Dziennik;
        public const string NazwaDziennika = "LogWMI";
        public const string NazwaZrodla = "ZrodloWMI";

        public static HardwareInfo HardwareData { get; set; } = new HardwareInfo();

        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string GetMessage();
        }

        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class MessageService : IMessageService
        {
            public string GetMessage()
            {
                string dataSerialized = JsonConvert.SerializeObject(HardwareData, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                return dataSerialized;
            }
        }

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
            var uris = new Uri[1];
            string address = "net.tcp://localhost:6565/MessageService";
            uris[0] = new Uri(address);
            IMessageService message = new MessageService();
            ServiceHost host = new ServiceHost(message, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, "");
            host.Open();

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
            HardwareData.ProcessorPercentageUsage = (int)Counters.processorTime.NextValue();
            HardwareData.ProcessorPrivilegedTime = (int)Counters.processorPrivilegedTime.NextValue();
            HardwareData.ProcessorInterruptTime = (int)Counters.processorInterruptTime.NextValue();
            HardwareData.ProcessorDPCTime = (int)Counters.processorDPCTime.NextValue();
            HardwareData.MemoryAvaibleMBytes = (int)Counters.memoryAvaibleMBytes.NextValue();
            HardwareData.MemoryCommitedBytes = (long)Counters.memoryComittedBytes.NextValue();
            HardwareData.MemoryCommitLimit = (long)Counters.memoryCommitLimit.NextValue();
            HardwareData.MemoryCommitedBytesInUse = (int)Counters.memoryComittedBytesInUse.NextValue();
            HardwareData.MemoryPoolPagedBytes = (int)Counters.memoryPoolPagedBytes.NextValue();
            HardwareData.MemoryPoolNonpagedBytes = (int)Counters.memoryPoolNonpagedBytes.NextValue();
            HardwareData.MemoryCachedBytes = (int)Counters.memoryCacheBytes.NextValue();
            HardwareData.PagingFileUsage = (int)Counters.pagingFileUsage.NextValue();
            HardwareData.LogicalDiskPercentFreeSpace = (int)Counters.logicalDiskPercentFreeSpace.NextValue();
            HardwareData.PhysicalAvgDiskQueueLength = (int)Counters.physicalDiskAvgDiskQueueLength.NextValue();
            HardwareData.PhysicalDiskReadBytesSec = (int)Counters.physicalDiskReadBytesSec.NextValue();
            HardwareData.PhysicalDiskWriteBytesSec = (int)Counters.physicalDiskWriteBytesSec.NextValue();
            HardwareData.PhysicalAvgDiskReadSec = (int)Counters.physicalDiskAvgDiskReadSec.NextValue();
            HardwareData.PhysicalAvgDiskWriteSec = (int)Counters.physicalDiskAvgDiskWriteSec.NextValue();
            HardwareData.PhysicalPercentageDiskTime = (int)Counters.physicalDiskPercentageDiskTime.NextValue();
            HardwareData.ProcessHandleCount = (int)Counters.processHandleCount.NextValue();
            HardwareData.ProcessThreadCount = (int)Counters.processThreadCount.NextValue();
            HardwareData.SystemContextSwitchesSec = (int)Counters.systemContextSwitchesSec.NextValue();
            HardwareData.SystemCallSec = (int)Counters.systemCallsSec.NextValue();
            HardwareData.SystemProcessorQueueLength = (int)Counters.systemProcessorQueueLength.NextValue();
        }

        protected override void OnStop()
        {
            Dziennik.WriteEntry("Zatrzymanie usługi");
        }
    }
}
