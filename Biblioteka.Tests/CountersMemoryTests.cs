using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Management;

namespace Biblioteka.Tests
{
    public class CountersMemoryTests
    {
        [Test]
        public void MemoryAvaibleMBytes_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter memoryAvaibleMBytes = new PerformanceCounter("Memory", "Available MBytes", null);

            ManagementObjectSearcher search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            // act
            int memoryAvaibleMBytesTest = (int)memoryAvaibleMBytes.NextValue();

            long ramMBytes = 0;
            foreach (ManagementObject mObject in search.Get())
            {
                ramMBytes = Convert.ToInt64(mObject["TotalPhysicalMemory"]) / 1048576;
            }

            // assert
            Assert.GreaterOrEqual(memoryAvaibleMBytesTest, 0);
            Assert.LessOrEqual(memoryAvaibleMBytesTest, ramMBytes);
        }

        [Test]
        public void MemoryCommitedBytes_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter memoryComittedBytes = new PerformanceCounter("Memory", "Committed Bytes", null);

            // act
            long memoryComittedBytesTest = (long)memoryComittedBytes.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryComittedBytesTest, 0);
        }

        [Test]
        public void MemoryCommitLimit_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter memoryCommitLimit = new PerformanceCounter("Memory", "Commit Limit", null);

            // act
            long memoryCommitLimitTest = (long)memoryCommitLimit.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryCommitLimitTest, 0);
        }

        [Test]
        public void MemoryComittedBytesInUse_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter memoryCommittedBytesInUse = new PerformanceCounter("Memory", "% Committed Bytes In Use", null);

            // act
            int memoryCommittedBytesInUseTest = (int)memoryCommittedBytesInUse.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryCommittedBytesInUseTest, 0);
            Assert.LessOrEqual(memoryCommittedBytesInUseTest, 100);
        }

        [Test]
        public void MemoryPoolPagedBytes_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter memoryPoolPagedBytes = new PerformanceCounter("Memory", "Pool Paged Bytes", null);

            // act
            int memoryPoolPagedBytesTest = (int)memoryPoolPagedBytes.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryPoolPagedBytesTest, 0);
        }

        [Test]
        public void MemoryPoolNonpagedBytes_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter memoryPoolNonpagedBytes = new PerformanceCounter("Memory", "Pool Nonpaged Bytes", null);

            // act
            int memoryPoolNonpagedBytesTest = (int)memoryPoolNonpagedBytes.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryPoolNonpagedBytesTest, 0);
        }

        [Test]
        public void MemoryCacheBytes_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter memoryCacheBytes = new PerformanceCounter("Memory", "Cache Bytes", null);

            // act
            int memoryCacheBytesTest = (int)memoryCacheBytes.NextValue();

            // assert
            Assert.GreaterOrEqual(memoryCacheBytesTest, 0);
        }
    }
}
