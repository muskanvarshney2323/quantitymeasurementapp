using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class InchMeasurementTests
    {
        [TestMethod]
        public void InchObjects_WithSameValue_ShouldBeEqual()
        {
            Inch first = new Inch(1.0);
            Inch second = new Inch(1.0);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void InchObjects_WithDifferentValues_ShouldNotBeEqual()
        {
            Inch first = new Inch(1.0);
            Inch second = new Inch(2.0);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void InchObject_ComparedWithItself_ShouldReturnTrue()
        {
            Inch value = new Inch(2.0);

            Assert.IsTrue(value.Equals(value));
        }

        [TestMethod]
        public void InchObject_ComparedWithNull_ShouldReturnFalse()
        {
            Inch value = new Inch(1.0);

            Assert.IsFalse(value.Equals(null));
        }

        [TestMethod]
        public void EqualObjects_ShouldGenerateSameHashCode()
        {
            Inch first = new Inch(5.0);
            Inch second = new Inch(5.0);

            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}