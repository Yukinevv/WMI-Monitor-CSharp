namespace Biblioteka
{
    public class HardwareInfo
    {
        public int ProcessorPercentageUsage { get; set; }
        public int ProcessorPrivilegedTime { get; set; }
        public int ProcessorInterruptTime { get; set; }
        public int ProcessorDPCTime { get; set; }
        public int MemoryAvaibleMBytes { get; set; }
        public long MemoryCommitedBytes { get; set; }
        public long MemoryCommitLimit { get; set; }
        public int MemoryCommitedBytesInUse { get; set; }
        public int MemoryPoolPagedBytes { get; set; }
        public int MemoryPoolNonpagedBytes { get; set; }
        public int MemoryCachedBytes { get; set; }
        public int PagingFileUsage { get; set; }
        public int LogicalDiskPercentFreeSpace { get; set; }
        public int PhysicalAvgDiskQueueLength { get; set; }
        public int PhysicalDiskReadBytesSec { get; set; }
        public int PhysicalDiskWriteBytesSec { get; set; }
        public int PhysicalAvgDiskReadSec { get; set; }
        public int PhysicalAvgDiskWriteSec { get; set; }
        public int PhysicalPercentageDiskTime { get; set; }
        public int ProcessHandleCount { get; set; }
        public int ProcessThreadCount { get; set; }
        public int SystemContextSwitchesSec { get; set; }
        public int SystemCallSec { get; set; }
        public int SystemProcessorQueueLength { get; set; }
    }
}
