using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services
{
    [TestClass]
    public class QuantityMeasurementServiceTestCases
    {
        private QuantityMeasurementService _quantityService = null!;

        [TestInitialize]
        public void Initialize()
        {
            _quantityService = new QuantityMeasurementService();
        }

        #region Feet Related Tests

        [TestMethod]
        public void CompareFeet_WhenBothValuesSame_ShouldReturnTrue()
        {
            Feet first = new Feet(1.0);
            Feet second = new Feet(1.0);

            bool isEqual = _quantityService.CompareFeetEquality(first, second);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void CompareFeet_WhenValuesDifferent_ShouldReturnFalse()
        {
            Feet first = new Feet(1.0);
            Feet second = new Feet(2.0);

            bool isEqual = _quantityService.CompareFeetEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareFeet_WhenFirstValueIsNull_ShouldReturnFalse()
        {
            Feet? first = null;
            Feet second = new Feet(1.0);

            bool isEqual = _quantityService.CompareFeetEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareFeet_WhenSecondValueIsNull_ShouldReturnFalse()
        {
            Feet first = new Feet(1.0);
            Feet? second = null;

            bool isEqual = _quantityService.CompareFeetEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareFeet_WhenBothValuesAreNull_ShouldReturnFalse()
        {
            Feet? first = null;
            Feet? second = null;

            bool isEqual = _quantityService.CompareFeetEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenValidNumberProvided_ShouldCreateFeet()
        {
            string inputValue = "3.5";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNotNull(feet);
            Assert.AreEqual(3.5, feet!.Value, 0.0001);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenInputIsNull_ShouldReturnNull()
        {
            string? inputValue = null;

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNull(feet);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenInputIsEmpty_ShouldReturnNull()
        {
            string inputValue = "";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNull(feet);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenInputIsOnlySpaces_ShouldReturnNull()
        {
            string inputValue = "   ";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNull(feet);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenInputIsInvalidText_ShouldReturnNull()
        {
            string inputValue = "xyz";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNull(feet);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenNegativeValueProvided_ShouldCreateFeet()
        {
            string inputValue = "-2.5";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNotNull(feet);
            Assert.AreEqual(-2.5, feet!.Value, 0.0001);
        }

        [TestMethod]
        public void ConvertStringToFeet_WhenZeroProvided_ShouldCreateFeet()
        {
            string inputValue = "0";

            Feet? feet = _quantityService.ParseFeetInput(inputValue);

            Assert.IsNotNull(feet);
            Assert.AreEqual(0, feet!.Value, 0.0001);
        }

        [TestMethod]
        public void StaticFeetComparison_WhenValuesMatch_ShouldReturnTrue()
        {
            bool result = QuantityMeasurementService.AreFeetEqual(1.0, 1.0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StaticFeetComparison_WhenValuesDoNotMatch_ShouldReturnFalse()
        {
            bool result = QuantityMeasurementService.AreFeetEqual(1.0, 2.0);

            Assert.IsFalse(result);
        }

        #endregion

        #region Inch Related Tests

        [TestMethod]
        public void CompareInch_WhenSameValuesProvided_ShouldReturnTrue()
        {
            Inch first = new Inch(1.0);
            Inch second = new Inch(1.0);

            bool isEqual = _quantityService.CompareInchEquality(first, second);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void CompareInch_WhenDifferentValuesProvided_ShouldReturnFalse()
        {
            Inch first = new Inch(1.0);
            Inch second = new Inch(2.0);

            bool isEqual = _quantityService.CompareInchEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareInch_WhenFirstValueIsNull_ShouldReturnFalse()
        {
            Inch? first = null;
            Inch second = new Inch(1.0);

            bool isEqual = _quantityService.CompareInchEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareInch_WhenSecondValueIsNull_ShouldReturnFalse()
        {
            Inch first = new Inch(1.0);
            Inch? second = null;

            bool isEqual = _quantityService.CompareInchEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void CompareInch_WhenBothValuesAreNull_ShouldReturnFalse()
        {
            Inch? first = null;
            Inch? second = null;

            bool isEqual = _quantityService.CompareInchEquality(first, second);

            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenValidNumberProvided_ShouldCreateInch()
        {
            string inputValue = "3.5";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNotNull(inch);
            Assert.AreEqual(3.5, inch!.Value, 0.0001);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenInputIsNull_ShouldReturnNull()
        {
            string? inputValue = null;

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNull(inch);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenInputIsEmpty_ShouldReturnNull()
        {
            string inputValue = "";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNull(inch);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenInputIsSpaces_ShouldReturnNull()
        {
            string inputValue = "   ";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNull(inch);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenInvalidTextProvided_ShouldReturnNull()
        {
            string inputValue = "abc";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNull(inch);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenNegativeValueProvided_ShouldCreateInch()
        {
            string inputValue = "-2.5";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNotNull(inch);
            Assert.AreEqual(-2.5, inch!.Value, 0.0001);
        }

        [TestMethod]
        public void ConvertStringToInch_WhenZeroProvided_ShouldCreateInch()
        {
            string inputValue = "0";

            Inch? inch = _quantityService.ParseInchInput(inputValue);

            Assert.IsNotNull(inch);
            Assert.AreEqual(0, inch!.Value, 0.0001);
        }

        [TestMethod]
        public void StaticInchComparison_WhenValuesMatch_ShouldReturnTrue()
        {
            bool result = QuantityMeasurementService.AreInchEqual(1.0, 1.0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StaticInchComparison_WhenValuesDoNotMatch_ShouldReturnFalse()
        {
            bool result = QuantityMeasurementService.AreInchEqual(1.0, 2.0);

            Assert.IsFalse(result);
        }

        #endregion
    }
}