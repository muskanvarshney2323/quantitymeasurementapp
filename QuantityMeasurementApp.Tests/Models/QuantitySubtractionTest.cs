using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Enums;
using System;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantitySubtractionTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Subtract_SameUnit_FeetMinusFeet_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            var result = first.Subtract(second);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Subtract_CrossUnit_FeetMinusInch_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Subtract(second);

            Assert.AreEqual(9.5, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Subtract_ExplicitTargetUnit_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Subtract(second, LengthUnit.INCH);

            Assert.AreEqual(114.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Subtract_ResultCanBeNegative()
        {
            var first = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            var result = first.Subtract(second);

            Assert.AreEqual(-5.0, result.Value, Precision);
        }

        [TestMethod]
        public void Subtract_EquivalentQuantities_ReturnsZero()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(120.0, LengthUnit.INCH);

            var result = first.Subtract(second);

            Assert.AreEqual(0.0, result.Value, Precision);
        }

        [TestMethod]
        public void Subtract_WithNullOperand_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            Assert.ThrowsException<ArgumentException>(() => first.Subtract(null!));
        }

        [TestMethod]
        public void Subtract_WithNullTargetUnitStyleInvalidEnum_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => first.Subtract(second, invalidUnit));
        }

        [TestMethod]
        public void Subtract_DoesNotChangeOriginalObjects()
        {
            var first = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(5.0, WeightUnit.KILOGRAM);

            var result = first.Subtract(second);

            Assert.AreEqual(10.0, first.Value, Precision);
            Assert.AreEqual(5.0, second.Value, Precision);
            Assert.AreEqual(5.0, result.Value, Precision);
        }

        [TestMethod]
        public void Subtract_WorksForVolume()
        {
            var first = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(500.0, VolumeUnit.MILLILITRE);

            var result = first.Subtract(second);

            Assert.AreEqual(4.5, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Subtract_ChainedOperations_ReturnsCorrectResult()
        {
            var start = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            var result = start
                .Subtract(new Quantity<LengthUnit>(2.0, LengthUnit.FEET))
                .Subtract(new Quantity<LengthUnit>(1.0, LengthUnit.FEET));

            Assert.AreEqual(7.0, result.Value, Precision);
        }
    }
}