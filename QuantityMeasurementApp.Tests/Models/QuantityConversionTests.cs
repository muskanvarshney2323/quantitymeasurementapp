using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionTests
    {
        private const double Delta = 0.000001;

        [TestMethod]
        public void FeetToInch_ConvertsCorrectly()
        {
            Quantity quantity = new Quantity(1.0, LengthUnit.FEET);
            Quantity result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Delta);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void InchToFeet_ConvertsCorrectly()
        {
            Quantity quantity = new Quantity(24.0, LengthUnit.INCH);
            Quantity result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, Delta);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void YardToFeet_ConvertsCorrectly()
        {
            Quantity quantity = new Quantity(1.0, LengthUnit.YARD);
            Quantity result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(3.0, result.Value, Delta);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void CentimeterToInch_ConvertsCorrectly()
        {
            Quantity quantity = new Quantity(2.54, LengthUnit.CENTIMETER);
            Quantity result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(1.0, result.Value, Delta);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_SameUnit_ReturnsSameValue()
        {
            Quantity quantity = new Quantity(5.0, LengthUnit.FEET);
            Quantity result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(5.0, result.Value, Delta);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }
    }
}