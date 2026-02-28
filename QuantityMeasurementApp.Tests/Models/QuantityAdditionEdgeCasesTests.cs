using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Test suite focused on unusual scenarios and boundary conditions
    /// while performing quantity addition.
    /// Covers limits, precision concerns, and exceptional cases.
    /// </summary>
    [TestClass]
    public class QuantityAdditionEdgeCasesTests
    {
        private const double Tolerance = 0.000001;

        #region Extreme Value Tests

        /// <summary>
        /// Validates addition behavior when values are close to the maximum
        /// representable double value.
        /// Ensures the result remains a valid finite number.
        /// </summary>
        [TestMethod]
        public void Add_NearMaxValue_HandlesCorrectly()
        {
            double nearMax = double.MaxValue / 2.0;

            var q1 = new Quantity(nearMax, LengthUnit.FEET);
            var q2 = new Quantity(nearMax, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.IsFalse(double.IsInfinity(result.Value), "Result should not overflow");
            Assert.IsFalse(double.IsNaN(result.Value), "Result should be a valid number");
        }

        /// <summary>
        /// Checks accuracy when adding very large values where
        /// floating-point precision could degrade.
        /// </summary>
        [TestMethod]
        public void Add_LargeValues_PrecisionLossWithinTolerance()
        {
            double largeValue = 1e12;

            var q1 = new Quantity(largeValue, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            // Expected outcome after converting inches to feet
            double expected = largeValue + (1.0 / 12.0);

            // Validate that relative error stays within acceptable bounds
            double relativeError = Math.Abs((result.Value - expected) / expected);
            Assert.IsTrue(relativeError < 1e-12, $"Relative error {relativeError} exceeds limit");
        }

        #endregion

        #region Precision Tests

        /// <summary>
        /// Ensures correct handling of values that lead to repeating decimals
        /// during unit conversion.
        /// </summary>
        [TestMethod]
        public void Add_RepeatingDecimals_MaintainsAccuracy()
        {
            // One-third foot equals four inches
            var q1 = new Quantity(1.0 / 3.0, LengthUnit.FEET);
            var q2 = new Quantity(4.0, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.INCH);

            // Total should be eight inches
            Assert.AreEqual(8.0, result.Value, Tolerance);
        }

        /// <summary>
        /// Confirms that conversions involving irrational numbers
        /// retain sufficient numerical accuracy.
        /// </summary>
        [TestMethod]
        public void Add_IrrationalConversions_MaintainsPrecision()
        {
            // Conversion between centimeters and inches involves irrational values
            var q1 = new Quantity(1.0, LengthUnit.CENTIMETER);
            var q2 = new Quantity(1.0, LengthUnit.CENTIMETER);

            var result = q1.Add(q2, LengthUnit.INCH);

            // Expected inch value after converting 2 cm
            double expected = 2.0 * 0.393700787;

            Assert.AreEqual(expected, result.Value, Tolerance);
        }

        #endregion

        #region Identity and Zero Tests

        /// <summary>
        /// Verifies that adding zero does not alter the original quantity,
        /// regardless of the measurement unit.
        /// </summary>
        [TestMethod]
        public void Add_IdentityProperty_HoldsForAllUnits()
        {
            LengthUnit[] units =
            {
                LengthUnit.FEET,
                LengthUnit.INCH,
                LengthUnit.YARD,
                LengthUnit.CENTIMETER,
            };

            var zero = new Quantity(0.0, LengthUnit.FEET);

            foreach (var unit in units)
            {
                var q = new Quantity(5.0, unit);
                var result = q.Add(zero, unit);

                Assert.AreEqual(5.0, result.Value, Tolerance);
                Assert.AreEqual(unit, result.Unit);
            }
        }

        /// <summary>
        /// Confirms that zero values expressed in different units
        /// still behave as a neutral element in addition.
        /// </summary>
        [TestMethod]
        public void Add_ZeroInDifferentUnits_ReturnsOriginalValue()
        {
            var q = new Quantity(5.0, LengthUnit.FEET);

            var zeroInInches = new Quantity(0.0, LengthUnit.INCH);
            var zeroInYards = new Quantity(0.0, LengthUnit.YARD);
            var zeroInCm = new Quantity(0.0, LengthUnit.CENTIMETER);

            var result1 = q.Add(zeroInInches);
            var result2 = q.Add(zeroInYards);
            var result3 = q.Add(zeroInCm);

            Assert.AreEqual(5.0, result1.Value, Tolerance);
            Assert.AreEqual(5.0, result2.Value, Tolerance);
            Assert.AreEqual(5.0, result3.Value, Tolerance);
        }

        #endregion

        #region Sign Tests

        /// <summary>
        /// Ensures that equal positive and negative quantities
        /// negate each other correctly.
        /// </summary>
        [TestMethod]
        public void Add_PositiveAndNegative_CancelOut()
        {
            var feet = new Quantity(2.0, LengthUnit.FEET);
            var inches = new Quantity(-24.0, LengthUnit.INCH);

            var result = feet.Add(inches);

            Assert.AreEqual(0.0, result.Value, Tolerance);
        }

        /// <summary>
        /// Validates scenarios where the final sum results in a negative value.
        /// </summary>
        [TestMethod]
        public void Add_ResultIsNegative_ReturnsCorrectValue()
        {
            var feet = new Quantity(1.0, LengthUnit.FEET);
            var inches = new Quantity(-24.0, LengthUnit.INCH);

            var result = feet.Add(inches);

            Assert.AreEqual(-1.0, result.Value, Tolerance);
        }

        #endregion

        #region Associativity Tests

        /// <summary>
        /// Confirms that addition follows the associative rule
        /// when comparisons are made using a common base unit.
        /// </summary>
        [TestMethod]
        public void Add_IsAssociative_WhenComparedInBaseUnit()
        {
            var a = new Quantity(1.0, LengthUnit.FEET);
            var b = new Quantity(12.0, LengthUnit.INCH);
            var c = new Quantity(0.5, LengthUnit.YARD);

            var left = a.Add(b).Add(c);
            var right = a.Add(b.Add(c));

            var leftInFeet = left.ConvertTo(LengthUnit.FEET);
            var rightInFeet = right.ConvertTo(LengthUnit.FEET);

            Assert.IsTrue(leftInFeet.Equals(rightInFeet));
        }

        #endregion

        #region Overflow/Underflow Tests

        /// <summary>
        /// Tests behavior when adding extremely small values
        /// that may be close to underflow limits.
        /// </summary>
        [TestMethod]
        public void Add_VerySmallNumbers_HandlesUnderflow()
        {
            double verySmall = double.Epsilon * 100;

            var q1 = new Quantity(verySmall, LengthUnit.FEET);
            var q2 = new Quantity(verySmall, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.IsFalse(double.IsInfinity(result.Value));
            Assert.IsFalse(double.IsNaN(result.Value));
        }

        #endregion

        #region Rounding Tests

        /// <summary>
        /// Ensures consistent rounding behavior when multiple
        /// fractional values are added sequentially.
        /// </summary>
        [TestMethod]
        public void Add_RoundingBehavior_Consistent()
        {
            var q1 = new Quantity(1.0 / 3.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0 / 3.0, LengthUnit.FEET);
            var q3 = new Quantity(1.0 / 3.0, LengthUnit.FEET);

            var result = q1.Add(q2).Add(q3);

            Assert.AreEqual(1.0, result.Value, Tolerance);
        }

        #endregion
    }
}