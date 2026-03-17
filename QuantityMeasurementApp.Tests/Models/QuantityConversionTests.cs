using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionTests
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void Convert_FeetToInches_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(12.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_InchesToFeet_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(24.0, LengthUnit.INCH, LengthUnit.FEET);
            Assert.AreEqual(2.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_YardsToFeet_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.YARD, LengthUnit.FEET);
            Assert.AreEqual(3.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_FeetToYards_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(6.0, LengthUnit.FEET, LengthUnit.YARD);
            Assert.AreEqual(2.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_YardsToInches_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.YARD, LengthUnit.INCH);
            Assert.AreEqual(36.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_InchesToYards_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(72.0, LengthUnit.INCH, LengthUnit.YARD);
            Assert.AreEqual(2.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_CentimetersToInches_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(2.54, LengthUnit.CENTIMETER, LengthUnit.INCH);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_InchesToCentimeters_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.INCH, LengthUnit.CENTIMETER);
            Assert.AreEqual(2.54, result, Tolerance);
        }

        [TestMethod]
        public void Convert_CentimetersToFeet_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(30.48, LengthUnit.CENTIMETER, LengthUnit.FEET);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_FeetToCentimeters_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.FEET, LengthUnit.CENTIMETER);
            Assert.AreEqual(30.48, result, Tolerance);
        }

        [TestMethod]
        public void Convert_CentimetersToYards_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(91.44, LengthUnit.CENTIMETER, LengthUnit.YARD);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_YardsToCentimeters_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.YARD, LengthUnit.CENTIMETER);
            Assert.AreEqual(91.44, result, Tolerance);
        }

        [TestMethod]
        public void Convert_YardsToCentimeters_DecimalValue_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(2.5, LengthUnit.YARD, LengthUnit.CENTIMETER);
            double expected = 2.5 * 91.44;
            Assert.AreEqual(expected, result, Tolerance);
        }

        [TestMethod]
        public void Convert_InchesToCentimeters_FractionalValue_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(12.5, LengthUnit.INCH, LengthUnit.CENTIMETER);
            double expected = 12.5 * 2.54;
            Assert.AreEqual(expected, result, Tolerance);
        }

        [TestMethod]
        public void Convert_FeetToCentimeters_DecimalValue_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(3.5, LengthUnit.FEET, LengthUnit.CENTIMETER);
            double expected = 3.5 * 30.48;
            Assert.AreEqual(expected, result, Tolerance);
        }

        [TestMethod]
        public void Convert_ZeroValue_ReturnsZero()
        {
            double result = Quantity.Convert(0.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(0.0, result, Tolerance);

            result = Quantity.Convert(0.0, LengthUnit.YARD, LengthUnit.CENTIMETER);
            Assert.AreEqual(0.0, result, Tolerance);

            result = Quantity.Convert(0.0, LengthUnit.INCH, LengthUnit.FEET);
            Assert.AreEqual(0.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_NegativeValue_PreservesSign()
        {
            double result = Quantity.Convert(-1.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(-12.0, result, Tolerance);

            result = Quantity.Convert(-2.5, LengthUnit.YARD, LengthUnit.FEET);
            Assert.AreEqual(-7.5, result, Tolerance);

            result = Quantity.Convert(-30.48, LengthUnit.CENTIMETER, LengthUnit.FEET);
            Assert.AreEqual(-1.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_LargeValues_MaintainsPrecision()
        {
            double result = Quantity.Convert(1000000.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(12000000.0, result, Tolerance * 1000000);
        }

        [TestMethod]
        public void Convert_SmallValues_MaintainsPrecision()
        {
            double result = Quantity.Convert(0.000001, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(0.000012, result, Tolerance);

            result = Quantity.Convert(0.000001, LengthUnit.CENTIMETER, LengthUnit.INCH);
            double expected = 0.000001 * 0.393700787;
            Assert.AreEqual(expected, result, Tolerance);
        }

        [TestMethod]
        public void Convert_SameUnit_ReturnsOriginalValue()
        {
            double result = Quantity.Convert(5.0, LengthUnit.FEET, LengthUnit.FEET);
            Assert.AreEqual(5.0, result, Tolerance);

            result = Quantity.Convert(7.5, LengthUnit.INCH, LengthUnit.INCH);
            Assert.AreEqual(7.5, result, Tolerance);

            result = Quantity.Convert(3.2, LengthUnit.YARD, LengthUnit.YARD);
            Assert.AreEqual(3.2, result, Tolerance);

            result = Quantity.Convert(10.0, LengthUnit.CENTIMETER, LengthUnit.CENTIMETER);
            Assert.AreEqual(10.0, result, Tolerance);
        }

        [TestMethod]
        public void Convert_RoundTrip_ReturnsOriginalValue()
        {
            double originalValue = 3.5;

            double toInches = Quantity.Convert(originalValue, LengthUnit.FEET, LengthUnit.INCH);
            double backToFeet = Quantity.Convert(toInches, LengthUnit.INCH, LengthUnit.FEET);

            Assert.AreEqual(originalValue, backToFeet, Tolerance);

            originalValue = 2.0;
            double toCm = Quantity.Convert(originalValue, LengthUnit.YARD, LengthUnit.CENTIMETER);
            double backToYards = Quantity.Convert(toCm, LengthUnit.CENTIMETER, LengthUnit.YARD);

            Assert.AreEqual(originalValue, backToYards, Tolerance);
        }

        [TestMethod]
        public void Convert_MultiStepRoundTrip_ReturnsOriginalValue()
        {
            double originalValue = 1.0;

            double toInches = Quantity.Convert(originalValue, LengthUnit.FEET, LengthUnit.INCH);
            double toCm = Quantity.Convert(toInches, LengthUnit.INCH, LengthUnit.CENTIMETER);
            double toYards = Quantity.Convert(toCm, LengthUnit.CENTIMETER, LengthUnit.YARD);
            double backToFeet = Quantity.Convert(toYards, LengthUnit.YARD, LengthUnit.FEET);

            Assert.AreEqual(originalValue, backToFeet, Tolerance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_InvalidSourceUnit_ThrowsArgumentException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;
            Quantity.Convert(1.0, invalidUnit, LengthUnit.FEET);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_InvalidTargetUnit_ThrowsArgumentException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;
            Quantity.Convert(1.0, LengthUnit.FEET, invalidUnit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_NaNValue_ThrowsArgumentException()
        {
            Quantity.Convert(double.NaN, LengthUnit.FEET, LengthUnit.INCH);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_PositiveInfinity_ThrowsArgumentException()
        {
            Quantity.Convert(double.PositiveInfinity, LengthUnit.FEET, LengthUnit.INCH);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_NegativeInfinity_ThrowsArgumentException()
        {
            Quantity.Convert(double.NegativeInfinity, LengthUnit.FEET, LengthUnit.INCH);
        }

        [TestMethod]
        public void ConvertTo_InstanceMethod_ReturnsCorrectQuantity()
        {
            var quantity = new Quantity(1.0, LengthUnit.FEET);
            var converted = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, converted.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, converted.Unit);
        }

        [TestMethod]
        public void ConvertTo_InstanceMethod_ZeroValue_ReturnsZero()
        {
            var quantity = new Quantity(0.0, LengthUnit.FEET);
            var converted = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(0.0, converted.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, converted.Unit);
        }

        [TestMethod]
        public void ConvertTo_InstanceMethod_NegativeValue_PreservesSign()
        {
            var quantity = new Quantity(-2.5, LengthUnit.YARD);
            var converted = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(-7.5, converted.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, converted.Unit);
        }

        [TestMethod]
        public void ConvertTo_InstanceMethod_SameUnit_ReturnsSameValue()
        {
            var quantity = new Quantity(5.0, LengthUnit.FEET);
            var converted = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(5.0, converted.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, converted.Unit);
        }

        [TestMethod]
        public void Convert_PrecisionTest_MaintainsAccuracy()
        {
            double result = Quantity.Convert(1.23456789, LengthUnit.FEET, LengthUnit.INCH);
            double expected = 1.23456789 * 12.0;
            Assert.AreEqual(expected, result, 0.000001);

            result = Quantity.Convert(2.3456789, LengthUnit.YARD, LengthUnit.CENTIMETER);
            expected = 2.3456789 * 91.44;
            Assert.AreEqual(expected, result, 0.0001);

            result = Quantity.Convert(3.456789, LengthUnit.CENTIMETER, LengthUnit.INCH);
            expected = 3.456789 * 0.393700787;
            Assert.AreEqual(expected, result, 0.000001);
        }

        [TestMethod]
        public void Convert_Bidirectional_AreInverses()
        {
            double value = 5.0;

            double feetToInches = Quantity.Convert(value, LengthUnit.FEET, LengthUnit.INCH);
            double inchesToFeet = Quantity.Convert(feetToInches, LengthUnit.INCH, LengthUnit.FEET);
            Assert.AreEqual(value, inchesToFeet, Tolerance);

            double yardsToFeet = Quantity.Convert(value, LengthUnit.YARD, LengthUnit.FEET);
            double feetToYards = Quantity.Convert(yardsToFeet, LengthUnit.FEET, LengthUnit.YARD);
            Assert.AreEqual(value, feetToYards, Tolerance);

            double cmToInches = Quantity.Convert(value, LengthUnit.CENTIMETER, LengthUnit.INCH);
            double inchesToCm = Quantity.Convert(cmToInches, LengthUnit.INCH, LengthUnit.CENTIMETER);
            Assert.AreEqual(value, inchesToCm, Tolerance);
        }
    }
}