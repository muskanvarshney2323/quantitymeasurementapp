using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void ConvertTo_FeetToInch_ReturnsCorrectValue()
        {
            var quantity = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            var result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_InchToFeet_ReturnsCorrectValue()
        {
            var quantity = new Quantity<LengthUnit>(24.0, LengthUnit.INCH);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_YardToFeet_ReturnsCorrectValue()
        {
            var quantity = new Quantity<LengthUnit>(2.0, LengthUnit.YARD);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(6.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_CentimeterToFeet_ReturnsCorrectValue()
        {
            var quantity = new Quantity<LengthUnit>(30.48, LengthUnit.CENTIMETER);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_KilogramToGram_ReturnsCorrectValue()
        {
            var quantity = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);

            var result = quantity.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(2000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_GramToKilogram_ReturnsCorrectValue()
        {
            var quantity = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = quantity.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_LitreToMillilitre_ReturnsCorrectValue()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var result = quantity.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_MillilitreToLitre_ReturnsCorrectValue()
        {
            var quantity = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_GallonToLitre_ReturnsCorrectValue()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);

            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.78541, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Equality_FeetAndInchEquivalent_ReturnsTrue()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_KilogramAndGramEquivalent_ReturnsTrue()
        {
            var first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_LitreAndMillilitreEquivalent_ReturnsTrue()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_DifferentValues_ReturnsFalse()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(10.0, LengthUnit.INCH);

            Assert.AreNotEqual(first, second);
        }

        [TestMethod]
        public void ConvertTo_InvalidLengthUnit_ThrowsException()
        {
            var quantity = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<System.ArgumentException>(() => quantity.ConvertTo(invalidUnit));
        }

        [TestMethod]
        public void ConvertTo_InvalidWeightUnit_ThrowsException()
        {
            var quantity = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var invalidUnit = (WeightUnit)999;

            Assert.ThrowsException<System.ArgumentException>(() => quantity.ConvertTo(invalidUnit));
        }

        [TestMethod]
        public void ConvertTo_InvalidVolumeUnit_ThrowsException()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var invalidUnit = (VolumeUnit)999;

            Assert.ThrowsException<System.ArgumentException>(() => quantity.ConvertTo(invalidUnit));
        }
    }
}