using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityAdditionEdgeCasesTests
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void Add_WithZero_ReturnsOriginalValue()
        {
            var q = new Quantity(5.0, LengthUnit.FEET);
            var zero = new Quantity(0.0, LengthUnit.INCH);

            var result = q.Add(zero);

            Assert.AreEqual(5.0, result.Value, Tolerance);
        }

        [TestMethod]
        public void Add_WithNegativeValues_ReturnsCorrectResult()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(-2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, Tolerance);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Add_NullOperand_ShouldThrowException()
        {
            var q = new Quantity(1.0, LengthUnit.FEET);
            q.Add(null!);
        }
    }
}