using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Extended tests for Quantity class.
    /// Verifies equality, conversion, transitive consistency, hash code correctness,
    /// and proper string formatting for various units.
    /// </summary>
    [TestClass]
    public class QuantityAdvancedTests
    {
        private const double Tolerance = 0.000001;

        #region Yard Tests

        [TestMethod]
        public void EqualYardValues_ShouldBeEqual()
        {
            var firstYard = new Quantity(1.0, LengthUnit.YARD);
            var secondYard = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(firstYard.Equals(secondYard));
        }

        [TestMethod]
        public void DifferentYardValues_ShouldNotBeEqual()
        {
            var firstYard = new Quantity(1.0, LengthUnit.YARD);
            var secondYard = new Quantity(2.0, LengthUnit.YARD);

            Assert.IsFalse(firstYard.Equals(secondYard));
        }

        [TestMethod]
        public void YardEqualsThreeFeet_ShouldBeTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.IsTrue(yard.Equals(feet));
        }

        [TestMethod]
        public void YardEqualsThirtySixInches_ShouldBeTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var inches = new Quantity(36.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void YardNotEqualToTwoFeet_ShouldBeFalse()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(2.0, LengthUnit.FEET);

            Assert.IsFalse(yard.Equals(feet));
        }

        #endregion

        #region Centimeter Tests

        [TestMethod]
        public void EqualCentimeterValues_ShouldBeEqual()
        {
            var first = new Quantity(1.0, LengthUnit.CENTIMETER);
            var second = new Quantity(1.0, LengthUnit.CENTIMETER);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void ThirtyPointFourEightCm_EqualsOneFoot_ShouldBeTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var ft = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(cm.Equals(ft));
        }

        [TestMethod]
        public void NinetyOnePointFourFourCm_EqualsOneYard_ShouldBeTrue()
        {
            var cm = new Quantity(91.44, LengthUnit.CENTIMETER);
            var yard = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(cm.Equals(yard));
        }

        [TestMethod]
        public void OneCmNotEqualToOneInch_ShouldBeFalse()
        {
            var cm = new Quantity(1.0, LengthUnit.CENTIMETER);
            var inch = new Quantity(1.0, LengthUnit.INCH);

            Assert.IsFalse(cm.Equals(inch));
        }

        #endregion

        #region Transitive Property Tests

        [TestMethod]
        public void TransitiveYardFeetInches_ShouldBeTrue()
        {
            var yard = new Quantity(2.0, LengthUnit.YARD);
            var feet = new Quantity(6.0, LengthUnit.FEET);
            var inches = new Quantity(72.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void TransitiveCmInchesFeet_ShouldBeTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var inches = new Quantity(12.0, LengthUnit.INCH);
            var feet = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(cm.Equals(inches));
            Assert.IsTrue(inches.Equals(feet));
            Assert.IsTrue(cm.Equals(feet));
        }

        #endregion

        #region Edge Cases

        [TestMethod]
        public void ObjectEqualsItself_ShouldBeTrue()
        {
            var val = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsTrue(val.Equals(val));
        }

        [TestMethod]
        public void ObjectComparedWithNull_ShouldBeFalse()
        {
            var val = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(val.Equals(null));
        }

        [TestMethod]
        public void ObjectComparedWithOtherType_ShouldBeFalse()
        {
            var val = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(val.Equals(new object()));
        }

        #endregion

        #region HashCode Tests

        [TestMethod]
        public void EqualValues_HashCodesShouldMatch()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.AreEqual(yard.GetHashCode(), feet.GetHashCode());
        }

        #endregion

        #region ToString Tests

        [TestMethod]
        public void ToStringYard_ShouldReturnFormattedString()
        {
            var val = new Quantity(7.5, LengthUnit.YARD);
            Assert.AreEqual("7.5 yd", val.ToString());
        }

        [TestMethod]
        public void ToStringCentimeter_ShouldReturnFormattedString()
        {
            var val = new Quantity(7.5, LengthUnit.CENTIMETER);
            Assert.AreEqual("7.5 cm", val.ToString());
        }

        #endregion
    }
}