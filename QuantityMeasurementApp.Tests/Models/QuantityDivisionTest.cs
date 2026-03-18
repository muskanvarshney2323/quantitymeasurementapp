using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp;
using QuantityMeasurementApp.Enums;
using System;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityDivisionTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Divide_SameUnit_ReturnsCorrectRatio()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            double result = first.Divide(second);

            Assert.AreEqual(5.0, result, Precision);
        }

        [TestMethod]
        public void Divide_CrossUnit_ReturnsCorrectRatio()
        {
            var first = new Quantity<LengthUnit>(24.0, LengthUnit.INCH);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            double result = first.Divide(second);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Divide_RatioGreaterThanOne_ReturnsCorrectValue()
        {
            var first = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(5.0, WeightUnit.KILOGRAM);

            double result = first.Divide(second);

            Assert.AreEqual(2.0, result, Precision);
        }

        [TestMethod]
        public void Divide_RatioLessThanOne_ReturnsCorrectValue()
        {
            var first = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(10.0, VolumeUnit.LITRE);

            double result = first.Divide(second);

            Assert.AreEqual(0.5, result, Precision);
        }

        [TestMethod]
        public void Divide_EquivalentQuantities_ReturnsOne()
        {
            var first = new Quantity<WeightUnit>(2000.0, WeightUnit.GRAM);
            var second = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);

            double result = first.Divide(second);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);

            Assert.ThrowsException<ArithmeticException>(() => first.Divide(second));
        }

        [TestMethod]
        public void Divide_WithNullOperand_ThrowsException()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            Assert.ThrowsException<ArgumentException>(() => first.Divide(null!));
        }

        [TestMethod]
        public void Divide_DoesNotChangeOriginalObjects()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            double result = first.Divide(second);

            Assert.AreEqual(10.0, first.Value, Precision);
            Assert.AreEqual(5.0, second.Value, Precision);
            Assert.AreEqual(2.0, result, Precision);
        }

        [TestMethod]
        public void Divide_WorksForVolume()
        {
            var first = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var second = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            double result = first.Divide(second);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Divide_NonCommutative_BehavesCorrectly()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

            double forward = first.Divide(second);
            double reverse = second.Divide(first);

            Assert.AreEqual(2.0, forward, Precision);
            Assert.AreEqual(0.5, reverse, Precision);
        }
    }
}