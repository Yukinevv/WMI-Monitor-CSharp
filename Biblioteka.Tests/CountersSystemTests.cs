using NUnit.Framework;
using System.Diagnostics;

namespace Biblioteka.Tests
{
    public class CountersSystemTests
    {
        [Test]
        public void ProcessHandleCountTest_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter processHandleCount = new PerformanceCounter("Process", "Handle Count", "_Total");

            // act
            int processHandleCountTest = (int)processHandleCount.NextValue();

            // assert
            Assert.GreaterOrEqual(processHandleCountTest, 0);
        }

        [Test]
        public void ProcessThreadCount_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter processThreadCount = new PerformanceCounter("Process", "Thread Count", "_Total");

            // act
            int processThreadCountTest = (int)processThreadCount.NextValue();

            // assert
            Assert.GreaterOrEqual(processThreadCountTest, 0);
        }

        [Test]
        public void SystemContextSwitchesSec_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter systemContextSwitchesSec = new PerformanceCounter("System", "Context Switches/sec", null);

            // act
            int systemContextSwitchesSecTest = (int)systemContextSwitchesSec.NextValue();

            // assert
            Assert.GreaterOrEqual(systemContextSwitchesSecTest, 0);
        }

        [Test]
        public void SystemCallsSect_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter systemCallsSec = new PerformanceCounter("System", "System Calls/sec", null);

            // act
            int systemCallsSecTest = (int)systemCallsSec.NextValue();

            // assert
            Assert.GreaterOrEqual(systemCallsSecTest, 0);
        }

        [Test]
        public void SystemProcessorQueueLength_GreaterOrEqualZero()
        {
            // arange
            PerformanceCounter systemProcessorQueueLength = new PerformanceCounter("System", "Processor Queue Length", null);

            // act
            int systemProcessorQueueLengthTest = (int)systemProcessorQueueLength.NextValue();

            // assert
            Assert.GreaterOrEqual(systemProcessorQueueLengthTest, 0);
        }
    }
}
