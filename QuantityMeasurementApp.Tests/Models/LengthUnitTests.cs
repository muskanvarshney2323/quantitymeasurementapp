using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class LengthUnitTests
    {
        private const double Delta = 0.0001;

        [TestMethod]
        public void Convert_FeetToInch_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(12.0, result, Delta);
        }

        [TestMethod]
        public void Convert_InchToFeet_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(12.0, LengthUnit.INCH, LengthUnit.FEET);

            Assert.AreEqual(1.0, result, Delta);
        }

        [TestMethod]
        public void Convert_YardToFeet_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.YARD, LengthUnit.FEET);

            Assert.AreEqual(3.0, result, Delta);
        }

        [TestMethod]
        public void Convert_CentimeterToInch_ReturnsCorrectValue()
        {
            double result = Quantity.Convert(2.54, LengthUnit.CENTIMETER, LengthUnit.INCH);

            Assert.AreEqual(1.0, result, Delta);
        }

        [TestMethod]
        public void Convert_SameUnit_ReturnsSameValue()
        {
            double result = Quantity.Convert(5.0, LengthUnit.FEET, LengthUnit.FEET);

            Assert.AreEqual(5.0, result, Delta);
        }
    }
}