using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Tests for verifying conversion logic under edge conditions and special cases.
    /// </summary>
    [TestClass]
    public class QuantityConversionSpecialCasesTests
    {
        private const double Precision = 1e-6;

        #region Extreme Values

        [TestMethod]
        public void Conversion_LargeMagnitude_DoesNotOverflow()
        {
            double bigNumber = double.MaxValue / 1000;

            double inches = Quantity.Convert(bigNumber, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(inches), "Conversion resulted in infinity");
            Assert.IsFalse(double.IsNaN(inches), "Conversion resulted in NaN");
        }

        [TestMethod]
        public void Conversion_TinyMagnitude_HandledSafely()
        {
            double tinyNumber = double.Epsilon;

            double inches = Quantity.Convert(tinyNumber, LengthUnit.FEET, LengthUnit.INCH);

            Assert.IsFalse(double.IsInfinity(inches), "Result should not be infinity");
            Assert.IsFalse(double.IsNaN(inches), "Result should not be NaN");
        }

        #endregion

        #region Unit Combination Checks

        [TestMethod]
        public void Conversion_AllUnits_NoUnexpectedFailures()
        {
            LengthUnit[] units = { LengthUnit.FEET, LengthUnit.INCH, LengthUnit.YARD, LengthUnit.CENTIMETER };
            double value = 1.0;

            foreach (var from in units)
            {
                foreach (var to in units)
                {
                    try
                    {
                        double result = Quantity.Convert(value, from, to);
                        Assert.IsFalse(double.IsNaN(result), $"{from}->{to} produced NaN");
                        Assert.IsFalse(double.IsInfinity(result), $"{from}->{to} produced Infinity");
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail($"Conversion {from}->{to} threw exception: {ex.Message}");
                    }
                }
            }
        }

        #endregion

        #region Consistency Checks

        [TestMethod]
        public void Conversion_MultipleCalls_Consistent()
        {
            double val = 2.5;
            double first = Quantity.Convert(val, LengthUnit.YARD, LengthUnit.INCH);
            double second = Quantity.Convert(val, LengthUnit.YARD, LengthUnit.INCH);
            double third = Quantity.Convert(val, LengthUnit.YARD, LengthUnit.INCH);

            Assert.AreEqual(first, second, Precision);
            Assert.AreEqual(second, third, Precision);
        }

        [TestMethod]
        public void Conversion_ThroughIntermediate_EqualsDirect()
        {
            double val = 3.0;

            double direct = Quantity.Convert(val, LengthUnit.YARD, LengthUnit.INCH);
            double viaFeet = Quantity.Convert(Quantity.Convert(val, LengthUnit.YARD, LengthUnit.FEET), LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(direct, viaFeet, Precision);
        }

        #endregion

        #region Validation Checks

        [TestMethod]
        public void Conversion_InvalidEnum_Throws()
        {
            int[] invalid = { -5, 4, 10, 100 };

            foreach (int val in invalid)
            {
                LengthUnit invalidUnit = (LengthUnit)val;

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, invalidUnit, LengthUnit.FEET),
                    $"Source {val} should throw"
                );

                Assert.ThrowsException<ArgumentException>(
                    () => Quantity.Convert(1.0, LengthUnit.FEET, invalidUnit),
                    $"Target {val} should throw"
                );
            }
        }

        #endregion

        #region Mathematical Properties

        [TestMethod]
        public void Conversion_Linear_ScalesProperly()
        {
            double x = 2.0;
            double factor = 3.0;

            double scaled = Quantity.Convert(x * factor, LengthUnit.FEET, LengthUnit.INCH);
            double multiplied = factor * Quantity.Convert(x, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(scaled, multiplied, Precision);
        }

        [TestMethod]
        public void Conversion_Additive_PreservesSum()
        {
            double a = 1.5, b = 2.5;

            double sumDirect = Quantity.Convert(a + b, LengthUnit.FEET, LengthUnit.INCH);
            double sumSeparate = Quantity.Convert(a, LengthUnit.FEET, LengthUnit.INCH)
                                + Quantity.Convert(b, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(sumDirect, sumSeparate, Precision);
        }

        #endregion

        #region Zero and Sign Handling

        [TestMethod]
        public void Conversion_NegativeZero_PreservesSign()
        {
            double negZero = -0.0;

            double result = Quantity.Convert(negZero, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(BitConverter.DoubleToInt64Bits(result), BitConverter.DoubleToInt64Bits(-0.0));
        }

        #endregion

        #region Rounding Behavior

        [TestMethod]
        public void Conversion_Rounding_PreservesAccuracy()
        {
            double[] values = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 / 3.0 };

            foreach (var v in values)
            {
                double result = Quantity.Convert(v, LengthUnit.FEET, LengthUnit.INCH);
                double expected = v * 12.0;

                Assert.AreEqual(expected, result, Precision, $"Value {v} converted incorrectly");
            }
        }

        #endregion
    }
}