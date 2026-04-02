
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Enums;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityExtendedTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Add_LengthWithSameUnit_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(3.0, LengthUnit.FEET);

            var result = first.Add(second);

            Assert.AreEqual(5.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_LengthWithDifferentUnits_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.INCH);

            var result = first.Add(second);

            Assert.AreEqual(1.17, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_WeightWithDifferentUnits_ReturnsCorrectResult()
        {
            var first = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(500.0, WeightUnit.GRAM);

            var result = first.Add(second);

            Assert.AreEqual(1.5, result.Value, Precision);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void Add_VolumeWithDifferentUnits_ReturnsCorrectResult()
        {
            var first = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(500.0, VolumeUnit.MILLILITRE);

            var result = first.Add(second);

            Assert.AreEqual(2.5, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.LITRE, result.Unit);
        }

        [TestMethod]
        public void Add_WithExplicitTargetUnit_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Add(second, LengthUnit.INCH);

            Assert.AreEqual(18.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Subtract_LengthWithSameUnit_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(4.0, LengthUnit.FEET);

            var result = first.Subtract(second);

            Assert.AreEqual(6.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Subtract_LengthWithDifferentUnits_ReturnsCorrectResult()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Subtract(second);

            Assert.AreEqual(9.5, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Subtract_WithExplicitTargetUnit_ReturnsCorrectResult()
        {
            var first = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);

            var result = first.Subtract(second, VolumeUnit.MILLILITRE);

            Assert.AreEqual(3000.0, result.Value, Precision);
            Assert.AreEqual(VolumeUnit.MILLILITRE, result.Unit);
        }

        [TestMethod]
        public void Divide_SameUnit_ReturnsCorrectRatio()
        {
            var first = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(5.0, WeightUnit.KILOGRAM);

            var result = first.Divide(second);

            Assert.AreEqual(2.0, result, Precision);
        }

        [TestMethod]
        public void Divide_DifferentUnits_ReturnsCorrectRatio()
        {
            var first = new Quantity<LengthUnit>(24.0, LengthUnit.INCH);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            var result = first.Divide(second);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Add_DoesNotChangeOriginalObjects()
        {
            var first = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Add(second);

            Assert.AreEqual(2.0, first.Value, Precision);
            Assert.AreEqual(6.0, second.Value, Precision);
            Assert.AreEqual(2.5, result.Value, Precision);
        }

        [TestMethod]
        public void Subtract_DoesNotChangeOriginalObjects()
        {
            var first = new Quantity<WeightUnit>(10.0, WeightUnit.KILOGRAM);
            var second = new Quantity<WeightUnit>(2.0, WeightUnit.KILOGRAM);

            var result = first.Subtract(second);

            Assert.AreEqual(10.0, first.Value, Precision);
            Assert.AreEqual(2.0, second.Value, Precision);
            Assert.AreEqual(8.0, result.Value, Precision);
        }

        [TestMethod]
        public void Divide_DoesNotChangeOriginalObjects()
        {
            var first = new Quantity<VolumeUnit>(10.0, VolumeUnit.LITRE);
            var second = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);

            var result = first.Divide(second);

            Assert.AreEqual(10.0, first.Value, Precision);
            Assert.AreEqual(5.0, second.Value, Precision);
            Assert.AreEqual(2.0, result, Precision);
        }
    }
}
