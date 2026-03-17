using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services
{
    [TestClass]
    public class QuantityMeasurementServiceTests
    {
        [TestMethod]
        public void AreLengthsEqual_EquivalentValues_ReturnsTrue()
        {
            var service = new QuantityMeasurementService();

            bool result = service.AreLengthsEqual(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertLength_FeetToInch_ReturnsCorrectValue()
        {
            var service = new QuantityMeasurementService();

            double result = service.ConvertLength(1.0, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(12.0, result, 0.000001);
        }

        [TestMethod]
        public void AddLengths_ReturnsCorrectResult()
        {
            var service = new QuantityMeasurementService();

            var result = service.AddLengths(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH);

            Assert.AreEqual(2.0, result.Value, 0.000001);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }
    }
}