using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services
{
    /// <summary>
    /// Unit test suite for validating QuantityMeasurementService behavior.
    /// Covers quantity comparison, input parsing, unit conversion checks,
    /// static comparison helpers, and support for legacy Feet and Inch models.
    /// </summary>
    [TestClass]
    public class QuantityMeasurementServiceTests
    {
        private QuantityMeasurementService _service = null!;

        [TestInitialize]
        public void Init()
        {
            _service = new QuantityMeasurementService();
        }

        #region Generic Quantity Validation

        // Verifies equality when both quantities have same value and same unit
        [TestMethod]
        public void CompareQuantityEquality_SameUnitSameValue_ShouldReturnTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsTrue(result);
        }

        // Verifies inequality when quantities differ but unit remains same
        [TestMethod]
        public void CompareQuantityEquality_SameUnitDifferentValue_ShouldReturnFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsFalse(result);
        }

        // Ensures correct comparison for equivalent values across units
        [TestMethod]
        public void CompareQuantityEquality_EquivalentCrossUnits_ShouldReturnTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsTrue(result);
        }

        // Ensures comparison fails for non-matching cross-unit values
        [TestMethod]
        public void CompareQuantityEquality_NonEquivalentCrossUnits_ShouldReturnFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(13.0, LengthUnit.INCH);

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsFalse(result);
        }

        // Handles scenario when first quantity is null
        [TestMethod]
        public void CompareQuantityEquality_FirstQuantityNull_ShouldReturnFalse()
        {
            Quantity? q1 = null;
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsFalse(result);
        }

        // Handles scenario when second quantity is null
        [TestMethod]
        public void CompareQuantityEquality_SecondQuantityNull_ShouldReturnFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity? q2 = null;

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsFalse(result);
        }

        // Handles scenario when both quantities are null
        [TestMethod]
        public void CompareQuantityEquality_BothQuantitiesNull_ShouldReturnFalse()
        {
            Quantity? q1 = null;
            Quantity? q2 = null;

            bool result = _service.CompareQuantityEquality(q1, q2);

            Assert.IsFalse(result);
        }

        // Confirms valid numeric input produces a Quantity object
        [TestMethod]
        public void ParseQuantityInput_ValidNumber_ShouldCreateQuantity()
        {
            string input = "3.5";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        // Ensures null input is safely rejected
        [TestMethod]
        public void ParseQuantityInput_NullValue_ShouldReturnNull()
        {
            string? input = null;

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNull(result);
        }

        // Ensures empty string input is rejected
        [TestMethod]
        public void ParseQuantityInput_EmptyText_ShouldReturnNull()
        {
            string input = "";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNull(result);
        }

        // Ensures whitespace-only input is rejected
        [TestMethod]
        public void ParseQuantityInput_WhitespaceOnly_ShouldReturnNull()
        {
            string input = "   ";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNull(result);
        }

        // Ensures non-numeric input is rejected
        [TestMethod]
        public void ParseQuantityInput_InvalidText_ShouldReturnNull()
        {
            string input = "abc";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNull(result);
        }

        // Confirms negative numbers are allowed
        [TestMethod]
        public void ParseQuantityInput_NegativeNumber_ShouldCreateQuantity()
        {
            string input = "-2.5";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNotNull(result);
            Assert.AreEqual(-2.5, result!.Value);
        }

        // Confirms zero is handled correctly
        [TestMethod]
        public void ParseQuantityInput_ZeroValue_ShouldCreateQuantity()
        {
            string input = "0";

            Quantity? result = _service.ParseQuantityInput(input, LengthUnit.FEET);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result!.Value);
        }

        // Static comparison with same unit and equal values
        [TestMethod]
        public void AreQuantitiesEqual_Static_SameUnitSameValue_ShouldReturnTrue()
        {
            bool result = QuantityMeasurementService.AreQuantitiesEqual(
                1.0, LengthUnit.FEET,
                1.0, LengthUnit.FEET
            );

            Assert.IsTrue(result);
        }

        // Static comparison with same unit and different values
        [TestMethod]
        public void AreQuantitiesEqual_Static_SameUnitDifferentValue_ShouldReturnFalse()
        {
            bool result = QuantityMeasurementService.AreQuantitiesEqual(
                1.0, LengthUnit.FEET,
                2.0, LengthUnit.FEET
            );

            Assert.IsFalse(result);
        }

        // Static comparison with equivalent cross-unit values
        [TestMethod]
        public void AreQuantitiesEqual_Static_CrossUnitMatch_ShouldReturnTrue()
        {
            bool result = QuantityMeasurementService.AreQuantitiesEqual(
                1.0, LengthUnit.FEET,
                12.0, LengthUnit.INCH
            );

            Assert.IsTrue(result);
        }

        // Static comparison with non-matching cross-unit values
        [TestMethod]
        public void AreQuantitiesEqual_Static_CrossUnitMismatch_ShouldReturnFalse()
        {
            bool result = QuantityMeasurementService.AreQuantitiesEqual(
                1.0, LengthUnit.FEET,
                13.0, LengthUnit.INCH
            );

            Assert.IsFalse(result);
        }

        #endregion

        #region Legacy Feet Tests

        // Validates equality comparison for Feet objects
        [TestMethod]
        public void CompareFeetEquality_IdenticalValues_ShouldReturnTrue()
        {
            var f1 = new Feet(1.0);
            var f2 = new Feet(1.0);

            bool result = _service.CompareFeetEquality(f1, f2);

            Assert.IsTrue(result);
        }

        // Confirms Feet parsing with valid input
        [TestMethod]
        public void ParseFeetInput_ValidNumber_ShouldCreateFeet()
        {
            string input = "3.5";

            Feet? result = _service.ParseFeetInput(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value, 0.0001);
        }

        #endregion

        #region Legacy Inch Tests

        // Validates equality comparison for Inch objects
        [TestMethod]
        public void CompareInchEquality_IdenticalValues_ShouldReturnTrue()
        {
            var i1 = new Inch(1.0);
            var i2 = new Inch(1.0);

            bool result = _service.CompareInchEquality(i1, i2);

            Assert.IsTrue(result);
        }

        // Confirms Inch parsing with valid input
        [TestMethod]
        public void ParseInchInput_ValidNumber_ShouldCreateInch()
        {
            string input = "3.5";

            Inch? result = _service.ParseInchInput(input);

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value, 0.0001);
        }

        #endregion
    }
}