using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityAdditionEdgeCasesTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Add_ZeroValues_ReturnsZero()
        {
            var first = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);

            var result = first.Add(second);

            Assert.AreEqual(0.0, result.Value, Precision);
        }

        [TestMethod]
        public void Add_ZeroAndNonZero_ReturnsOriginalValue()
        {
            var first = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.0, LengthUnit.INCH);

            var result = first.Add(second);

            Assert.AreEqual(5.0, result.Value, Precision);
        }

        [TestMethod]
        public void Add_NegativeAndPositiveValues_ReturnsCorrectResult()
        {
            var first = new Quantity<WeightUnit>(5.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(-2.0, WeightUnit.KILOGRAM);

            var result = first.Add(second);

            Assert.AreEqual(3.0, result.Value, Precision);
        }

        [TestMethod]
        public void Add_TwoNegativeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<WeightUnit>(-2.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(-3.0, WeightUnit.KILOGRAM);

            var result = first.Add(second);

            Assert.AreEqual(-5.0, result.Value, Precision);
        }

        [TestMethod]
        public void Add_LargeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<WeightUnit>(1000000.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(500000.0, WeightUnit.KILOGRAM);

            var result = first.Add(second);

            Assert.AreEqual(1500000.0, result.Value, Precision);
        }

        [TestMethod]
        public void Add_SmallValues_ReturnsRoundedResult()
        {
            var first = new Quantity<LengthUnit>(0.001, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.001, LengthUnit.FEET);

            var result = first.Add(second);

            Assert.AreEqual(0.0, result.Value, 0.01);
        }

        [TestMethod]
        public void Add_DifferentUnitsWithExplicitTarget_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);

            var result = first.Add(second, LengthUnit.INCH);

            Assert.AreEqual(14.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Add_NullOperand_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.ThrowsException<ArgumentException>(() => first.Add(null!));
        }

        [TestMethod]
        public void Add_InvalidTargetUnit_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);
            var invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => first.Add(second, invalidUnit));
        }

        [TestMethod]
        public void Constructor_NaNValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Quantity<LengthUnit>(double.NaN, LengthUnit.FEET));
        }

        [TestMethod]
        public void Constructor_InfiniteValue_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Quantity<WeightUnit>(double.PositiveInfinity, WeightUnit.KILOGRAM));
        }

        [TestMethod]
        public void Add_VolumeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(500.0, VolumeUnit.MILLILITRE);

            var result = first.Add(second);

            Assert.AreEqual(1.5, result.Value, Precision);
        }
    }
}