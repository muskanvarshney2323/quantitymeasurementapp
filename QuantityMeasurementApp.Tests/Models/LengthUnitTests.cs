using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Contains unit tests for the LengthUnit enum and its extension methods.
    /// Validates that GetConversionFactorToFeet() and GetUnitSymbol() work correctly.
    /// </summary>
    [TestClass]
    public class LengthUnitTests
    {
        // Ensures FEET unit returns correct conversion factor (1.0)
        [TestMethod]
        public void GetConversionFactorToFeet_ForFeet_ShouldReturnOne()
        {
            double factor = LengthUnit.FEET.GetConversionFactorToFeet();
            Assert.AreEqual(1.0, factor, 0.0001);
        }

        // Ensures INCH unit returns correct conversion factor (1/12)
        [TestMethod]
        public void GetConversionFactorToFeet_ForInch_ShouldReturnOneTwelfth()
        {
            double factor = LengthUnit.INCH.GetConversionFactorToFeet();
            Assert.AreEqual(1.0 / 12.0, factor, 0.0001);
        }

        // Verifies that FEET unit symbol is correctly returned
        [TestMethod]
        public void GetUnitSymbol_ForFeet_ShouldReturnFt()
        {
            string symbol = LengthUnit.FEET.GetUnitSymbol();
            Assert.AreEqual("ft", symbol);
        }

        // Verifies that INCH unit symbol is correctly returned
        [TestMethod]
        public void GetUnitSymbol_ForInch_ShouldReturnIn()
        {
            string symbol = LengthUnit.INCH.GetUnitSymbol();
            Assert.AreEqual("in", symbol);
        }

        // Confirms that using an invalid enum value throws an exception
        [TestMethod]
        public void GetConversionFactorToFeet_InvalidEnum_ShouldThrowException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;
            Assert.ThrowsException<ArgumentException>(() =>
                invalidUnit.GetConversionFactorToFeet()
            );
        }
    }
}