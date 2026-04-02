using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Enums;
using QuantityMeasurementAppModel.Entities;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityRefactoringTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void Add_ShouldStillWork_AfterRefactoring()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = first.Add(second);

            Assert.AreEqual(2.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Subtract_ShouldStillWork_AfterRefactoring()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(6.0, LengthUnit.INCH);

            var result = first.Subtract(second);

            Assert.AreEqual(9.5, result.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void Divide_ShouldStillWork_AfterRefactoring()
        {
            var first = new Quantity<LengthUnit>(24.0, LengthUnit.INCH);
            var second = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            double result = first.Divide(second);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void Add_NullOperand_ShouldThrowSameException()
        {
            var quantity = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            var exception = Assert.ThrowsException<ArgumentException>(() => quantity.Add(null));

            Assert.AreEqual("Operand cannot be null", exception.Message);
        }

        [TestMethod]
        public void Subtract_NullOperand_ShouldThrowSameException()
        {
            var quantity = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            var exception = Assert.ThrowsException<ArgumentException>(() => quantity.Subtract(null));

            Assert.AreEqual("Operand cannot be null", exception.Message);
        }

        [TestMethod]
        public void Divide_NullOperand_ShouldThrowSameException()
        {
            var quantity = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

            var exception = Assert.ThrowsException<ArgumentException>(() => quantity.Divide(null));

            Assert.AreEqual("Operand cannot be null", exception.Message);
        }

        [TestMethod]
        public void Divide_ByZero_ShouldThrowException()
        {
            var first = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);

            var exception = Assert.ThrowsException<ArithmeticException>(() => first.Divide(second));

            Assert.AreEqual("Cannot divide by zero", exception.Message);
        }

        [TestMethod]
        public void Add_WithExplicitTargetUnit_ShouldReturnTargetUnitResult()
        {
            var first = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = first.Add(second, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Subtract_WithExplicitTargetUnit_ShouldReturnTargetUnitResult()
        {
            var first = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = first.Subtract(second, LengthUnit.INCH);

            Assert.AreEqual(48.0, result.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void Arithmetic_ShouldNotModifyOriginalObjects()
        {
            var first = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);
            var second = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = first.Add(second);

            Assert.AreEqual(2.0, first.Value, Precision);
            Assert.AreEqual(LengthUnit.FEET, first.Unit);
            Assert.AreEqual(12.0, second.Value, Precision);
            Assert.AreEqual(LengthUnit.INCH, second.Unit);

            Assert.AreEqual(3.0, result.Value, Precision);
        }
    }
}