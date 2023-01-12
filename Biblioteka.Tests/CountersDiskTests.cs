using NUnit.Framework;
using System.Diagnostics;

namespace Biblioteka.Tests
{
    public class CountersDiskTests
    {
        [Test]
        public void PagingFileUsage_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter pagingFileUsage = new PerformanceCounter("Paging File", "% Usage", "_Total");

            PerformanceCounter processHandleCount = new PerformanceCounter("Process", "Handle Count", "_Total");
            PerformanceCounter processThreadCount = new PerformanceCounter("Process", "Thread Count", "_Total");
            PerformanceCounter systemContextSwitchesSec = new PerformanceCounter("System", "Context Switches/sec", null);
            PerformanceCounter systemCallsSec = new PerformanceCounter("System", "System Calls/sec", null);
            PerformanceCounter systemProcessorQueueLength = new PerformanceCounter("System", "Processor Queue Length", null);

            // act
            int pagingFileUsageTest = (int)pagingFileUsage.NextValue();

            int processHandleCountTest = (int)processHandleCount.NextValue();
            int processThreadCountTest = (int)processThreadCount.NextValue();
            int systemContextSwitchesSecTest = (int)systemContextSwitchesSec.NextValue();
            int systemCallsSecTest = (int)systemCallsSec.NextValue();
            int systemProcessorQueueLengthTest = (int)systemProcessorQueueLength.NextValue();

            // assert
            Assert.GreaterOrEqual(pagingFileUsageTest, 0);
            Assert.LessOrEqual(pagingFileUsageTest, 100);
        }

        [Test]
        public void LogicalDiskPercentUsage_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter logicalDiskPercentFreeSpace = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");

            // act
            int logicalDiskPercentFreeSpaceTest = (int)logicalDiskPercentFreeSpace.NextValue();

            // assert
            Assert.GreaterOrEqual(logicalDiskPercentFreeSpaceTest, 0);
            Assert.LessOrEqual(logicalDiskPercentFreeSpaceTest, 100);
        }

        [Test]
        public void PhysicalDiskAvgDiskQueueLength_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter physicalDiskAvgDiskQueueLength = new PerformanceCounter("PhysicalDisk", "Avg. Disk Queue Length", "_Total");

            // act
            int physicalDiskAvgDiskQueueLengthTest = (int)physicalDiskAvgDiskQueueLength.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskAvgDiskQueueLengthTest, 0);
        }

        [Test]
        public void PhysicalDiskReadBytesSec_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter physicalDiskReadBytesSec = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");

            // act
            int physicalDiskReadBytesSecTest = (int)physicalDiskReadBytesSec.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskReadBytesSecTest, 0);
        }

        [Test]
        public void PhysicalDiskWriteBytesSec_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter physicalDiskWriteBytesSec = new PerformanceCounter("PhysicalDisk", "Disk Write Bytes/sec", "_Total");

            // act
            int physicalDiskWriteBytesSecTest = (int)physicalDiskWriteBytesSec.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskWriteBytesSecTest, 0);
        }

        [Test]
        public void PhysicalDiskAvgDiskReadSec_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter physicalDiskAvgDiskReadSec = new PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Read", "_Total");

            // act
            int physicalDiskAvgDiskReadSecTest = (int)physicalDiskAvgDiskReadSec.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskAvgDiskReadSecTest, 0);
        }

        [Test]
        public void PhysicalDiskAvgDiskWriteSec_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter physicalDiskAvgDiskWriteSec = new PerformanceCounter("PhysicalDisk", "Avg. Disk sec/Write", "_Total");

            // act
            int physicalDiskAvgDiskWriteSecTest = (int)physicalDiskAvgDiskWriteSec.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskAvgDiskWriteSecTest, 0);
        }

        [Test]
        public void PhysicalDiskPercentageDiskTime_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter physicalDiskPercentageDiskTime = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");

            // act
            int physicalDiskPercentageDiskTimeTest = (int)physicalDiskPercentageDiskTime.NextValue();

            // assert
            Assert.GreaterOrEqual(physicalDiskPercentageDiskTimeTest, 0);
            Assert.LessOrEqual(physicalDiskPercentageDiskTimeTest, 100);
        }
    }
}
