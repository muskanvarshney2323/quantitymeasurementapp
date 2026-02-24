using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests for verifying LengthUnit-related functionality,
    /// including conversion factors, unit symbols, unit names,
    /// and handling of invalid enum values.
    /// </summary>
    [TestClass]
    public class LengthUnitTests
    {
        private UnitConverter _unitConverter = null!;

        /// <summary>
        /// Initializes required objects before each test runs.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _unitConverter = new UnitConverter();
        }

        /// <summary>
        /// Verifies that FEET returns a conversion factor of 1.0.
        /// </summary>
        [TestMethod]
        public void GetConversionFactorToFeet_FeetUnit_ReturnsOne()
        {
            double factor = _unitConverter.GetConversionFactorToFeet(LengthUnit.FEET);
            Assert.AreEqual(1.0, factor, 0.0001);
        }

        /// <summary>
        /// Verifies that INCH returns a conversion factor of 1/12.
        /// </summary>
        [TestMethod]
        public void GetConversionFactorToFeet_InchUnit_ReturnsOneTwelfth()
        {
            double factor = _unitConverter.GetConversionFactorToFeet(LengthUnit.INCH);
            Assert.AreEqual(1.0 / 12.0, factor, 0.0001);
        }

        /// <summary>
        /// Verifies that YARD returns a conversion factor of 3.0.
        /// </summary>
        [TestMethod]
        public void GetConversionFactorToFeet_YardUnit_ReturnsThree()
        {
            double factor = _unitConverter.GetConversionFactorToFeet(LengthUnit.YARD);
            Assert.AreEqual(3.0, factor, 0.0001);
        }

        /// <summary>
        /// Verifies that CENTIMETER returns the correct conversion factor to feet.
        /// </summary>
        [TestMethod]
        public void GetConversionFactorToFeet_CentimeterUnit_ReturnsCorrectValue()
        {
            double factor = _unitConverter.GetConversionFactorToFeet(LengthUnit.CENTIMETER);

            // 1 cm = 1 / (2.54 × 12) feet = 1 / 30.48 feet
            double expected = 0.0328083989501312;

            Assert.AreEqual(expected, factor, 0.0000001);
        }

        /// <summary>
        /// Verifies that FEET returns the symbol "ft".
        /// </summary>
        [TestMethod]
        public void GetUnitSymbol_FeetUnit_ReturnsFt()
        {
            string symbol = LengthUnit.FEET.GetUnitSymbol();
            Assert.AreEqual("ft", symbol);
        }

        /// <summary>
        /// Verifies that INCH returns the symbol "in".
        /// </summary>
        [TestMethod]
        public void GetUnitSymbol_InchUnit_ReturnsIn()
        {
            string symbol = LengthUnit.INCH.GetUnitSymbol();
            Assert.AreEqual("in", symbol);
        }

        /// <summary>
        /// Verifies that YARD returns the symbol "yd".
        /// </summary>
        [TestMethod]
        public void GetUnitSymbol_YardUnit_ReturnsYd()
        {
            string symbol = LengthUnit.YARD.GetUnitSymbol();
            Assert.AreEqual("yd", symbol);
        }

        /// <summary>
        /// Verifies that CENTIMETER returns the symbol "cm".
        /// </summary>
        [TestMethod]
        public void GetUnitSymbol_CentimeterUnit_ReturnsCm()
        {
            string symbol = LengthUnit.CENTIMETER.GetUnitSymbol();
            Assert.AreEqual("cm", symbol);
        }

        /// <summary>
        /// Verifies that FEET returns the full name "feet".
        /// </summary>
        [TestMethod]
        public void GetUnitName_FeetUnit_ReturnsFeet()
        {
            string name = LengthUnit.FEET.GetUnitName();
            Assert.AreEqual("feet", name);
        }

        /// <summary>
        /// Verifies that INCH returns the full name "inches".
        /// </summary>
        [TestMethod]
        public void GetUnitName_InchUnit_ReturnsInches()
        {
            string name = LengthUnit.INCH.GetUnitName();
            Assert.AreEqual("inches", name);
        }

        /// <summary>
        /// Verifies that YARD returns the full name "yards".
        /// </summary>
        [TestMethod]
        public void GetUnitName_YardUnit_ReturnsYards()
        {
            string name = LengthUnit.YARD.GetUnitName();
            Assert.AreEqual("yards", name);
        }

        /// <summary>
        /// Verifies that CENTIMETER returns the full name "centimeters".
        /// </summary>
        [TestMethod]
        public void GetUnitName_CentimeterUnit_ReturnsCentimeters()
        {
            string name = LengthUnit.CENTIMETER.GetUnitName();
            Assert.AreEqual("centimeters", name);
        }

        /// <summary>
        /// Ensures that requesting a conversion factor
        /// for an undefined enum value throws an ArgumentException.
        /// </summary>
        [TestMethod]
        public void GetConversionFactorToFeet_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() =>
                _unitConverter.GetConversionFactorToFeet(invalidUnit)
            );
        }
    }
}