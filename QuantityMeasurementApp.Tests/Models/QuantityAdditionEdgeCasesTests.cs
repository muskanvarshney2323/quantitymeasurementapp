using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Entities;
using System;

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

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(0.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_ZeroAndNonZero_ReturnsOriginalValue()
        {
            var first = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_NegativeAndPositiveValues_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(-2.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(3.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_TwoNegativeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(-2.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(-3.0, LengthUnit.FEET);

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(-5.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_LargeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(1000000.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2000000.0, LengthUnit.FEET);

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(3000000.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_SmallValues_ReturnsRoundedResult()
        {
            var first = new Quantity<LengthUnit>(0.1, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.2, LengthUnit.FEET);

            var result = first.Add(second, LengthUnit.FEET);

            Assert.AreEqual(0.3, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_DifferentUnitsWithExplicitTarget_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = first.Add(second, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Add_NullOperand_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.ThrowsException<ArgumentException>(() => first.Add(null, LengthUnit.FEET));
        }

        [TestMethod]
        public void Add_InvalidTargetUnit_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(1.0, LengthUnit.INCH);

            Assert.ThrowsException<ArgumentException>(() => first.Add(second, (LengthUnit)999));
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
                new Quantity<LengthUnit>(double.PositiveInfinity, LengthUnit.FEET));
        }

        [TestMethod]
        public void Add_VolumeValues_ReturnsCorrectResult()
        {
            var first = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var result = first.Add(second, VolumeUnit.LITRE);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }
    }
}