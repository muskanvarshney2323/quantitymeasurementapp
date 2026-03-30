

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityAdditionTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Add_FeetAndInch_ReturnsCorrectValueInFeet()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = feet.Add(inch);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_KilogramAndGram_ReturnsCorrectValueInKilogram()
        {
            var kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = kilogram.Add(gram);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Add_LitreAndMillilitre_ReturnsCorrectValueInLitre()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = litre.Add(millilitre);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Add_LitreAndMillilitre_WithExplicitTargetUnit_ReturnsCorrectValue()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = litre.Add(millilitre, VolumeUnit.MILLILITRE);

            Assert.AreEqual(2000.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }
    }
}
