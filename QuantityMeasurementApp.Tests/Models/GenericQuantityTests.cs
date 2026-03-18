using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityTests
    {
        private const double Precision = 0.0001;

        // -----------------------------
        // Length Equality Tests
        // -----------------------------

        [TestMethod]
        public void Equality_SameFeetValue_ReturnsTrue()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_FeetAndInchEquivalent_ReturnsTrue()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.AreEqual(feet, inch);
        }

        [TestMethod]
        public void Equality_FeetAndYardEquivalent_ReturnsTrue()
        {
            var feet = new Quantity<LengthUnit>(3.0, LengthUnit.FEET);
            var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARD);

            Assert.AreEqual(feet, yard);
        }

        [TestMethod]
        public void Equality_DifferentLengthValues_ReturnsFalse()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            Assert.AreNotEqual(first, second);
        }

        // -----------------------------
        // Weight Equality Tests
        // -----------------------------

        [TestMethod]
        public void Equality_SameKilogramValue_ReturnsTrue()
        {
            var first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_KilogramAndGramEquivalent_ReturnsTrue()
        {
            var kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(kilogram, gram);
        }

        [TestMethod]
        public void Equality_DifferentWeightValues_ReturnsFalse()
        {
            var first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);

            Assert.AreNotEqual(first, second);
        }

        // -----------------------------
        // Volume Equality Tests
        // -----------------------------

        [TestMethod]
        public void Equality_SameLitreValue_ReturnsTrue()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_LitreAndMillilitreEquivalent_ReturnsTrue()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            Assert.AreEqual(litre, millilitre);
        }

        [TestMethod]
        public void Equality_GallonAndLitreEquivalent_ReturnsTrue()
        {
            var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Assert.AreEqual(gallon, litre);
        }

        [TestMethod]
        public void Equality_DifferentVolumeValues_ReturnsFalse()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);

            Assert.AreNotEqual(first, second);
        }

        // -----------------------------
        // Conversion Tests - Length
        // -----------------------------

        [TestMethod]
        public void Convert_FeetToInch_ReturnsCorrectValue()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            var result = feet.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Convert_YardToFeet_ReturnsCorrectValue()
        {
            var yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARD);

            var result = yard.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(3.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        // -----------------------------
        // Conversion Tests - Weight
        // -----------------------------

        [TestMethod]
        public void Convert_KilogramToGram_ReturnsCorrectValue()
        {
            var kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            var result = kilogram.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void Convert_GramToKilogram_ReturnsCorrectValue()
        {
            var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = gram.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        // -----------------------------
        // Conversion Tests - Volume
        // -----------------------------

        [TestMethod]
        public void Convert_LitreToMillilitre_ReturnsCorrectValue()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var result = litre.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void Convert_MillilitreToLitre_ReturnsCorrectValue()
        {
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = millilitre.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Convert_GallonToLitre_ReturnsCorrectValue()
        {
            var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);

            var result = gallon.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.78541, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Convert_LitreToGallon_ReturnsCorrectValue()
        {
            var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            var result = litre.ConvertTo(VolumeUnit.GALLON);

            Assert.AreEqual(1.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.GALLON, result.Unit);
        }

        // -----------------------------
        // Addition Tests - Length
        // -----------------------------

        [TestMethod]
        public void Add_FeetAndInch_ReturnsCorrectValueInFirstUnit()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = feet.Add(inch);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_LengthWithExplicitTargetUnit_ReturnsCorrectValue()
        {
            var feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = feet.Add(inch, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        // -----------------------------
        // Addition Tests - Weight
        // -----------------------------

        [TestMethod]
        public void Add_KilogramAndGram_ReturnsCorrectValueInFirstUnit()
        {
            var kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = kilogram.Add(gram);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Add_WeightWithExplicitTargetUnit_ReturnsCorrectValue()
        {
            var kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            var result = kilogram.Add(gram, WeightUnit.GRAM);

            Assert.AreEqual(2000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        // -----------------------------
        // Addition Tests - Volume
        // -----------------------------

        [TestMethod]
        public void Add_LitreAndMillilitre_ReturnsCorrectValueInFirstUnit()
        {
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = litre.Add(millilitre);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Add_MillilitreAndLitre_ReturnsCorrectValueInFirstUnit()
        {
            var millilitre = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var result = millilitre.Add(litre);

            Assert.AreEqual(2000.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
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

        [TestMethod]
        public void Add_GallonAndLitre_WithExplicitTargetUnit_ReturnsCorrectValue()
        {
            var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            var result = gallon.Add(litre, VolumeUnit.GALLON);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.GALLON, result.Unit);
        }

        // -----------------------------
        // Generic / Edge Tests
        // -----------------------------

        [TestMethod]
        public void Equality_SameReference_ReturnsTrue()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.AreEqual(quantity, quantity);
        }

        [TestMethod]
        public void Equality_WithNull_ReturnsFalse()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsFalse(quantity.Equals(null));
        }

        [TestMethod]
        public void Convert_SameUnit_ReturnsSameValue()
        {
            var quantity = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);

            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Add_ZeroVolume_ReturnsSameValue()
        {
            var first = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(0.0, VolumeUnit.MILLILITRE);

            var result = first.Add(second);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Add_NegativeVolume_ReturnsCorrectValue()
        {
            var first = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(-2000.0, VolumeUnit.MILLILITRE);

            var result = first.Add(second);

            Assert.AreEqual(3.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }
    }
}