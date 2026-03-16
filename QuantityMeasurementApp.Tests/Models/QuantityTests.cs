using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityTests
    {
        private static Quantity Create(double value, LengthUnit unit)
        {
            return new Quantity(value, unit);
        }

        private static void AssertEqualQuantity(
            double leftValue,
            LengthUnit leftUnit,
            double rightValue,
            LengthUnit rightUnit,
            string message = "")
        {
            var left = Create(leftValue, leftUnit);
            var right = Create(rightValue, rightUnit);

            Assert.IsTrue(left.Equals(right), message);
        }

        private static void AssertNotEqualQuantity(
            double leftValue,
            LengthUnit leftUnit,
            double rightValue,
            LengthUnit rightUnit,
            string message = "")
        {
            var left = Create(leftValue, leftUnit);
            var right = Create(rightValue, rightUnit);

            Assert.IsFalse(left.Equals(right), message);
        }

        [TestMethod]
        public void Equals_WhenFeetValuesAreSame_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.FEET, 1.0, LengthUnit.FEET, "1.0 ft must equal 1.0 ft");
        }

        [TestMethod]
        public void Equals_WhenFeetValuesAreDifferent_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.FEET, 2.0, LengthUnit.FEET, "1.0 ft should not equal 2.0 ft");
        }

        [TestMethod]
        public void Equals_WhenInchValuesAreSame_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.INCH, 1.0, LengthUnit.INCH, "1.0 in must equal 1.0 in");
        }

        [TestMethod]
        public void Equals_WhenInchValuesAreDifferent_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.INCH, 2.0, LengthUnit.INCH, "1.0 in should not equal 2.0 in");
        }

        [TestMethod]
        public void Equals_WhenFeetAndInchesAreEquivalent_ShouldReturnTrue()
        {
            AssertEqualQuantity(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH, "1.0 ft should equal 12.0 in");
        }

        [TestMethod]
        public void Equals_WhenInchesAndFeetAreEquivalent_ShouldReturnTrue()
        {
            AssertEqualQuantity(12.0, LengthUnit.INCH, 1.0, LengthUnit.FEET, "12.0 in should equal 1.0 ft");
        }

        [TestMethod]
        public void Equals_WhenFeetAndInchesAreNotEquivalent_ShouldReturnFalse()
        {
            AssertNotEqualQuantity(1.0, LengthUnit.FEET, 13.0, LengthUnit.INCH, "1.0 ft should not equal 13.0 in");
        }

        [TestMethod]
        public void Equals_WhenComparedWithItself_ShouldReturnTrue()
        {
            var quantity = Create(1.0, LengthUnit.FEET);

            Assert.IsTrue(quantity.Equals(quantity), "Object must equal itself");
        }

        [TestMethod]
        public void Equals_WhenComparedWithNull_ShouldReturnFalse()
        {
            var quantity = Create(1.0, LengthUnit.FEET);

            Assert.IsFalse(quantity.Equals(null), "Object must not equal null");
        }

        [TestMethod]
        public void Equals_WhenRelationIsSymmetric_ShouldReturnTrue()
        {
            var first = Create(1.5, LengthUnit.FEET);
            var second = Create(1.5, LengthUnit.FEET);

            Assert.IsTrue(first.Equals(second) && second.Equals(first), "Equality should be symmetric");
        }

        [TestMethod]
        public void Equals_WhenRelationIsTransitive_ShouldReturnTrue()
        {
            var first = Create(2.5, LengthUnit.FEET);
            var second = Create(2.5, LengthUnit.FEET);
            var third = Create(2.5, LengthUnit.FEET);

            Assert.IsTrue(
                first.Equals(second) && second.Equals(third) && first.Equals(third),
                "Equality should be transitive");
        }

        [TestMethod]
        public void Equals_WhenComparedWithDifferentType_ShouldReturnFalse()
        {
            var quantity = Create(1.0, LengthUnit.FEET);

            Assert.IsFalse(quantity.Equals(new object()), "Quantity must not equal a different type");
        }

        [TestMethod]
        public void Equals_WhenCalledRepeatedly_ShouldRemainConsistent()
        {
            var first = Create(3.0, LengthUnit.FEET);
            var second = Create(3.0, LengthUnit.FEET);

            Assert.IsTrue(
                first.Equals(second) && first.Equals(second) && first.Equals(second),
                "Equality results should be consistent");
        }

        [TestMethod]
        public void Equals_WhenValuesDifferSlightly_ShouldReturnFalse()
        {
            var first = Create(1.000001, LengthUnit.FEET);
            var second = Create(1.000002, LengthUnit.FEET);

            Assert.IsFalse(first.Equals(second), "Very close values should not be equal");
        }

        [TestMethod]
        public void GetHashCode_WhenObjectsAreEqual_ShouldMatch()
        {
            var first = Create(5.0, LengthUnit.FEET);
            var second = Create(5.0, LengthUnit.FEET);

            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_WhenObjectsAreDifferent_ShouldNotMatch()
        {
            var first = Create(5.0, LengthUnit.FEET);
            var second = Create(6.0, LengthUnit.FEET);

            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_WhenQuantitiesAreEquivalentAcrossUnits_ShouldMatch()
        {
            var feet = Create(1.0, LengthUnit.FEET);
            var inches = Create(12.0, LengthUnit.INCH);

            Assert.AreEqual(
                feet.GetHashCode(),
                inches.GetHashCode(),
                "Equivalent quantities should have the same hash");
        }

        [TestMethod]
        public void ToString_WhenUnitIsFeet_ShouldReturnFormattedValue()
        {
            var quantity = Create(7.5, LengthUnit.FEET);

            Assert.AreEqual("7.5 ft", quantity.ToString());
        }

        [TestMethod]
        public void ToString_WhenUnitIsInch_ShouldReturnFormattedValue()
        {
            var quantity = Create(7.5, LengthUnit.INCH);

            Assert.AreEqual("7.5 in", quantity.ToString());
        }
    }
}