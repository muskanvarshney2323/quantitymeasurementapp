using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests for Quantity class.
    /// Validates equality, hash code consistency, unit conversions (feet ↔ inches),
    /// object comparison rules (reflexive, symmetric, transitive, consistent),
    /// type and null safety, floating-point precision, and string formatting.
    /// </summary>
    [TestClass]
    public class QuantityTests
    {
        // Check equality for identical units and values
        [TestMethod]
        public void Equals_SameUnitAndValue_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2), "1.0 ft must equal 1.0 ft");
        }

        // Check inequality for identical units but different values
        [TestMethod]
        public void Equals_SameUnitDifferentValue_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2), "1.0 ft should not equal 2.0 ft");
        }

        // Check equality for inch values that are the same
        [TestMethod]
        public void Equals_SameInchValue_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.INCH);
            var q2 = new Quantity(1.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2), "1.0 in must equal 1.0 in");
        }

        // Check inequality for inch values that differ
        [TestMethod]
        public void Equals_DifferentInchValue_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.INCH);
            var q2 = new Quantity(2.0, LengthUnit.INCH);
            Assert.IsFalse(q1.Equals(q2), "1.0 in should not equal 2.0 in");
        }

        // Check cross-unit equality (1 ft = 12 in)
        [TestMethod]
        public void Equals_FeetAndInchEquivalent_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2), "1.0 ft should equal 12.0 in");
        }

        // Symmetry: inch ↔ feet equivalence
        [TestMethod]
        public void Equals_InchAndFeetSymmetry_ShouldBeTrue()
        {
            var q1 = new Quantity(12.0, LengthUnit.INCH);
            var q2 = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2), "12.0 in should equal 1.0 ft");
        }

        // Non-equivalent cross-unit comparison
        [TestMethod]
        public void Equals_FeetAndInchNotEquivalent_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(13.0, LengthUnit.INCH);
            Assert.IsFalse(q1.Equals(q2), "1.0 ft should not equal 13.0 in");
        }

        // Reflexive check: object equals itself
        [TestMethod]
        public void Equals_ReflexiveProperty_ShouldBeTrue()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q.Equals(q), "Object must equal itself");
        }

        // Null comparison: object should not equal null
        [TestMethod]
        public void Equals_NullCheck_ShouldBeFalse()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsFalse(q.Equals(null), "Object must not equal null");
        }

        // Symmetric property test
        [TestMethod]
        public void Equals_SymmetricRule_ShouldBeTrue()
        {
            var q1 = new Quantity(1.5, LengthUnit.FEET);
            var q2 = new Quantity(1.5, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2) && q2.Equals(q1), "Equality should be symmetric");
        }

        // Transitive property test
        [TestMethod]
        public void Equals_TransitiveRule_ShouldBeTrue()
        {
            var qA = new Quantity(2.5, LengthUnit.FEET);
            var qB = new Quantity(2.5, LengthUnit.FEET);
            var qC = new Quantity(2.5, LengthUnit.FEET);
            Assert.IsTrue(qA.Equals(qB) && qB.Equals(qC) && qA.Equals(qC), "Equality should be transitive");
        }

        // Objects of different types should not be equal
        [TestMethod]
        public void Equals_DifferentTypeObject_ShouldBeFalse()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            var obj = new object();
            Assert.IsFalse(q.Equals(obj), "Quantity must not equal a different type");
        }

        // Consistent equality across multiple calls
        [TestMethod]
        public void Equals_ConsistencyCheck_ShouldBeTrue()
        {
            var q1 = new Quantity(3.0, LengthUnit.FEET);
            var q2 = new Quantity(3.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2) && q1.Equals(q2) && q1.Equals(q2), "Equality results should be consistent");
        }

        // Test floating point precision handling
        [TestMethod]
        public void Equals_FloatingPointPrecision_ShouldBeFalseForTinyDifference()
        {
            var q1 = new Quantity(1.000001, LengthUnit.FEET);
            var q2 = new Quantity(1.000002, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2), "Very close values should not be equal");
        }

        // Hash codes for equal objects should match
        [TestMethod]
        public void GetHashCode_EqualObjects_ShouldMatch()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(5.0, LengthUnit.FEET);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        // Hash codes for different objects should differ
        [TestMethod]
        public void GetHashCode_DifferentObjects_ShouldDiffer()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(6.0, LengthUnit.FEET);
            Assert.AreNotEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        // Hash codes for cross-unit equivalent objects should match
        [TestMethod]
        public void GetHashCode_CrossUnitEquivalent_ShouldMatch()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode(), "Equivalent quantities should have the same hash");
        }

        // ToString() formatting for feet
        [TestMethod]
        public void ToString_FeetFormatting_ShouldBeCorrect()
        {
            var q = new Quantity(7.5, LengthUnit.FEET);
            Assert.AreEqual("7.5 ft", q.ToString());
        }

        // ToString() formatting for inches
        [TestMethod]
        public void ToString_InchFormatting_ShouldBeCorrect()
        {
            var q = new Quantity(7.5, LengthUnit.INCH);
            Assert.AreEqual("7.5 in", q.ToString());
        }
    }
}
