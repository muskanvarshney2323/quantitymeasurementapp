using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Extensions;
namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class WeightUnitTests
    {
        private const double Precision = 0.000001;

        [TestMethod]
        public void ToKilogramFactor_Kilogram_ReturnsOne()
        {
            Assert.AreEqual(1.0, WeightUnit.KILOGRAM.ToKilogramFactor(), Precision);
        }

        [TestMethod]
        public void ToKilogramFactor_Gram_ReturnsCorrectFactor()
        {
            Assert.AreEqual(0.001, WeightUnit.GRAM.ToKilogramFactor(), Precision);
        }

        [TestMethod]
        public void ToKilogramFactor_Pound_ReturnsCorrectFactor()
        {
            Assert.AreEqual(0.453592, WeightUnit.POUND.ToKilogramFactor(), Precision);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Gram_ReturnsKilogramValue()
        {
            double result = WeightUnit.GRAM.ConvertToBaseUnit(1000.0);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Pound_ReturnsCorrectValue()
        {
            double result = WeightUnit.POUND.ConvertFromBaseUnit(1.0);

            Assert.AreEqual(2.2046244201837775, result, Precision);
        }
    }
}