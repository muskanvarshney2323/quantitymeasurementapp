using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    // Test suite for Inch model
    // Ensures correct implementation of equality, hash code, and string output
    [TestClass]
    public class InchTests
    {
        // Case: Two Inch objects with identical values
        // Expected: Equals should return true
        [TestMethod]
        public void Equals_SameValue_ReturnsTrue()
        {
            var inch1 = new Inch(1.0);
            var inch2 = new Inch(1.0);

            bool result = inch1.Equals(inch2);

            Assert.IsTrue(result, "1.0 in should equal 1.0 in");
        }

        // Case: Inch objects having different values
        // Expected: Equals should return false
        [TestMethod]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            var inch1 = new Inch(1.0);
            var inch2 = new Inch(2.0);

            bool result = inch1.Equals(inch2);

            Assert.IsFalse(result, "1.0 in should not equal 2.0 in");
        }

        // Case: Object compared with itself
        // Expected: Equals should always return true
        [TestMethod]
        public void Equals_SameReference_ReturnsTrue()
        {
            var inch = new Inch(1.0);

            bool result = inch.Equals(inch);

            Assert.IsTrue(result, "An object must be equal to itself");
        }

        // Case: Comparison against null
        // Expected: Equals should return false
        [TestMethod]
        public void Equals_NullComparison_ReturnsFalse()
        {
            var inch = new Inch(1.0);

            bool result = inch.Equals(null);

            Assert.IsFalse(result, "Object should not be equal to null");
        }

        // Case: Symmetric equality rule
        // If a equals b, then b must equal a
        [TestMethod]
        public void Equals_SymmetricProperty_ReturnsTrue()
        {
            var inch1 = new Inch(1.5);
            var inch2 = new Inch(1.5);

            bool result1 = inch1.Equals(inch2);
            bool result2 = inch2.Equals(inch1);

            Assert.IsTrue(result1 && result2, "Equality should be symmetric");
        }

        // Case: Transitive equality rule
        // If a equals b and b equals c, then a must equal c
        [TestMethod]
        public void Equals_TransitiveProperty_ReturnsTrue()
        {
            var inchA = new Inch(2.5);
            var inchB = new Inch(2.5);
            var inchC = new Inch(2.5);

            bool aEqualsB = inchA.Equals(inchB);
            bool bEqualsC = inchB.Equals(inchC);
            bool aEqualsC = inchA.Equals(inchC);

            Assert.IsTrue(aEqualsB && bEqualsC && aEqualsC, "Equality should be transitive");
        }

        // Case: Comparison with a different object type
        // Expected: Equals should return false
        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            var inch = new Inch(1.0);
            var obj = new object();

            bool result = inch.Equals(obj);

            Assert.IsFalse(result, "Inch should not equal an object of another type");
        }

        // Case: Repeated equality checks
        // Expected: Same result every time
        [TestMethod]
        public void Equals_ConsistentProperty_ReturnsTrue()
        {
            var inch1 = new Inch(3.0);
            var inch2 = new Inch(3.0);

            bool result1 = inch1.Equals(inch2);
            bool result2 = inch1.Equals(inch2);
            bool result3 = inch1.Equals(inch2);

            Assert.IsTrue(
                result1 && result2 && result3,
                "Equality result should be consistent across calls"
            );
        }

        // Case: Very close floating-point values
        // Expected: Values should still be treated as different
        [TestMethod]
        public void Equals_FloatingPointPrecision_HandlesCorrectly()
        {
            var inch1 = new Inch(1.000001);
            var inch2 = new Inch(1.000002);

            bool result = inch1.Equals(inch2);

            Assert.IsFalse(result, "Slightly different values should not be equal");
        }

        // Case: Hash codes for equal objects
        // Expected: Hash codes should match
        [TestMethod]
        public void GetHashCode_EqualObjects_ReturnsSameHashCode()
        {
            var inch1 = new Inch(5.0);
            var inch2 = new Inch(5.0);

            int hash1 = inch1.GetHashCode();
            int hash2 = inch2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Equal objects must have identical hash codes");
        }

        // Case: Hash codes for unequal objects
        // Expected: Hash codes should be different
        [TestMethod]
        public void GetHashCode_DifferentObjects_ReturnsDifferentHashCode()
        {
            var inch1 = new Inch(5.0);
            var inch2 = new Inch(6.0);

            int hash1 = inch1.GetHashCode();
            int hash2 = inch2.GetHashCode();

            Assert.AreNotEqual(hash1, hash2, "Different objects should produce different hash codes");
        }

        // Case: String representation of Inch
        // Expected format: "<value> in"
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            var inch = new Inch(7.5);

            string result = inch.ToString();

            Assert.AreEqual("7.5 in", result, "ToString should include value and unit");
        }
    }
}