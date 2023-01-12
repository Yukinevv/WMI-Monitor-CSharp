using System.Diagnostics;

namespace Biblioteka
{
    public static class Counters
    {
        public static PerformanceCounter processorTime = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public static PerformanceCounter processorPrivilegedTime = new PerformanceCounter("Processor", "% Privileged Time", "_Total");
        public static PerformanceCounter processorInterruptTime = new PerformanceCounter("Processor", "% Interrupt Time", "_Total");
        public static PerformanceCounter processorDPCTime = new PerformanceCounter("Processor", "% DPC Time", "_Total");
        public static PerformanceCounter memoryAvaibleMBytes = new PerformanceCounter("Memory", "Available MBytes", null);
        public static PerformanceCounter memoryComittedBytes = new PerformanceCounter("Memory", "Committed Bytes", null);
        public static PerformanceCounter memoryCommitLimit = new PerformanceCounter("Memory", "Commit Limit", null);
        public static PerformanceCounter memoryComittedBytesInUse = new PerformanceCounter("Memory", "% Committed Bytes In Use", null);
        public static PerformanceCounter memoryPoolPagedBytes = new PerformanceCounter("Memory", "Pool Paged Bytes", null);
        public static PerformanceCounter memoryPoolNonpagedBytes = new PerformanceCounter("Memory", "Pool Nonpaged Bytes", null);
        public static PerformanceCounter memoryCacheBytes = new PerformanceCounter("Memory", "Cache Bytes", null);
        public static PerformanceCounter pagingFileUsage = new PerformanceCounter("Paging File", "% Usage", "_Total");
        public static PerformanceCounter logicalDiskPercentFreeSpace = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
        public static PerformanceCounter physicalDiskAvgDiskQueueLength = new PerformanceCounter("PhysicalDisk", "Avg. Disk Queue Length", "_Total");
        public static PerformanceCounter physicalDiskReadBytesSec = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
        public static PerformanceCounter physicalDiskWriteBytesSec = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");
        public static PerformanceCounter physicalDiskAvgDiskReadSec = new PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Read", "_Total");
        public static PerformanceCounter physicalDiskAvgDiskWriteSec = new PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Write", "_Total");
        public static PerformanceCounter physicalDiskPercentageDiskTime = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        public static PerformanceCounter processHandleCount = new PerformanceCounter("Process", "Handle Count", "_Total");
        public static PerformanceCounter processThreadCount = new PerformanceCounter("Process", "Thread Count", "_Total");
        public static PerformanceCounter systemContextSwitchesSec = new PerformanceCounter("System", "Context Switches/sec", null);
        public static PerformanceCounter systemCallsSec = new PerformanceCounter("System", "System Calls/sec", null);
        public static PerformanceCounter systemProcessorQueueLength = new PerformanceCounter("System", "Processor Queue Length", null);
    }
}
