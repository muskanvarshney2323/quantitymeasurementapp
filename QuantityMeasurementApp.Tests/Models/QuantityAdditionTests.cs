using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    /// <summary>
    /// Unit tests focused on validating quantity addition behavior.
    /// Covers addition logic across all supported measurement units.
    /// </summary>
    [TestClass]
    public class QuantityAdditionTests
    {
        private const double Tolerance = 0.000001;

        #region Same-Unit Addition Tests

        /// <summary>
        /// Validates addition when both quantities are measured in feet.
        /// Expected outcome: 1 foot added to 2 feet results in 3 feet.
        /// </summary>
        [TestMethod]
        public void Add_SameUnit_FeetPlusFeet_ReturnsCorrectSum()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        /// <summary>
        /// Confirms correct behavior when adding inch values together.
        /// Example: 6 inches combined with 6 inches equals 12 inches.
        /// </summary>
        [TestMethod]
        public void Add_SameUnit_InchPlusInch_ReturnsCorrectSum()
        {
            var q1 = new Quantity(6.0, LengthUnit.INCH);
            var q2 = new Quantity(6.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(12.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        /// <summary>
        /// Ensures correct addition when both inputs are in yards.
        /// For example, 2 yards plus 3 yards should give 5 yards.
        /// </summary>
        [TestMethod]
        public void Add_SameUnit_YardPlusYard_ReturnsCorrectSum()
        {
            var q1 = new Quantity(2.0, LengthUnit.YARD);
            var q2 = new Quantity(3.0, LengthUnit.YARD);

            var result = q1.Add(q2);

            Assert.AreEqual(5.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        /// <summary>
        /// Checks addition for centimeter-based quantities.
        /// Expected: 5 cm added to 5 cm equals 10 cm.
        /// </summary>
        [TestMethod]
        public void Add_SameUnit_CentimeterPlusCentimeter_ReturnsCorrectSum()
        {
            var q1 = new Quantity(5.0, LengthUnit.CENTIMETER);
            var q2 = new Quantity(5.0, LengthUnit.CENTIMETER);

            var result = q1.Add(q2);

            Assert.AreEqual(10.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.CENTIMETER, result.Unit);
        }

        #endregion

        #region Cross-Unit Addition Tests

        /// <summary>
        /// Verifies mixed-unit addition where feet is the target unit.
        /// Example: 1 foot plus 12 inches should convert to 2 feet.
        /// </summary>
        [TestMethod]
        public void Add_CrossUnit_FeetPlusInches_ResultInFeet_ReturnsCorrectSum()
        {
            var feet = new Quantity(1.0, LengthUnit.FEET);
            var inches = new Quantity(12.0, LengthUnit.INCH);

            var result = feet.Add(inches);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        /// <summary>
        /// Ensures inches remain the output unit when inches are the first operand.
        /// Expected: 12 inches plus 1 foot equals 24 inches.
        /// </summary>
        [TestMethod]
        public void Add_CrossUnit_InchesPlusFeet_ResultInInches_ReturnsCorrectSum()
        {
            var inches = new Quantity(12.0, LengthUnit.INCH);
            var feet = new Quantity(1.0, LengthUnit.FEET);

            var result = inches.Add(feet);

            Assert.AreEqual(24.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        /// <summary>
        /// Tests yard and foot combination with yard as the output.
        /// Expected conversion: 1 yard plus 3 feet equals 2 yards.
        /// </summary>
        [TestMethod]
        public void Add_CrossUnit_YardPlusFeet_ResultInYards_ReturnsCorrectSum()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            var result = yard.Add(feet);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        /// <summary>
        /// Confirms correct behavior when inches are added to yards.
        /// Example: 36 inches combined with 1 yard equals 2 yards.
        /// </summary>
        [TestMethod]
        public void Add_CrossUnit_YardPlusInches_ResultInYards_ReturnsCorrectSum()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var inches = new Quantity(36.0, LengthUnit.INCH);

            var result = yard.Add(inches);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        /// <summary>
        /// Ensures accurate conversion when centimeters are added to inches.
        /// Example: 2.54 cm plus 1 inch equals 5.08 cm.
        /// </summary>
        [TestMethod]
        public void Add_CrossUnit_CentimeterPlusInch_ResultInCentimeters_ReturnsCorrectSum()
        {
            var cm = new Quantity(2.54, LengthUnit.CENTIMETER);
            var inch = new Quantity(1.0, LengthUnit.INCH);

            var result = cm.Add(inch);

            Assert.AreEqual(5.08, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.CENTIMETER, result.Unit);
        }

        #endregion

        #region Zero Addition Tests

        /// <summary>
        /// Confirms that adding zero does not modify the original quantity.
        /// Zero may be expressed in any compatible unit.
        /// </summary>
        [TestMethod]
        public void Add_WithZero_ReturnsOriginalValue()
        {
            var q = new Quantity(5.0, LengthUnit.FEET);
            var zero = new Quantity(0.0, LengthUnit.INCH);

            var result = q.Add(zero);

            Assert.AreEqual(5.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        #endregion

        #region Negative Value Tests

        /// <summary>
        /// Validates addition behavior when negative values are involved.
        /// Example: 5 feet plus -2 feet should result in 3 feet.
        /// </summary>
        [TestMethod]
        public void Add_WithNegativeValues_ReturnsCorrectSum()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(-2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        #endregion

        #region Null and Invalid Input Tests

        /// <summary>
        /// Ensures the Add method throws an exception when a null operand is used.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullOperand_ThrowsArgumentNullException()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity? q2 = null;

            q1.Add(q2!);
        }

        /// <summary>
        /// Verifies that an invalid target unit triggers an ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InvalidTargetUnit_ThrowsArgumentException()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            LengthUnit invalidUnit = (LengthUnit)99;
            q1.Add(q2, invalidUnit);
        }

        #endregion
    }
}