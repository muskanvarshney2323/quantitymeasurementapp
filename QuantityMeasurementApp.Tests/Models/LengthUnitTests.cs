using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Test suite for verifying LengthUnit helper behavior.
    /// Covers conversion logic, display formatting methods,
    /// and validation for unsupported enum values.
    /// </summary>
    [TestClass]
    public class LengthUnitTests
    {
        private LengthUnitExtensions _helper = null!;

        [TestInitialize]
        public void Init()
        {
            _helper = new LengthUnitExtensions();
        }

        // Verify conversion factor for FEET returns base value (1.0)
        [TestMethod]
        public void ConversionFactor_Feet_ReturnsOne()
        {
            double result = _helper.GetConversionFactorToFeet(LengthUnit.FEET);
            Assert.AreEqual(1.0, result, 0.0001);
        }

        // Verify conversion factor for INCH equals 1/12
        [TestMethod]
        public void ConversionFactor_Inch_ReturnsOneDividedByTwelve()
        {
            double result = _helper.GetConversionFactorToFeet(LengthUnit.INCH);
            Assert.AreEqual(1.0 / 12.0, result, 0.0001);
        }

        // Verify conversion factor for YARD equals 3 feet
        [TestMethod]
        public void ConversionFactor_Yard_ReturnsThree()
        {
            double result = _helper.GetConversionFactorToFeet(LengthUnit.YARD);
            Assert.AreEqual(3.0, result, 0.0001);
        }

        // Verify conversion factor for CENTIMETER matches precise calculation
        [TestMethod]
        public void ConversionFactor_Centimeter_ReturnsExpectedFeetValue()
        {
            double result = _helper.GetConversionFactorToFeet(LengthUnit.CENTIMETER);

            // 1 cm = 1 / (2.54 * 12) feet = 1 / 30.48 feet
            double expected = 1.0 / 30.48;

            Assert.AreEqual(expected, result, 0.0000001);
        }

        // Validate short symbol for FEET
        [TestMethod]
        public void UnitSymbol_Feet_ReturnsFt()
        {
            string symbol = LengthUnitExtensions.GetUnitSymbol(LengthUnit.FEET);
            Assert.AreEqual("ft", symbol);
        }

        // Validate short symbol for INCH
        [TestMethod]
        public void UnitSymbol_Inch_ReturnsIn()
        {
            string symbol = LengthUnitExtensions.GetUnitSymbol(LengthUnit.INCH);
            Assert.AreEqual("in", symbol);
        }

        // Validate short symbol for YARD
        [TestMethod]
        public void UnitSymbol_Yard_ReturnsYd()
        {
            string symbol = LengthUnitExtensions.GetUnitSymbol(LengthUnit.YARD);
            Assert.AreEqual("yd", symbol);
        }

        // Validate short symbol for CENTIMETER
        [TestMethod]
        public void UnitSymbol_Centimeter_ReturnsCm()
        {
            string symbol = LengthUnitExtensions.GetUnitSymbol(LengthUnit.CENTIMETER);
            Assert.AreEqual("cm", symbol);
        }

        // Validate full name for FEET
        [TestMethod]
        public void UnitName_Feet_ReturnsFeet()
        {
            string name = LengthUnitExtensions.GetUnitName(LengthUnit.FEET);
            Assert.AreEqual("feet", name);
        }

        // Validate full name for INCH
        [TestMethod]
        public void UnitName_Inch_ReturnsInches()
        {
            string name = LengthUnitExtensions.GetUnitName(LengthUnit.INCH);
            Assert.AreEqual("inches", name);
        }

        // Validate full name for YARD
        [TestMethod]
        public void UnitName_Yard_ReturnsYards()
        {
            string name = LengthUnitExtensions.GetUnitName(LengthUnit.YARD);
            Assert.AreEqual("yards", name);
        }

        // Validate full name for CENTIMETER
        [TestMethod]
        public void UnitName_Centimeter_ReturnsCentimeters()
        {
            string name = LengthUnitExtensions.GetUnitName(LengthUnit.CENTIMETER);
            Assert.AreEqual("centimeters", name);
        }

        // Ensure invalid enum value throws ArgumentException
        [TestMethod]
        public void ConversionFactor_InvalidEnum_ThrowsArgumentException()
        {
            LengthUnit unknown = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() =>
                _helper.GetConversionFactorToFeet(unknown)
            );
        }
    }
}