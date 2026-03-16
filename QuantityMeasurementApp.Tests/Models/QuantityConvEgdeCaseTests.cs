using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionEdgeCasesTests
    {
        private const double Delta = 0.000001;

        private static void AssertValidNumber(double value, string message)
        {
            Assert.IsFalse(double.IsNaN(value), $"{message} produced NaN");
            Assert.IsFalse(double.IsInfinity(value), $"{message} produced Infinity");
        }

        private static void AssertConversion(
            double input,
            LengthUnit from,
            LengthUnit to,
            double expected)
        {
            var actual = Quantity.Convert(input, from, to);
            Assert.AreEqual(expected, actual, Delta);
        }

        [TestMethod]
        public void Convert_WithVeryLargeInput_ShouldReturnFiniteValue()
        {
            var input = double.MaxValue / 1000.0;

            var output = Quantity.Convert(input, LengthUnit.FEET, LengthUnit.INCH);

            AssertValidNumber(output, "Large value conversion");
        }

        [TestMethod]
        public void Convert_WithVerySmallInput_ShouldReturnFiniteValue()
        {
            var input = double.Epsilon;

            var output = Quantity.Convert(input, LengthUnit.FEET, LengthUnit.INCH);

            AssertValidNumber(output, "Small value conversion");
        }

        [TestMethod]
        public void Convert_ForEverySupportedUnitPair_ShouldNotThrow()
        {
            var supportedUnits = new[]
            {
                LengthUnit.FEET,
                LengthUnit.INCH,
                LengthUnit.YARD,
                LengthUnit.CENTIMETER
            };

            foreach (var fromUnit in supportedUnits)
            {
                foreach (var toUnit in supportedUnits)
                {
                    var converted = Quantity.Convert(1.0, fromUnit, toUnit);
                    AssertValidNumber(converted, $"Conversion from {fromUnit} to {toUnit}");
                }
            }
        }

        [TestMethod]
        public void Convert_RepeatedCallsWithSameInput_ShouldGiveSameResult()
        {
            var first = Quantity.Convert(2.5, LengthUnit.YARD, LengthUnit.INCH);
            var second = Quantity.Convert(2.5, LengthUnit.YARD, LengthUnit.INCH);
            var third = Quantity.Convert(2.5, LengthUnit.YARD, LengthUnit.INCH);

            Assert.AreEqual(first, second, Delta);
            Assert.AreEqual(second, third, Delta);
        }

        [TestMethod]
        public void Convert_DirectConversion_ShouldMatchStepwiseConversion()
        {
            var directResult = Quantity.Convert(3.0, LengthUnit.YARD, LengthUnit.INCH);

            var intermediateFeet = Quantity.Convert(3.0, LengthUnit.YARD, LengthUnit.FEET);
            var stepwiseResult = Quantity.Convert(intermediateFeet, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(directResult, stepwiseResult, Delta);
        }

        [TestMethod]
        public void Convert_WhenSourceUnitIsInvalid_ShouldThrowArgumentException()
        {
            var invalidUnits = new[] { -1, 4, 5, 10, 100 };

            foreach (var invalid in invalidUnits)
            {
                var invalidSource = (LengthUnit)invalid;

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, invalidSource, LengthUnit.FEET));
            }
        }

        [TestMethod]
        public void Convert_WhenTargetUnitIsInvalid_ShouldThrowArgumentException()
        {
            var invalidUnits = new[] { -1, 4, 5, 10, 100 };

            foreach (var invalid in invalidUnits)
            {
                var invalidTarget = (LengthUnit)invalid;

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, LengthUnit.FEET, invalidTarget));
            }
        }

        [TestMethod]
        public void Convert_ShouldFollowLinearProperty()
        {
            const double original = 2.0;
            const double multiplier = 3.0;

            var scaledInputResult = Quantity.Convert(original * multiplier, LengthUnit.FEET, LengthUnit.INCH);
            var scaledOutputResult = multiplier * Quantity.Convert(original, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(scaledInputResult, scaledOutputResult, Delta);
        }

        [TestMethod]
        public void Convert_ShouldFollowAdditiveProperty()
        {
            const double firstPart = 1.5;
            const double secondPart = 2.5;

            var combined = Quantity.Convert(firstPart + secondPart, LengthUnit.FEET, LengthUnit.INCH);
            var separateThenAdd =
                Quantity.Convert(firstPart, LengthUnit.FEET, LengthUnit.INCH) +
                Quantity.Convert(secondPart, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(combined, separateThenAdd, Delta);
        }

        [TestMethod]
        public void Convert_NegativeZero_ShouldPreserveNegativeZero()
        {
            var result = Quantity.Convert(-0.0, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsTrue(double.IsNegativeInfinity(1.0 / result));
        }

        [TestMethod]
        public void Convert_FloatingPointSensitiveInputs_ShouldRemainAccurate()
        {
            var inputs = new[]
            {
                0.1, 0.2, 0.3, 0.4, 0.5,
                0.6, 0.7, 0.8, 0.9, 1.0 / 3.0
            };

            foreach (var input in inputs)
            {
                AssertConversion(input, LengthUnit.FEET, LengthUnit.INCH, input * 12.0);
            }
        }
    }
}