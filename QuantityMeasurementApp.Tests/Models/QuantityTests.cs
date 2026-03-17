using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;
using System;

namespace QuantityMeasurementApp.Tests
{
    [TestClass]
    public class QuantityTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Equality_SameLengthValue_ReturnsTrue()
        {
            Quantity<LengthUnit> first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_FeetAndInchEquivalent_ReturnsTrue()
        {
            Quantity<LengthUnit> feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> inch = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.AreEqual(feet, inch);
        }

        [TestMethod]
        public void Equality_FeetAndYardNotEquivalent_ReturnsFalse()
        {
            Quantity<LengthUnit> feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> yard = new Quantity<LengthUnit>(1.0, LengthUnit.YARD);

            Assert.AreNotEqual(feet, yard);
        }

        [TestMethod]
        public void Equality_SameWeightValue_ReturnsTrue()
        {
            Quantity<WeightUnit> first = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);
            Quantity<WeightUnit> second = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_KilogramAndGramEquivalent_ReturnsTrue()
        {
            Quantity<WeightUnit> kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> gram = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.AreEqual(kilogram, gram);
        }

        [TestMethod]
        public void ConvertTo_LengthUnit_ReturnsConvertedQuantity()
        {
            Quantity<LengthUnit> feet = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Quantity<LengthUnit> result = feet.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_WeightUnit_ReturnsConvertedQuantity()
        {
            Quantity<WeightUnit> kilogram = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Quantity<WeightUnit> result = kilogram.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void Add_LengthQuantities_ReturnsResultInSameUnit()
        {
            Quantity<LengthUnit> first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Quantity<LengthUnit> result = first.Add(second);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_LengthQuantities_WithTargetUnit_ReturnsExpectedResult()
        {
            Quantity<LengthUnit> first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Quantity<LengthUnit> result = first.Add(second, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Add_WeightQuantities_WithTargetUnit_ReturnsExpectedResult()
        {
            Quantity<WeightUnit> first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            Quantity<WeightUnit> second = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Quantity<WeightUnit> result = first.Add(second, WeightUnit.KILOGRAM);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Constructor_InvalidEnumValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Quantity<LengthUnit>(1.0, (LengthUnit)999);
            });
        }

        [TestMethod]
        public void Constructor_NaNValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Quantity<LengthUnit>(double.NaN, LengthUnit.FEET);
            });
        }

        [TestMethod]
        public void Constructor_InfiniteValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = new Quantity<WeightUnit>(double.PositiveInfinity, WeightUnit.GRAM);
            });
        }

        [TestMethod]
        public void GetHashCode_EqualLengthQuantities_ReturnSameHashCode()
        {
            Quantity<LengthUnit> first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            Quantity<LengthUnit> second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void ToString_ReturnsReadableFormat()
        {
            Quantity<LengthUnit> quantity = new Quantity<LengthUnit>(5.0, LengthUnit.YARD);

            string result = quantity.ToString();

            Assert.AreEqual("Quantity(Value=5, Unit=YARD)", result);
        }
    }
}