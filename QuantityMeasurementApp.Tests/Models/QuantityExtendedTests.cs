
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityExtendedTests
    {
        [TestMethod]
        public void Equals_YardSameValue_ReturnsTrue()
        {
            var first = new Quantity(1.0, LengthUnit.YARD);
            var second = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_YardDifferentValue_ReturnsFalse()
        {
            var first = new Quantity(1.0, LengthUnit.YARD);
            var second = new Quantity(2.0, LengthUnit.YARD);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void Equals_YardAndFeetEquivalent_ReturnsTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.IsTrue(yard.Equals(feet));
        }

        [TestMethod]
        public void Equals_YardAndInchesEquivalent_ReturnsTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var inches = new Quantity(36.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void Equals_YardAndFeetNonEquivalent_ReturnsFalse()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(2.0, LengthUnit.FEET);

            Assert.IsFalse(yard.Equals(feet));
        }

        [TestMethod]
        public void Equals_CentimeterSameValue_ReturnsTrue()
        {
            var first = new Quantity(1.0, LengthUnit.CENTIMETER);
            var second = new Quantity(1.0, LengthUnit.CENTIMETER);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void Equals_CentimeterAndFeetEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var ft = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(cm.Equals(ft));
        }

        [TestMethod]
        public void Equals_CentimeterAndYardEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(91.44, LengthUnit.CENTIMETER);
            var yard = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(cm.Equals(yard));
        }

        [TestMethod]
        public void Equals_CentimeterAndInchNonEquivalent_ReturnsFalse()
        {
            var cm = new Quantity(1.0, LengthUnit.CENTIMETER);
            var inch = new Quantity(1.0, LengthUnit.INCH);

            Assert.IsFalse(cm.Equals(inch));
        }

        [TestMethod]
        public void Equals_Transitive_YardFeetInches_ReturnsTrue()
        {
            var yard = new Quantity(2.0, LengthUnit.YARD);
            var feet = new Quantity(6.0, LengthUnit.FEET);
            var inches = new Quantity(72.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(feet));
            Assert.IsTrue(feet.Equals(inches));
            Assert.IsTrue(yard.Equals(inches));
        }

        [TestMethod]
        public void Equals_Transitive_CmInchesFeet_ReturnsTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var inches = new Quantity(12.0, LengthUnit.INCH);
            var feet = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(cm.Equals(inches));
            Assert.IsTrue(inches.Equals(feet));
            Assert.IsTrue(cm.Equals(feet));
        }

        [TestMethod]
        public void Equals_SameReference_ReturnsTrue()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsTrue(value.Equals(value));
        }

        [TestMethod]
        public void Equals_NullComparison_ReturnsFalse()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(value.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(value.Equals(new object()));
        }

        [TestMethod]
        public void GetHashCode_EquivalentValues_ReturnSameHash()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.AreEqual(yard.GetHashCode(), feet.GetHashCode());
        }

        [TestMethod]
        public void ToString_Yard_ReturnsFormattedText()
        {
            var value = new Quantity(7.5, LengthUnit.YARD);
            Assert.AreEqual("7.5 yd", value.ToString());
        }

        [TestMethod]
        public void ToString_Centimeter_ReturnsFormattedText()
        {
            var value = new Quantity(7.5, LengthUnit.CENTIMETER);
            Assert.AreEqual("7.5 cm", value.ToString());
        }
    }
}
