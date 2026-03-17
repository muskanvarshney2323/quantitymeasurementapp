using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests for verifying LengthUnit-related functionality,
    /// including conversion factors, base-unit conversion,
    /// unit symbols, unit names, and invalid enum handling.
    /// </summary>
    [TestClass]
    public class LengthUnitTests
    {
        private const double Tolerance = 0.000001;

        /// <summary>
        /// Verifies that FEET returns a conversion factor of 1.0.
        /// </summary>
        [TestMethod]
        public void ToFeetFactor_FeetUnit_ReturnsOne()
        {
            double factor = LengthUnit.FEET.ToFeetFactor();
            Assert.AreEqual(1.0, factor, Tolerance);
        }

        /// <summary>
        /// Verifies that INCH returns a conversion factor of 1/12.
        /// </summary>
        [TestMethod]
        public void ToFeetFactor_InchUnit_ReturnsOneTwelfth()
        {
            double factor = LengthUnit.INCH.ToFeetFactor();
            Assert.AreEqual(1.0 / 12.0, factor, Tolerance);
        }

        /// <summary>
        /// Verifies that YARD returns a conversion factor of 3.0.
        /// </summary>
        [TestMethod]
        public void ToFeetFactor_YardUnit_ReturnsThree()
        {
            double factor = LengthUnit.YARD.ToFeetFactor();
            Assert.AreEqual(3.0, factor, Tolerance);
        }

        /// <summary>
        /// Verifies that CENTIMETER returns the correct conversion factor to feet.
        /// </summary>
        [TestMethod]
        public void ToFeetFactor_CentimeterUnit_ReturnsCorrectValue()
        {
            double factor = LengthUnit.CENTIMETER.ToFeetFactor();
            double expected = 1.0 / 30.48;

            Assert.AreEqual(expected, factor, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from FEET to base unit FEET.
        /// </summary>
        [TestMethod]
        public void ConvertToBaseUnit_Feet_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.ConvertToBaseUnit(5.0);
            Assert.AreEqual(5.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from INCH to base unit FEET.
        /// </summary>
        [TestMethod]
        public void ConvertToBaseUnit_Inch_ReturnsFeetValue()
        {
            double result = LengthUnit.INCH.ConvertToBaseUnit(12.0);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from YARD to base unit FEET.
        /// </summary>
        [TestMethod]
        public void ConvertToBaseUnit_Yard_ReturnsFeetValue()
        {
            double result = LengthUnit.YARD.ConvertToBaseUnit(1.0);
            Assert.AreEqual(3.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from CENTIMETER to base unit FEET.
        /// </summary>
        [TestMethod]
        public void ConvertToBaseUnit_Centimeter_ReturnsFeetValue()
        {
            double result = LengthUnit.CENTIMETER.ConvertToBaseUnit(30.48);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from base unit FEET to FEET.
        /// </summary>
        [TestMethod]
        public void ConvertFromBaseUnit_Feet_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.ConvertFromBaseUnit(2.0);
            Assert.AreEqual(2.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from base unit FEET to INCH.
        /// </summary>
        [TestMethod]
        public void ConvertFromBaseUnit_Inch_ReturnsInchValue()
        {
            double result = LengthUnit.INCH.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(12.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from base unit FEET to YARD.
        /// </summary>
        [TestMethod]
        public void ConvertFromBaseUnit_Yard_ReturnsYardValue()
        {
            double result = LengthUnit.YARD.ConvertFromBaseUnit(3.0);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        /// <summary>
        /// Verifies conversion from base unit FEET to CENTIMETER.
        /// </summary>
        [TestMethod]
        public void ConvertFromBaseUnit_Centimeter_ReturnsCentimeterValue()
        {
            double result = LengthUnit.CENTIMETER.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(30.48, result, Tolerance);
        }

        /// <summary>
        /// Verifies that FEET returns the symbol "ft".
        /// </summary>
        [TestMethod]
        public void GetSymbol_FeetUnit_ReturnsFt()
        {
            string symbol = LengthUnit.FEET.GetSymbol();
            Assert.AreEqual("ft", symbol);
        }

        /// <summary>
        /// Verifies that INCH returns the symbol "in".
        /// </summary>
        [TestMethod]
        public void GetSymbol_InchUnit_ReturnsIn()
        {
            string symbol = LengthUnit.INCH.GetSymbol();
            Assert.AreEqual("in", symbol);
        }

        /// <summary>
        /// Verifies that YARD returns the symbol "yd".
        /// </summary>
        [TestMethod]
        public void GetSymbol_YardUnit_ReturnsYd()
        {
            string symbol = LengthUnit.YARD.GetSymbol();
            Assert.AreEqual("yd", symbol);
        }

        /// <summary>
        /// Verifies that CENTIMETER returns the symbol "cm".
        /// </summary>
        [TestMethod]
        public void GetSymbol_CentimeterUnit_ReturnsCm()
        {
            string symbol = LengthUnit.CENTIMETER.GetSymbol();
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
        public void ToFeetFactor_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() =>
                invalidUnit.ToFeetFactor()
            );
        }

        /// <summary>
        /// Ensures that converting an invalid unit to base unit throws an exception.
        /// </summary>
        [TestMethod]
        public void ConvertToBaseUnit_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() =>
                invalidUnit.ConvertToBaseUnit(10.0)
            );
        }

        /// <summary>
        /// Ensures that converting from base unit using an invalid unit throws an exception.
        /// </summary>
        [TestMethod]
        public void ConvertFromBaseUnit_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() =>
                invalidUnit.ConvertFromBaseUnit(10.0)
            );
        }
    }
}