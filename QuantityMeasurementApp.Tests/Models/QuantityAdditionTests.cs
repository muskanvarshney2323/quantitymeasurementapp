using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityAdditionTests
    {
        private const double Delta = 0.000001;

        private static void VerifyAddition(
            double leftValue,
            LengthUnit leftUnit,
            double rightValue,
            LengthUnit rightUnit,
            double expectedValue,
            LengthUnit expectedUnit)
        {
            // Arrange
            var left = new Quantity(leftValue, leftUnit);
            var right = new Quantity(rightValue, rightUnit);

            // Act
            var sum = left.Add(right);

            // Assert
            Assert.AreEqual(expectedValue, sum.Value, Delta);
            Assert.AreEqual(expectedUnit, sum.Unit);
        }

        [TestMethod]
        public void Add_WhenBothQuantitiesAreInFeet_ShouldReturnSumInFeet()
        {
            VerifyAddition(1.0, LengthUnit.FEET, 2.0, LengthUnit.FEET, 3.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Add_WhenBothQuantitiesAreInInches_ShouldReturnSumInInches()
        {
            VerifyAddition(6.0, LengthUnit.INCH, 6.0, LengthUnit.INCH, 12.0, LengthUnit.INCH);
        }

        [TestMethod]
        public void Add_WhenBothQuantitiesAreInYards_ShouldReturnSumInYards()
        {
            VerifyAddition(2.0, LengthUnit.YARD, 3.0, LengthUnit.YARD, 5.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Add_WhenBothQuantitiesAreInCentimeters_ShouldReturnSumInCentimeters()
        {
            VerifyAddition(5.0, LengthUnit.CENTIMETER, 5.0, LengthUnit.CENTIMETER, 10.0, LengthUnit.CENTIMETER);
        }

        [TestMethod]
        public void Add_WhenFeetAndInchesAreAdded_ShouldReturnResultInFeet()
        {
            VerifyAddition(1.0, LengthUnit.FEET, 12.0, LengthUnit.INCH, 2.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Add_WhenInchesAndFeetAreAdded_ShouldReturnResultInInches()
        {
            VerifyAddition(12.0, LengthUnit.INCH, 1.0, LengthUnit.FEET, 24.0, LengthUnit.INCH);
        }

        [TestMethod]
        public void Add_WhenYardsAndFeetAreAdded_ShouldReturnResultInYards()
        {
            VerifyAddition(1.0, LengthUnit.YARD, 3.0, LengthUnit.FEET, 2.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Add_WhenYardsAndInchesAreAdded_ShouldReturnResultInYards()
        {
            VerifyAddition(1.0, LengthUnit.YARD, 36.0, LengthUnit.INCH, 2.0, LengthUnit.YARD);
        }

        [TestMethod]
        public void Add_WhenCentimetersAndInchesAreAdded_ShouldReturnResultInCentimeters()
        {
            VerifyAddition(2.54, LengthUnit.CENTIMETER, 1.0, LengthUnit.INCH, 5.08, LengthUnit.CENTIMETER);
        }

        [TestMethod]
        public void Add_WhenSecondQuantityIsZero_ShouldReturnOriginalQuantity()
        {
            VerifyAddition(5.0, LengthUnit.FEET, 0.0, LengthUnit.INCH, 5.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Add_WhenNegativeValueIsProvided_ShouldReturnCorrectResult()
        {
            VerifyAddition(5.0, LengthUnit.FEET, -2.0, LengthUnit.FEET, 3.0, LengthUnit.FEET);
        }

        [TestMethod]
        public void Add_WhenOtherQuantityIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var quantity = new Quantity(1.0, LengthUnit.FEET);

            // Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => quantity.Add(null!));
        }

        [TestMethod]
        public void Add_WhenTargetUnitIsInvalid_ShouldThrowArgumentException()
        {
            // Arrange
            var first = new Quantity(1.0, LengthUnit.FEET);
            var second = new Quantity(1.0, LengthUnit.FEET);
            var invalidUnit = (LengthUnit)99;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => first.Add(second, invalidUnit));
        }
    }
}