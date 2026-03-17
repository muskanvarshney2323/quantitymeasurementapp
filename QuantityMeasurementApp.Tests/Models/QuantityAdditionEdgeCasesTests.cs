using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityAdditionTests
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void Add_SameUnit_FeetPlusFeet_ReturnsCorrectSum()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_SameUnit_InchPlusInch_ReturnsCorrectSum()
        {
            var q1 = new Quantity(6.0, LengthUnit.INCH);
            var q2 = new Quantity(6.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(12.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Add_SameUnit_YardPlusYard_ReturnsCorrectSum()
        {
            var q1 = new Quantity(2.0, LengthUnit.YARD);
            var q2 = new Quantity(3.0, LengthUnit.YARD);

            var result = q1.Add(q2);

            Assert.AreEqual(5.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        [TestMethod]
        public void Add_SameUnit_CentimeterPlusCentimeter_ReturnsCorrectSum()
        {
            var q1 = new Quantity(5.0, LengthUnit.CENTIMETER);
            var q2 = new Quantity(5.0, LengthUnit.CENTIMETER);

            var result = q1.Add(q2);

            Assert.AreEqual(10.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.CENTIMETER, result.Unit);
        }

        [TestMethod]
        public void Add_CrossUnit_FeetPlusInches_ResultInFeet_ReturnsCorrectSum()
        {
            var feet = new Quantity(1.0, LengthUnit.FEET);
            var inches = new Quantity(12.0, LengthUnit.INCH);

            var result = feet.Add(inches);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_CrossUnit_InchesPlusFeet_ResultInInches_ReturnsCorrectSum()
        {
            var inches = new Quantity(12.0, LengthUnit.INCH);
            var feet = new Quantity(1.0, LengthUnit.FEET);

            var result = inches.Add(feet);

            Assert.AreEqual(24.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Add_CrossUnit_YardPlusFeet_ResultInYards_ReturnsCorrectSum()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var feet = new Quantity(3.0, LengthUnit.FEET);

            var result = yard.Add(feet);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        [TestMethod]
        public void Add_CrossUnit_YardPlusInches_ResultInYards_ReturnsCorrectSum()
        {
            var yard = new Quantity(1.0, LengthUnit.YARD);
            var inches = new Quantity(36.0, LengthUnit.INCH);

            var result = yard.Add(inches);

            Assert.AreEqual(2.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        [TestMethod]
        public void Add_CrossUnit_CentimeterPlusInch_ResultInCentimeters_ReturnsCorrectSum()
        {
            var cm = new Quantity(2.54, LengthUnit.CENTIMETER);
            var inch = new Quantity(1.0, LengthUnit.INCH);

            var result = cm.Add(inch);

            Assert.AreEqual(5.08, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.CENTIMETER, result.Unit);
        }

        [TestMethod]
        public void Add_WithZero_ReturnsOriginalValue()
        {
            var q = new Quantity(5.0, LengthUnit.FEET);
            var zero = new Quantity(0.0, LengthUnit.INCH);

            var result = q.Add(zero);

            Assert.AreEqual(5.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Add_WithNegativeValues_ReturnsCorrectSum()
        {
            var q1 = new Quantity(5.0, LengthUnit.FEET);
            var q2 = new Quantity(-2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, Tolerance);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullOperand_ThrowsArgumentNullException()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            Quantity? q2 = null;

            q1.Add(q2!);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_InvalidTargetUnit_ThrowsArgumentException()
        {
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(1.0, LengthUnit.FEET);

            LengthUnit invalidUnit = (LengthUnit)99;
            q1.Add(q2, invalidUnit);
        }
    }
}