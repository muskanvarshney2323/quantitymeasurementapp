
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionEdgeCaseTests
    {
        private const double Precision = 1e-6;

        // Large value test
        [TestMethod]
        public void Convert_LargeValue_DoesNotOverflow()
        {
            double largeValue = double.MaxValue / 1000;

            double result = Quantity.Convert(largeValue, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(result));
            Assert.IsFalse(double.IsNaN(result));
        }

        // Small value test
        [TestMethod]
        public void Convert_SmallValue_DoesNotBreak()
        {
            double smallValue = double.Epsilon;

            double result = Quantity.Convert(smallValue, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(result));
            Assert.IsFalse(double.IsNaN(result));
        }

        // Zero value test
        [TestMethod]
        public void Convert_Zero_ReturnsZero()
        {
            double result = Quantity.Convert(0, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(0, result, Precision);
        }

        // Negative value test
        [TestMethod]
        public void Convert_NegativeValue_PreservesSign()
        {
            double result = Quantity.Convert(-5, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsTrue(result < 0);
        }

        // Same unit test
        [TestMethod]
        public void Convert_SameUnit_ReturnsSameValue()
        {
            double value = 10;

            double result = Quantity.Convert(value, LengthUnit.FEET, LengthUnit.FEET);

            Assert.AreEqual(value, result, Precision);
        }

        // Round trip test
        [TestMethod]
        public void Convert_RoundTrip_ReturnsOriginalValue()
        {
            double value = 5;

            double inches = Quantity.Convert(value, LengthUnit.FEET, LengthUnit.INCH);
            double feet = Quantity.Convert(inches, LengthUnit.INCH, LengthUnit.FEET);

            Assert.AreEqual(value, feet, Precision);
        }

        // Invalid input test (NaN)
        [TestMethod]
        public void Convert_NaN_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                Quantity.Convert(double.NaN, LengthUnit.FEET, LengthUnit.INCH));
        }

        // Invalid input test (Infinity)
        [TestMethod]
        public void Convert_Infinity_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                Quantity.Convert(double.PositiveInfinity, LengthUnit.FEET, LengthUnit.INCH));
        }
    }
}
