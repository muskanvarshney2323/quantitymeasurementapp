using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class InchMeasurementTests
    {
        [TestMethod]
        public void InchMeasurement_SameValue_ShouldBeEqual()
        {
            InchMeasurement first = new InchMeasurement(1.0);
            InchMeasurement second = new InchMeasurement(1.0);

            Assert.IsTrue(first.Equals(second));
        }

        [TestMethod]
        public void InchMeasurement_DifferentValues_ShouldNotBeEqual()
        {
            InchMeasurement first = new InchMeasurement(1.0);
            InchMeasurement second = new InchMeasurement(2.0);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void InchMeasurement_ComparedWithItself_ShouldReturnTrue()
        {
            InchMeasurement value = new InchMeasurement(2.0);

            Assert.IsTrue(value.Equals(value));
        }

        [TestMethod]
        public void InchMeasurement_ComparedWithNull_ShouldReturnFalse()
        {
            InchMeasurement value = new InchMeasurement(1.0);

            Assert.IsFalse(value.Equals(null));
        }

        [TestMethod]
        public void InchMeasurement_SymmetricRule_ShouldBeTrue()
        {
            InchMeasurement a = new InchMeasurement(3.0);
            InchMeasurement b = new InchMeasurement(3.0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        [TestMethod]
        public void InchMeasurement_TransitiveRule_ShouldBeTrue()
        {
            InchMeasurement a = new InchMeasurement(2.5);
            InchMeasurement b = new InchMeasurement(2.5);
            InchMeasurement c = new InchMeasurement(2.5);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        [TestMethod]
        public void InchMeasurement_ComparedWithDifferentType_ShouldReturnFalse()
        {
            InchMeasurement inch = new InchMeasurement(1.0);
            object obj = new object();

            Assert.IsFalse(inch.Equals(obj));
        }

        [TestMethod]
        public void InchMeasurement_ConsistencyCheck_ShouldBeTrue()
        {
            InchMeasurement first = new InchMeasurement(4.0);
            InchMeasurement second = new InchMeasurement(4.0);

            bool r1 = first.Equals(second);
            bool r2 = first.Equals(second);

            Assert.AreEqual(r1, r2);
        }

        [TestMethod]
        public void InchMeasurement_CloseFloatingValues_ShouldNotBeEqual()
        {
            InchMeasurement first = new InchMeasurement(1.000001);
            InchMeasurement second = new InchMeasurement(1.000002);

            Assert.IsFalse(first.Equals(second));
        }

        [TestMethod]
        public void InchMeasurement_EqualObjects_SameHashCode()
        {
            InchMeasurement first = new InchMeasurement(5.0);
            InchMeasurement second = new InchMeasurement(5.0);

            Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void InchMeasurement_DifferentObjects_DifferentHashCode()
        {
            InchMeasurement first = new InchMeasurement(5.0);
            InchMeasurement second = new InchMeasurement(6.0);

            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [TestMethod]
        public void InchMeasurement_ToString_ShouldReturnCorrectFormat()
        {
            InchMeasurement value = new InchMeasurement(7.5);

            string output = value.ToString();

            Assert.AreEqual("7.5 in", output);
        }
    }
}