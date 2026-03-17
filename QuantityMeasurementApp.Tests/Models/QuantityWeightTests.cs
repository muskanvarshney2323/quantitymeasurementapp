using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;


namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityWeightTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Equality_SameKilogramValue_ReturnsTrue()
        {
            var first = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_KilogramAndGramEquivalent_ReturnsTrue()
        {
            var kilogram = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var gram = new QuantityWeight(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(kilogram, gram);
        }

        [TestMethod]
        public void Equality_KilogramAndPoundEquivalent_ReturnsTrue()
        {
            var kilogram = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var pound = new QuantityWeight(2.20462, WeightUnit.POUND);

            Assert.AreEqual(kilogram, pound);
        }
        [TestMethod]
        public void Equality_DifferentValues_ReturnsFalse()
        {
            var first = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(2.0, WeightUnit.KILOGRAM);

            Assert.AreNotEqual(first, second);
        }

        [TestMethod]
        public void Equality_WithNull_ReturnsFalse()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(weight.Equals(null));
        }

        [TestMethod]
        public void Conversion_KilogramToGram_ReturnsCorrectValue()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void Conversion_PoundToKilogram_ReturnsCorrectValue()
        {
            var weight = new QuantityWeight(2.0, WeightUnit.POUND);

            var result = weight.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(0.907184, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Conversion_SameUnit_ReturnsSameValue()
        {
            var weight = new QuantityWeight(5.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Addition_SameUnit_ReturnsCorrectResult()
        {
            var first = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(2.0, WeightUnit.KILOGRAM);

            var result = first.Add(second);

            Assert.AreEqual(3.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Addition_KilogramAndGram_ReturnsResultInFirstUnit()
        {
            var first = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(1000.0, WeightUnit.GRAM);

            var result = first.Add(second);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Addition_WithExplicitTargetUnit_ReturnsCorrectResult()
        {
            var first = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(1000.0, WeightUnit.GRAM);

            var result = first.Add(second, WeightUnit.GRAM);

            Assert.AreEqual(2000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void Addition_WithZero_ReturnsSameValue()
        {
            var first = new QuantityWeight(5.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(0.0, WeightUnit.GRAM);

            var result = first.Add(second);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Addition_NegativeValue_ReturnsCorrectResult()
        {
            var first = new QuantityWeight(5.0, WeightUnit.KILOGRAM);
            var second = new QuantityWeight(-2000.0, WeightUnit.GRAM);

            var result = first.Add(second);

            Assert.AreEqual(3.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Constructor_InvalidNaNValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuantityWeight(double.NaN, WeightUnit.KILOGRAM));
        }

        [TestMethod]
        public void Constructor_InvalidInfinityValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuantityWeight(double.PositiveInfinity, WeightUnit.KILOGRAM));
        }
    }
}