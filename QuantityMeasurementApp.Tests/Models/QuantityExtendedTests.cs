using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityExtendedTests
    {
        private const double Delta = 0.000001;

        private static Quantity Create(double value, LengthUnit unit) => new Quantity(value, unit);

        private static void AssertEqualQuantity(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = Create(firstValue, firstUnit);
            var second = Create(secondValue, secondUnit);

            Assert.IsTrue(first.Equals(second));
        }

        private static void AssertNotEqualQuantity(double firstValue, LengthUnit firstUnit, double secondValue, LengthUnit secondUnit)
        {
            var first = Create(firstValue, firstUnit);
            var second = Create(secondValue, secondUnit);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_WhenYardValuesAreSame_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.YARD, 1.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Equals_WhenYardValuesAreDifferent_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.YARD, 2.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Equals_WhenOneYardComparedWithThreeFeet_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.YARD, 3.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Equals_WhenOneYardComparedWithThirtySixInches_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.YARD, 36.0, LengthUnit.INCH);
        }

        [TestMethod]
        public void Equals_WhenYardAndFeetAreNotEquivalent_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.YARD, 2.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Equals_WhenCentimeterValuesAreSame_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.CENTIMETER, 1.0, LengthUnit.CENTIMETER);
        }

        [TestMethod]
        public void Equals_WhenThirtyPointFourEightCentimeterComparedWithOneFoot_ShouldReturnTrue()
        {
            AssertEqualQuantity(30.48, LengthUnit.CENTIMETER, 1.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Equals_WhenNinetyOnePointFourFourCentimeterComparedWithOneYard_ShouldReturnTrue()
        {
            AssertEqualQuantity(91.44, LengthUnit.CENTIMETER, 1.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Equals_WhenOneCentimeterComparedWithOneInch_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.CENTIMETER, 1.0, LengthUnit.INCH);
        }

        [TestMethod]
        public void Equals_ShouldSatisfyTransitiveProperty_ForYardFeetAndInches()
        {
            var yard = Create(2.0, LengthUnit.YARD);
            var feet = Create(6.0, LengthUnit.FEET);
            var inches = Create(72.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void Equals_ShouldSatisfyTransitiveProperty_ForCentimeterInchAndFeet()
        {
            var centimeter = Create(30.48, LengthUnit.CENTIMETER);
            var inches = Create(12.0, LengthUnit.INCH);
            var feet = Create(1.0, LengthUnit.FEET);

            Assert.IsTrue(centimeter.Equals(inches));
            Assert.IsTrue(inches.Equals(feet));
            Assert.IsTrue(centimeter.Equals(feet));
        }

        [TestMethod]
        public void Equals_WhenComparedWithSameReference_ShouldReturnTrue()
        {
            var quantity = Create(5.0, LengthUnit.YARD);

            Assert.IsTrue(quantity.Equals(quantity));
        }

        [TestMethod]
        public void Equals_WhenComparedWithNull_ShouldReturnFalse()
        {
            var quantity = Create(5.0, LengthUnit.YARD);

            Assert.IsFalse(quantity.Equals(null));
        }

        [TestMethod]
        public void Equals_WhenComparedWithDifferentObjectType_ShouldReturnFalse()
        {
            var quantity = Create(5.0, LengthUnit.YARD);

            Assert.IsFalse(quantity.Equals(new object()));
        }

        [TestMethod]
        public void GetHashCode_WhenQuantitiesAreEquivalent_ShouldMatch()
        {
            var yard = Create(1.0, LengthUnit.YARD);
            var feet = Create(3.0, LengthUnit.FEET);

            Assert.AreEqual(yard.GetHashCode(), feet.GetHashCode());
        }

        [TestMethod]
        public void ToString_WhenUnitIsYard_ShouldReturnExpectedText()
        {
            var quantity = Create(7.5, LengthUnit.YARD);

            Assert.AreEqual("7.5 yd", quantity.ToString());
        }

        [TestMethod]
        public void ToString_WhenUnitIsCentimeter_ShouldReturnExpectedText()
        {
            var quantity = Create(7.5, LengthUnit.CENTIMETER);

            Assert.AreEqual("7.5 cm", quantity.ToString());
        }
    }
}