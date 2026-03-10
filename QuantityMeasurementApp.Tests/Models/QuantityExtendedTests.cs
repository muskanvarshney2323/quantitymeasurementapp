using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Comprehensive tests for the Quantity class.
    /// Validates equality behavior across multiple units,
    /// conversion accuracy, transitive consistency,
    /// hash code reliability, and string formatting output.
    /// </summary>
    [TestClass]
    public class QuantityExtendedTests
    {
        // Precision threshold for floating-point checks
        private const double Precision = 0.000001;

        #region Yard Related Tests

        // Same yard values should be equal
        [TestMethod]
        public void Equals_YardSameValue_ReturnsTrue()
        {
            var first = new Quantity(1.0, LengthUnit.YARD);
            var second = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(first.Equals(second));
        }

        // Different yard values should not be equal
        [TestMethod]
        public void Equals_YardDifferentValue_ReturnsFalse()
        {
            var first = new Quantity(1.0, LengthUnit.YARD);
            var second = new Quantity(2.0, LengthUnit.YARD);

            Assert.IsFalse(first.Equals(second));
        }

        // 1 yard should match 3 feet
        [TestMethod]
        public void Equals_YardAndFeetEquivalent_ReturnsTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.IsTrue(yard.Equals(feet));
        }

        // 1 yard should match 36 inches
        [TestMethod]
        public void Equals_YardAndInchesEquivalent_ReturnsTrue()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var inches = new Quantity(36.0, LengthUnit.INCH);

            Assert.IsTrue(yard.Equals(inches));
        }

        // Non-equivalent yard and feet values
        [TestMethod]
        public void Equals_YardAndFeetNonEquivalent_ReturnsFalse()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(2.0, LengthUnit.FEET);

            Assert.IsFalse(yard.Equals(feet));
        }

        #endregion

        #region Centimeter Related Tests

        // Same centimeter values should be equal
        [TestMethod]
        public void Equals_CentimeterSameValue_ReturnsTrue()
        {
            var first = new Quantity(1.0, LengthUnit.CENTIMETER);
            var second = new Quantity(1.0, LengthUnit.CENTIMETER);

            Assert.IsTrue(first.Equals(second));
        }

        // 30.48 cm equals 1 foot
        [TestMethod]
        public void Equals_CentimeterAndFeetEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var ft = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(cm.Equals(ft));
        }

        // 91.44 cm equals 1 yard
        [TestMethod]
        public void Equals_CentimeterAndYardEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(91.44, LengthUnit.CENTIMETER);
            var yard = new Quantity(1.0, LengthUnit.YARD);

            Assert.IsTrue(cm.Equals(yard));
        }

        // 1 cm should not equal 1 inch
        [TestMethod]
        public void Equals_CentimeterAndInchNonEquivalent_ReturnsFalse()
        {
            var cm = new Quantity(1.0, LengthUnit.CENTIMETER);
            var inch = new Quantity(1.0, LengthUnit.INCH);

            Assert.IsFalse(cm.Equals(inch));
        }

        #endregion

        #region Transitive Equality Tests

        // Transitive property across yard, feet, and inches
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

        // Transitive property across cm, inches, and feet
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

        #endregion

        #region Edge Case Validation

        // Object should equal itself
        [TestMethod]
        public void Equals_SameReference_ReturnsTrue()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsTrue(value.Equals(value));
        }

        // Comparison with null should return false
        [TestMethod]
        public void Equals_NullComparison_ReturnsFalse()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(value.Equals(null));
        }

        // Comparison with unrelated object type should return false
        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var value = new Quantity(5.0, LengthUnit.YARD);
            Assert.IsFalse(value.Equals(new object()));
        }

        #endregion

        #region Hash Code Consistency

        // Equal objects must produce identical hash codes
        [TestMethod]
        public void GetHashCode_EquivalentValues_ReturnSameHash()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            Assert.AreEqual(yard.GetHashCode(), feet.GetHashCode());
        }

        #endregion

        #region ToString Formatting

        // Verify formatted output for yard
        [TestMethod]
        public void ToString_Yard_ReturnsFormattedText()
        {
            var value = new Quantity(7.5, LengthUnit.YARD);
            Assert.AreEqual("7.5 yd", value.ToString());
        }

        // Verify formatted output for centimeter
        [TestMethod]
        public void ToString_Centimeter_ReturnsFormattedText()
        {
            var value = new Quantity(7.5, LengthUnit.CENTIMETER);
            Assert.AreEqual("7.5 cm", value.ToString());
        }

        #endregion
    }
}