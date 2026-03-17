using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityConversionEgdeCaseTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void ConvertTo_SameUnit_ReturnsSameValue()
        {
            var quantity = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_ZeroValue_ReturnsZero()
        {
            var quantity = new Quantity<WeightUnit>(0.0, WeightUnit.GRAM);

            var result = quantity.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(0.0, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_NegativeValue_ReturnsCorrectResult()
        {
            var quantity = new Quantity<WeightUnit>(-1000.0, WeightUnit.GRAM);

            var result = quantity.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(-1.0, result.Value, Precision);
        }

        [TestMethod]
        public void ConvertTo_LargeValue_ReturnsCorrectResult()
        {
            var quantity = new Quantity<VolumeUnit>(1000.0, VolumeUnit.GALLON);

            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3785.41, result.Value, 0.01);
        }

        [TestMethod]
        public void ConvertTo_SmallValue_ReturnsCorrectResult()
        {
            var quantity = new Quantity<VolumeUnit>(1.0, VolumeUnit.MILLILITRE);

            var result = quantity.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(0.001, result.Value, Precision);
        }

        [TestMethod]
        public void Constructor_InvalidEnum_ThrowsException()
        {
            var invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() =>
                new Quantity<LengthUnit>(1.0, invalidUnit));
        }

        [TestMethod]
        public void Equality_EquivalentConvertedValues_ReturnsTrue()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            Assert.AreEqual(first, second);
        }

        [TestMethod]
        public void Equality_DifferentCategoriesAreNotComparedInGenericDesign()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.AreNotEqual(length.GetType(), weight.GetType());
        }

        [TestMethod]
        public void ConvertTo_DoesNotChangeOriginalObject()
        {
            var quantity = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            var result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(2.0, quantity.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, quantity.Unit);
            Assert.AreEqual(24.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }
    }
}