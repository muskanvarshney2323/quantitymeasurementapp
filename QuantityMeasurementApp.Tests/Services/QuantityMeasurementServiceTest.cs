using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Tests.Services
{
    [TestClass]
    public class QuantityMeasurementServiceTests
    {
        private QuantityMeasurementService _service = null!;
        private const double Delta = 0.0001;

        [TestInitialize]
        public void Init()
        {
            _service = new QuantityMeasurementService();
        }

        [TestMethod]
        public void CompareQuantity_SameUnitEqualValues_ReturnsTrue()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsTrue(_service.CompareQuantityEquality(q1, q2));
        }

        [TestMethod]
        public void CompareQuantity_SameUnitDifferentValues_ReturnsFalse()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);

            Assert.IsFalse(_service.CompareQuantityEquality(q1, q2));
        }

        [TestMethod]
        public void CompareQuantity_CrossUnitEquivalent_ReturnsTrue()
        {
            var feet = new Quantity(1.0, LengthUnit.FEET);
            var inch = new Quantity(12.0, LengthUnit.INCH);

            Assert.IsTrue(_service.CompareQuantityEquality(feet, inch));
        }

        [TestMethod]
        public void CompareQuantity_CrossUnitNotEquivalent_ReturnsFalse()
        {
            var feet = new Quantity(1.0, LengthUnit.FEET);
            var inch = new Quantity(13.0, LengthUnit.INCH);

            Assert.IsFalse(_service.CompareQuantityEquality(feet, inch));
        }

        [TestMethod]
        public void CompareQuantity_WhenNullValues_ReturnsFalse()
        {
            Quantity? q1 = null;
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            Assert.IsFalse(_service.CompareQuantityEquality(q1, q2));
        }

        [TestMethod]
        public void ParseQuantity_ValidInput_ReturnsQuantity()
        {
            var result = _service.ParseQuantityInput("3.5", LengthUnit.FEET);

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value, Delta);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void ParseQuantity_InvalidInputs_ReturnNull()
        {
            Assert.IsNull(_service.ParseQuantityInput(null, LengthUnit.FEET));
            Assert.IsNull(_service.ParseQuantityInput("", LengthUnit.FEET));
            Assert.IsNull(_service.ParseQuantityInput("abc", LengthUnit.FEET));
        }

        [TestMethod]
        public void ParseQuantity_NegativeNumber_ReturnsQuantity()
        {
            var result = _service.ParseQuantityInput("-2.5", LengthUnit.FEET);

            Assert.IsNotNull(result);
            Assert.AreEqual(-2.5, result!.Value, Delta);
        }

        [TestMethod]
        public void AreQuantitiesEqual_SameUnitEqual_ReturnsTrue()
        {
            bool result = _service.AreQuantitiesEqual(1, LengthUnit.FEET, 1, LengthUnit.FEET);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AreQuantitiesEqual_SameUnitDifferent_ReturnsFalse()
        {
            bool result = _service.AreQuantitiesEqual(1, LengthUnit.FEET, 2, LengthUnit.FEET);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AreQuantitiesEqual_CrossUnitEquivalent_ReturnsTrue()
        {
            bool result = _service.AreQuantitiesEqual(1, LengthUnit.FEET, 12, LengthUnit.INCH);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompareFeetEquality_EqualValues_ReturnsTrue()
        {
            var f1 = new Feet(1);
            var f2 = new Feet(1);

            Assert.IsTrue(_service.CompareFeetEquality(f1, f2));
        }

        [TestMethod]
        public void ParseFeetInput_ValidValue_ReturnsFeet()
        {
            var result = _service.ParseFeetInput("3.5");

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value, Delta);
        }

        [TestMethod]
        public void CompareInchEquality_EqualValues_ReturnsTrue()
        {
            var i1 = new Inch(1);
            var i2 = new Inch(1);

            Assert.IsTrue(_service.CompareInchEquality(i1, i2));
        }

        [TestMethod]
        public void ParseInchInput_ValidValue_ReturnsInch()
        {
            var result = _service.ParseInchInput("3.5");

            Assert.IsNotNull(result);
            Assert.AreEqual(3.5, result!.Value, Delta);
        }

        [TestMethod]
        public void CompareQuantity_YardAndFeetEquivalent_ReturnsTrue()
        {
            var yard = new Quantity(1, LengthUnit.YARD);
            var feet = new Quantity(3, LengthUnit.FEET);

            Assert.IsTrue(_service.CompareQuantityEquality(yard, feet));
        }

        [TestMethod]
        public void CompareQuantity_CentimeterAndFeetEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(30.48, LengthUnit.CENTIMETER);
            var ft = new Quantity(1, LengthUnit.FEET);

            Assert.IsTrue(_service.CompareQuantityEquality(cm, ft));
        }

        [TestMethod]
        public void CompareQuantity_CentimeterAndYardEquivalent_ReturnsTrue()
        {
            var cm = new Quantity(91.44, LengthUnit.CENTIMETER);
            var yard = new Quantity(1, LengthUnit.YARD);

            Assert.IsTrue(_service.CompareQuantityEquality(cm, yard));
        }
    }
}