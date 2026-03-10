using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    // Unit test suite for the Feet model
    // Validates equality rules, hash code behavior, and string output
    [TestClass]
    public class FeetTests
    {
        // Scenario: Two measurements with identical values should match
        // Confirms equality when both Feet objects store the same number
        [TestMethod]
        public void Equals_SameValue_ReturnsTrue()
        {
            // Setup: Initialize two Feet instances with equal values
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(1.0);

            // Execution: Perform equality check
            bool result = feet1.Equals(feet2);

            // Verification: Expect true
            Assert.IsTrue(result, "1.0 ft should equal 1.0 ft");
        }

        // Scenario: Measurements having different values must not match
        // Ensures unequal values return false
        [TestMethod]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            // Setup: Create Feet objects with different measurements
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(2.0);

            // Execution
            bool result = feet1.Equals(feet2);

            // Verification
            Assert.IsFalse(result, "1.0 ft should not equal 2.0 ft");
        }

        // Scenario: Object compared with itself
        // Confirms reflexive rule of equality
        [TestMethod]
        public void Equals_SameReference_ReturnsTrue()
        {
            // Setup
            var feet = new Feet(1.0);

            // Execution
            bool result = feet.Equals(feet);

            // Verification
            Assert.IsTrue(result, "An object must be equal to itself");
        }

        // Scenario: Comparison against null
        // Ensures Feet never equals null
        [TestMethod]
        public void Equals_NullComparison_ReturnsFalse()
        {
            // Setup
            var feet = new Feet(1.0);

            // Execution
            bool result = feet.Equals(null);

            // Verification
            Assert.IsFalse(result, "Comparison with null should return false");
        }

        // Scenario: Symmetric equality check
        // If a == b, then b must also == a
        [TestMethod]
        public void Equals_SymmetricProperty_ReturnsTrue()
        {
            // Setup
            var feet1 = new Feet(1.5);
            var feet2 = new Feet(1.5);

            // Execution
            bool result1 = feet1.Equals(feet2);
            bool result2 = feet2.Equals(feet1);

            // Verification
            Assert.IsTrue(result1 && result2, "Equality should work both ways");
        }

        // Scenario: Transitive equality rule
        // If a == b and b == c, then a == c
        [TestMethod]
        public void Equals_TransitiveProperty_ReturnsTrue()
        {
            // Setup
            var feetA = new Feet(2.5);
            var feetB = new Feet(2.5);
            var feetC = new Feet(2.5);

            // Execution
            bool aEqualsB = feetA.Equals(feetB);
            bool bEqualsC = feetB.Equals(feetC);
            bool aEqualsC = feetA.Equals(feetC);

            // Verification
            Assert.IsTrue(aEqualsB && bEqualsC && aEqualsC, "Equality should be transitive");
        }

        // Scenario: Comparison with an unrelated type
        // Ensures Feet only equals another Feet object
        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            // Setup
            var feet = new Feet(1.0);
            var obj = new object();

            // Execution
            bool result = feet.Equals(obj);

            // Verification
            Assert.IsFalse(result, "Feet must not equal a different object type");
        }

        // Scenario: Repeated equality checks
        // Ensures consistent results across multiple calls
        [TestMethod]
        public void Equals_ConsistentProperty_ReturnsTrue()
        {
            // Setup
            var feet1 = new Feet(3.0);
            var feet2 = new Feet(3.0);

            // Execution
            bool result1 = feet1.Equals(feet2);
            bool result2 = feet1.Equals(feet2);
            bool result3 = feet1.Equals(feet2);

            // Verification
            Assert.IsTrue(
                result1 && result2 && result3,
                "Equality results should remain consistent"
            );
        }

        // Scenario: Floating-point comparison
        // Confirms that very close but unequal values are treated as different
        [TestMethod]
        public void Equals_FloatingPointPrecision_HandlesCorrectly()
        {
            // Setup
            var feet1 = new Feet(1.000001);
            var feet2 = new Feet(1.000002);

            // Execution
            bool result = feet1.Equals(feet2);

            // Verification
            Assert.IsFalse(result, "Slight value differences should not be equal");
        }

        // Scenario: Hash code consistency for equal objects
        // Ensures same values generate same hash codes
        [TestMethod]
        public void GetHashCode_EqualObjects_ReturnsSameHashCode()
        {
            // Setup
            var feet1 = new Feet(5.0);
            var feet2 = new Feet(5.0);

            // Execution
            int hash1 = feet1.GetHashCode();
            int hash2 = feet2.GetHashCode();

            // Verification
            Assert.AreEqual(hash1, hash2, "Equal objects must share hash codes");
        }

        // Scenario: Hash code difference for unequal objects
        // Validates that different values usually generate different hash codes
        [TestMethod]
        public void GetHashCode_DifferentObjects_ReturnsDifferentHashCode()
        {
            // Setup
            var feet1 = new Feet(5.0);
            var feet2 = new Feet(6.0);

            // Execution
            int hash1 = feet1.GetHashCode();
            int hash2 = feet2.GetHashCode();

            // Verification
            Assert.AreNotEqual(hash1, hash2, "Different objects should not share hash codes");
        }

        // Scenario: String representation format
        // Confirms output includes value and unit
        [TestMethod]
        public void ToString_ReturnsFormattedString()
        {
            // Setup
            var feet = new Feet(7.5);

            // Execution
            string result = feet.ToString();

            // Verification
            Assert.AreEqual("7.5 ft", result, "Output should be value followed by unit");
        }
    }
}