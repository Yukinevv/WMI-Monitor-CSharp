using NUnit.Framework;
using System;
using ZarzadzanieUsluga.UserControls;

namespace ZarzadzanieUsluga.Tests
{
    public class CalculatePercentageValue
    {
        [Test]
        public void CalculatePercentageValue_ArgumentException_NegativeValue()
        {
            // Arrange
            int value = -1;
            int divider = 100;

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => CircularProgressBar.CalculatePercentageValue(value, divider));
        }

        [Test]
        public void CalculatePercentageValue_ArgumentException_DividerEqualZero()
        {
            // Arrange
            int value = 54;
            int divider = 0;

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => CircularProgressBar.CalculatePercentageValue(value, divider));
        }

        [Test]
        public void CalculatePercentageValue_GreaterOrEqualZero_LessOrEqualHundred()
        {
            // Arrange
            int value = 35;
            int divider = 100;

            // Act + Assert
            short percentageValue = CircularProgressBar.CalculatePercentageValue(value, divider);

            // Assert
            Assert.GreaterOrEqual(percentageValue, 0);
            Assert.LessOrEqual(percentageValue, 100);
        }

        [Test]
        public void CalculatePercentageValue_ExpectedValue()
        {
            // Arrange
            int value = 27;
            double divider = 100;

            // Act + Assert
            short percentageValue = CircularProgressBar.CalculatePercentageValue(value, divider);

            Assert.AreEqual(27, percentageValue);
        }
    }
}