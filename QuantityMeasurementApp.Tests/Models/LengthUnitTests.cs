using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests for LengthUnit enum and its extension methods.
    /// Ensures correct conversion factors, symbols, and exception handling for invalid enums.
    /// </summary>
    [TestClass]
    public class LengthUnitTests
    {
        [TestMethod]
        public void ToFeetFactor_ForFeet_ShouldReturnOne()
        {
            double factor = LengthUnit.FEET.ToFeetFactor();
            Assert.AreEqual(1.0, factor, 0.0001);
        }

        [TestMethod]
        public void ToFeetFactor_ForInch_ShouldReturnOneTwelfth()
        {
            double factor = LengthUnit.INCH.ToFeetFactor();
            Assert.AreEqual(1.0 / 12.0, factor, 0.0001);
        }

        [TestMethod]
        public void Symbol_ForFeet_ShouldReturnFt()
        {
            string symbol = LengthUnit.FEET.GetSymbol();
            Assert.AreEqual("ft", symbol);
        }

        [TestMethod]
        public void Symbol_ForInch_ShouldReturnIn()
        {
            string symbol = LengthUnit.INCH.GetSymbol();
            Assert.AreEqual("in", symbol);
        }

        [TestMethod]
        public void ToFeetFactor_InvalidEnum_ShouldThrowArgumentException()
        {
            LengthUnit invalid = (LengthUnit)99;
            bool exceptionThrown = false;

            try
            {
                invalid.ToFeetFactor();
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown, "Expected ArgumentException was not thrown.");
        }
    }
}