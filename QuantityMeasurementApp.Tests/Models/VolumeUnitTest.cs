using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class VolumeUnitTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Litre_ToBaseUnit_ReturnsSameValue()
        {
            double result = VolumeUnit.LITRE.ToBaseUnit(1.0);
            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Millilitre_ToBaseUnit_ReturnsCorrectValue()
        {
            double result = VolumeUnit.MILLILITRE.ToBaseUnit(1000.0);
            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Gallon_ToBaseUnit_ReturnsCorrectValue()
        {
            double result = VolumeUnit.GALLON.ToBaseUnit(1.0);
            Assert.AreEqual(3.78541, result, Precision);
        }

        [TestMethod]
        public void Litre_FromBaseUnit_ReturnsSameValue()
        {
            double result = VolumeUnit.LITRE.FromBaseUnit(1.0);
            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Millilitre_FromBaseUnit_ReturnsCorrectValue()
        {
            double result = VolumeUnit.MILLILITRE.FromBaseUnit(1.0);
            Assert.AreEqual(1000.0, result, Precision);
        }

        [TestMethod]
        public void Gallon_FromBaseUnit_ReturnsCorrectValue()
        {
            double result = VolumeUnit.GALLON.FromBaseUnit(3.78541);
            Assert.AreEqual(1.0, result, Precision);
        }
    }
}