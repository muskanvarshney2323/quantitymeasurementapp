using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services
{
    // Test suite for QuantityMeasurementService
    // Validates comparison logic and input parsing behavior
    [TestClass]
    public class QuantityMeasurementServiceTests
    {
        // Service object used across test cases
        private QuantityMeasurementService _service = null!;

        // Runs before every test case
        // Ensures a fresh service instance is created
        [TestInitialize]
        public void Setup()
        {
            _service = new QuantityMeasurementService();
        }

        // Case: Both inputs are non-null and equal
        // Expected outcome: true
        [TestMethod]
        public void CompareFeetEquality_BothNonNullEqualValues_ReturnsTrue()
        {
            // Prepare equal Feet objects
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(1.0);

            // Execute comparison
            bool result = _service.CompareFeetEquality(feet1, feet2);

            // Validate result
            Assert.IsTrue(result, "Equal values should return true");
        }

        // Case: Both inputs are non-null but different
        // Expected outcome: false
        [TestMethod]
        public void CompareFeetEquality_BothNonNullDifferentValues_ReturnsFalse()
        {
            // Prepare different Feet objects
            var feet1 = new Feet(1.0);
            var feet2 = new Feet(2.0);

            // Execute comparison
            bool result = _service.CompareFeetEquality(feet1, feet2);

            // Validate result
            Assert.IsFalse(result, "Different values should return false");
        }

        // Case: First argument is null
        // Expected outcome: false
        [TestMethod]
        public void CompareFeetEquality_FirstParameterNull_ReturnsFalse()
        {
            // First value missing, second valid
            Feet? feet1 = null;
            var feet2 = new Feet(1.0);

            // Execute comparison
            bool result = _service.CompareFeetEquality(feet1, feet2);

            // Validate result
            Assert.IsFalse(result, "Comparison with null should return false");
        }

        // Case: Second argument is null
        // Expected outcome: false
        [TestMethod]
        public void CompareFeetEquality_SecondParameterNull_ReturnsFalse()
        {
            // First valid, second missing
            var feet1 = new Feet(1.0);
            Feet? feet2 = null;

            // Execute comparison
            bool result = _service.CompareFeetEquality(feet1, feet2);

            // Validate result
            Assert.IsFalse(result, "Comparison with null should return false");
        }

        // Case: Both arguments are null
        // Expected outcome: false
        [TestMethod]
        public void CompareFeetEquality_BothParametersNull_ReturnsFalse()
        {
            // Both inputs missing
            Feet? feet1 = null;
            Feet? feet2 = null;

            // Execute comparison
            bool result = _service.CompareFeetEquality(feet1, feet2);

            // Validate result
            Assert.IsFalse(result, "Comparison with both null should return false");
        }

        // Case: Valid numeric string input
        // Expected outcome: Feet object created
        [TestMethod]
        public void ParseFeetInput_ValidNumericString_ReturnsFeetObject()
        {
            // Numeric input string
            string input = "3.5";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNotNull(result, "Should return non-null Feet object");
            Assert.AreEqual(3.5, result!.Value, 0.0001, "Parsed value should match input");
        }

        // Case: Input is null
        // Expected outcome: null
        [TestMethod]
        public void ParseFeetInput_NullInput_ReturnsNull()
        {
            // Null input
            string? input = null;

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNull(result, "Null input should return null");
        }

        // Case: Empty string input
        // Expected outcome: null
        [TestMethod]
        public void ParseFeetInput_EmptyString_ReturnsNull()
        {
            // Empty input
            string input = "";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNull(result, "Empty string should return null");
        }

        // Case: Input contains only spaces
        // Expected outcome: null
        [TestMethod]
        public void ParseFeetInput_Whitespace_ReturnsNull()
        {
            // Whitespace input
            string input = "   ";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNull(result, "Whitespace input should return null");
        }

        // Case: Input is not a number
        // Expected outcome: null
        [TestMethod]
        public void ParseFeetInput_NonNumericString_ReturnsNull()
        {
            // Invalid non-numeric input
            string input = "abc";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNull(result, "Non-numeric input should return null");
        }

        // Case: Negative numeric input
        // Expected outcome: Feet object created
        [TestMethod]
        public void ParseFeetInput_NegativeNumber_ReturnsFeetObject()
        {
            // Negative value input
            string input = "-2.5";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNotNull(result, "Negative values should be accepted");
            Assert.AreEqual(-2.5, result!.Value, 0.0001, "Parsed value should be negative");
        }

        // Case: Zero value input
        // Expected outcome: Feet object created
        [TestMethod]
        public void ParseFeetInput_Zero_ReturnsFeetObject()
        {
            // Zero input
            string input = "0";

            // Parse input
            Feet? result = _service.ParseFeetInput(input);

            // Validate output
            Assert.IsNotNull(result, "Zero should be accepted");
            Assert.AreEqual(0, result!.Value, 0.0001, "Parsed value should be zero");
        }
    }
}