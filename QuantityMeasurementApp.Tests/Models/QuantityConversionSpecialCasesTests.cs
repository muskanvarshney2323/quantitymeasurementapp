using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionSpecialCasesTests
    {
        private const double Delta = 0.000001;

        [TestMethod]
        public void Convert_VeryLargeValue_ShouldRemainFinite()
        {
            double largeValue = double.MaxValue / 1000;

            double result = Quantity.Convert(largeValue, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(result));
            Assert.IsFalse(double.IsNaN(result));
        }

        [TestMethod]
        public void Convert_VerySmallValue_ShouldRemainFinite()
        {
            double verySmallValue = double.Epsilon;

            double result = Quantity.Convert(verySmallValue, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(result));
            Assert.IsFalse(double.IsNaN(result));
        }

        [TestMethod]
        public void Convert_AllSupportedUnits_ShouldWorkWithoutInvalidResult()
        {
            LengthUnit[] availableUnits =
            {
                LengthUnit.FEET,
                LengthUnit.INCH,
                LengthUnit.YARD,
                LengthUnit.CENTIMETER
            };

            double input = 1.0;

            foreach (LengthUnit source in availableUnits)
            {
                foreach (LengthUnit target in availableUnits)
                {
                    double converted = Quantity.Convert(input, source, target);

                    Assert.IsFalse(double.IsNaN(converted), $"{source} to {target} returned NaN");
                    Assert.IsFalse(double.IsInfinity(converted), $"{source} to {target} returned Infinity");
                }
            }
        }

        [TestMethod]
        public void Convert_RepeatedCalls_ShouldReturnSameOutput()
        {
            double input = 2.5;

            double first = Quantity.Convert(input, LengthUnit.YARD, LengthUnit.INCH);
            double second = Quantity.Convert(input, LengthUnit.YARD, LengthUnit.INCH);
            double third = Quantity.Convert(input, LengthUnit.YARD, LengthUnit.INCH);

            Assert.AreEqual(first, second, Delta);
            Assert.AreEqual(second, third, Delta);
        }

        [TestMethod]
        public void Convert_DirectAndIntermediateConversion_ShouldMatch()
        {
            double input = 3.0;

            double direct = Quantity.Convert(input, LengthUnit.YARD, LengthUnit.INCH);
            double throughFeet = Quantity.Convert(
                Quantity.Convert(input, LengthUnit.YARD, LengthUnit.FEET),
                LengthUnit.FEET,
                LengthUnit.INCH
            );

            Assert.AreEqual(direct, throughFeet, Delta);
        }

        [TestMethod]
        public void Convert_InvalidSourceOrTargetUnit_ShouldThrowException()
        {
            int[] invalidUnits = { -5, 4, 10, 100 };

            foreach (int invalidValue in invalidUnits)
            {
                LengthUnit invalidUnit = (LengthUnit)invalidValue;

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, invalidUnit, LengthUnit.FEET)
                );

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, LengthUnit.FEET, invalidUnit)
                );
            }
        }

        [TestMethod]
        public void Convert_ShouldFollowLinearScalingRule()
        {
            double baseValue = 2.0;
            double multiplier = 3.0;

            double scaledConversion = Quantity.Convert(baseValue * multiplier, LengthUnit.FEET, LengthUnit.INCH);
            double separateConversion = multiplier * Quantity.Convert(baseValue, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(scaledConversion, separateConversion, Delta);
        }

        [TestMethod]
        public void Convert_ShouldPreserveAdditionProperty()
        {
            double first = 1.5;
            double second = 2.5;

            double combined = Quantity.Convert(first + second, LengthUnit.FEET, LengthUnit.INCH);
            double separate =
                Quantity.Convert(first, LengthUnit.FEET, LengthUnit.INCH) +
                Quantity.Convert(second, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(combined, separate, Delta);
        }

        [TestMethod]
        public void Convert_NegativeZero_ShouldRemainNegativeZero()
        {
            double negativeZero = -0.0;

            double result = Quantity.Convert(negativeZero, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(
                BitConverter.DoubleToInt64Bits(-0.0),
                BitConverter.DoubleToInt64Bits(result)
            );
        }

        [TestMethod]
        public void Convert_FractionalValues_ShouldMaintainExpectedAccuracy()
        {
            double[] values = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 / 3.0 };

            foreach (double value in values)
            {
                double converted = Quantity.Convert(value, LengthUnit.FEET, LengthUnit.INCH);
                double expected = value * 12.0;

                Assert.AreEqual(expected, converted, Delta, $"Incorrect conversion for {value}");
            }
        }
    }
}