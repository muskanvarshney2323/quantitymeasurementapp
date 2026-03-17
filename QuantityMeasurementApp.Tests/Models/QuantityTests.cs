using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests for Quantity class.
    /// Validates equality, hash code consistency, conversions,
    /// arithmetic operations, validation, and string formatting.
    /// </summary>
    [TestClass]
    public class QuantityTests
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void Equals_SameUnitAndValue_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2), "1.0 ft must equal 1.0 ft");
        }

        [TestMethod]
        public void Equals_SameUnitDifferentValue_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2), "1.0 ft should not equal 2.0 ft");
        }

        [TestMethod]
        public void Equals_SameInchValue_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.INCH);
            var q2 = new Quantity(1.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2), "1.0 in must equal 1.0 in");
        }

        [TestMethod]
        public void Equals_DifferentInchValue_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.INCH);
            var q2 = new Quantity(2.0, LengthUnit.INCH);
            Assert.IsFalse(q1.Equals(q2), "1.0 in should not equal 2.0 in");
        }

        [TestMethod]
        public void Equals_FeetAndInchEquivalent_ShouldBeTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2), "1.0 ft should equal 12.0 in");
        }

        [TestMethod]
        public void Equals_InchAndFeetSymmetry_ShouldBeTrue()
        {
            var q1 = new Quantity(12.0, LengthUnit.INCH);
            var q2 = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2), "12.0 in should equal 1.0 ft");
        }

        [TestMethod]
        public void Equals_FeetAndInchNotEquivalent_ShouldBeFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(13.0, LengthUnit.INCH);
            Assert.IsFalse(q1.Equals(q2), "1.0 ft should not equal 13.0 in");
        }

        [TestMethod]
        public void Equals_ReflexiveProperty_ShouldBeTrue()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q.Equals(q), "Object must equal itself");
        }

        [TestMethod]
        public void Equals_NullCheck_ShouldBeFalse()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsFalse(q.Equals(null), "Object must not equal null");
        }

        [TestMethod]
        public void Equals_SymmetricRule_ShouldBeTrue()
        {
            var q1 = new Quantity(1.5, LengthUnit.FEET);
            var q2 = new Quantity(1.5, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2) && q2.Equals(q1), "Equality should be symmetric");
        }

        [TestMethod]
        public void Equals_TransitiveRule_ShouldBeTrue()
        {
            var qA = new Quantity(2.5, LengthUnit.FEET);
            var qB = new Quantity(2.5, LengthUnit.FEET);
            var qC = new Quantity(2.5, LengthUnit.FEET);
            Assert.IsTrue(qA.Equals(qB) && qB.Equals(qC) && qA.Equals(qC), "Equality should be transitive");
        }

        [TestMethod]
        public void Equals_DifferentTypeObject_ShouldBeFalse()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            var obj = new object();
            Assert.IsFalse(q.Equals(obj), "Quantity must not equal a different type");
        }

        [TestMethod]
        public void Equals_ConsistencyCheck_ShouldBeTrue()
        {
            var q1 = new Quantity(3.0, LengthUnit.FEET);
            var q2 = new Quantity(3.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2) && q1.Equals(q2) && q1.Equals(q2), "Equality results should be consistent");
        }

        [TestMethod]
        public void Equals_FloatingPointPrecision_ShouldBeFalseForTinyDifference()
        {
            var q1 = new Quantity(1.000001, LengthUnit.FEET);
            var q2 = new Quantity(1.000002, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2), "Very close values should not be equal");
        }

        [TestMethod]
        public void GetHashCode_EqualObjects_ShouldMatch()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(5.0, LengthUnit.FEET);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_DifferentObjects_ShouldDiffer()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(6.0, LengthUnit.FEET);
            Assert.AreNotEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_CrossUnitEquivalent_ShouldMatch()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode(), "Equivalent quantities should have the same hash");
        }

        [TestMethod]
        public void ConvertTo_FeetToInch_ShouldReturnCorrectValue()
        {
            var quantity = new Quantity(1.0, LengthUnit.FEET);

            var result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_InchToFeet_ShouldReturnCorrectValue()
        {
            var quantity = new Quantity(12.0, LengthUnit.INCH);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_YardToFeet_ShouldReturnCorrectValue()
        {
            var quantity = new Quantity(1.0, LengthUnit.YARD);

            var result = quantity.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(3.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ConvertTo_CentimeterToInch_ShouldReturnCorrectValue()
        {
            var quantity = new Quantity(2.54, LengthUnit.CENTIMETER);

            var result = quantity.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(1.0, result.Value, 0.0001);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void StaticConvert_FeetToInch_ShouldReturnCorrectValue()
        {
            double result = Quantity.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);

            Assert.AreEqual(12.0, result, Tolerance);
        }

        [TestMethod]
        public void Add_SameUnit_ShouldReturnCorrectSum()
        {
            var q1 = new Quantity(2.0, LengthUnit.FEET);
            var q2 = new Quantity(3.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(5.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_DifferentUnits_ShouldReturnCorrectSumInFirstUnit()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_WithTargetUnit_ShouldReturnCorrectSum()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.YARD);

            Assert.AreEqual(2.0 / 3.0, result.Value, 0.0001);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        [TestMethod]
        public void Constructor_NaNValue_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Quantity(double.NaN, LengthUnit.FEET)
            );
        }

        [TestMethod]
        public void Constructor_InfiniteValue_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Quantity(double.PositiveInfinity, LengthUnit.FEET)
            );
        }

        [TestMethod]
        public void Convert_InvalidSourceValue_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                Quantity.Convert(double.NaN, LengthUnit.FEET, LengthUnit.INCH)
            );
        }

        [TestMethod]
        public void ToString_FeetFormatting_ShouldBeCorrect()
        {
            var q = new Quantity(7.5, LengthUnit.FEET);
            Assert.AreEqual("7.5 ft", q.ToString());
        }

        [TestMethod]
        public void ToString_InchFormatting_ShouldBeCorrect()
        {
            var q = new Quantity(7.5, LengthUnit.INCH);
            Assert.AreEqual("7.5 in", q.ToString());
        }
    }
}