using NUnit.Framework;
using System.Diagnostics;

namespace Biblioteka.Tests
{
    public class CountersProcessorTests
    {
        [Test]
        public void ProcessorTime_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter processorTime = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // act
            int processorPercentageUsageTest = (int)processorTime.NextValue();

            // assert
            Assert.GreaterOrEqual(processorPercentageUsageTest, 0);
            Assert.LessOrEqual(processorPercentageUsageTest, 100);
        }

        [Test]
        public void ProcessorPrivilegedTime_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter processorPrivilegedTime = new PerformanceCounter("Processor", "% Privileged Time", "_Total");

            // act
            int processorPrivilegedTimeTest = (int)processorPrivilegedTime.NextValue();

            // assert
            Assert.GreaterOrEqual(processorPrivilegedTimeTest, 0);
            Assert.LessOrEqual(processorPrivilegedTimeTest, 100);
        }

        [Test]
        public void ProcessorInterruptTime_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter processorInterruptTime = new PerformanceCounter("Processor", "% Interrupt Time", "_Total");

            // act
            int processorInterruptTimeTest = (int)processorInterruptTime.NextValue();

            // assert
            Assert.GreaterOrEqual(processorInterruptTimeTest, 0);
            Assert.LessOrEqual(processorInterruptTimeTest, 100);
        }

        [Test]
        public void ProcessorDPCTime_GreaterOrEqualZero_And_LowerOrEqualHundred()
        {
            // arange
            PerformanceCounter processorDPCTime = new PerformanceCounter("Processor", "% DPC Time", "_Total");

            // act
            int processorDPCTimeTest = (int)processorDPCTime.NextValue();

            // assert
            Assert.GreaterOrEqual(processorDPCTimeTest, 0);
            Assert.LessOrEqual(processorDPCTimeTest, 100);
        }
    }
}