using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityTests
    {
        [TestMethod]
        public void Equals_SameUnitAndValue_ShouldBeTrue()
        {
            Quantity q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void Equals_SameUnitDifferentValue_ShouldBeFalse()
        {
            Quantity q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(2.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void Equals_CrossUnitEquivalent_ShouldBeTrue()
        {
            Quantity q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void Equals_CrossUnitNotEquivalent_ShouldBeFalse()
        {
            Quantity q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(13.0, LengthUnit.INCH);
            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void Equals_Reflexive_ShouldBeTrue()
        {
            Quantity q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsTrue(q.Equals(q));
        }

        [TestMethod]
        public void Equals_Null_ShouldBeFalse()
        {
            Quantity q = new Quantity(1.0, LengthUnit.FEET);
            Assert.IsFalse(q.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentType_ShouldBeFalse()
        {
            Quantity q = new Quantity(1.0, LengthUnit.FEET);
            object obj = new object();
            Assert.IsFalse(q.Equals(obj));
        }

        [TestMethod]
        public void GetHashCode_EqualObjects_ShouldMatch()
        {
            Quantity q1 = new Quantity(5.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(5.0, LengthUnit.FEET);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_CrossUnitEquivalent_ShouldMatch()
        {
            Quantity q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity q2 = new Quantity(12.0, LengthUnit.INCH);
            Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
        }

        [TestMethod]
        public void ToString_Feet_ShouldFormatCorrectly()
        {
            Quantity q = new Quantity(7.5, LengthUnit.FEET);
            Assert.AreEqual("7.5 ft", q.ToString());
        }

        [TestMethod]
        public void ToString_Inch_ShouldFormatCorrectly()
        {
            Quantity q = new Quantity(7.5, LengthUnit.INCH);
            Assert.AreEqual("7.5 in", q.ToString());
        }
    }
}