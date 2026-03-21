using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class GenericQuantityTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Generic_LengthEquality_ReturnsTrue()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Generic_WeightEquality_ReturnsTrue()
        {
            var first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Generic_VolumeEquality_ReturnsTrue()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.785, result.Value, 0.01);
        }

        [TestMethod]
        public void Generic_TemperatureEquality_ReturnsTrue()
        {
            var first = new Quantity<TemperatureScale>(0.0, TemperatureScale.CELSIUS);
            var second = new Quantity<TemperatureScale>(32.0, TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Generic_LengthConversion_ReturnsCorrect()
        {
            var quantity = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Precision);
        }

        [TestMethod]
        public void Generic_WeightConversion_ReturnsCorrect()
        {
            var quantity = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var result = quantity.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, Precision);
        }

        [TestMethod]
        public void Generic_VolumeConversion_ReturnsCorrect()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.785, result.Value, 0.01);
        }

        [TestMethod]
        public void Generic_TemperatureConversion_ReturnsCorrect()
        {
            var quantity = new Quantity<TemperatureScale>(0.0, TemperatureScale.CELSIUS);
            var result = quantity.ConvertTo(TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(32.0, result.Value, Precision);
        }
    }
}