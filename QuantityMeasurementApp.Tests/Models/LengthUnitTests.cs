using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Tests.Enums
{
    [TestClass]
    public class LengthUnitTests
    {
        [TestMethod]
        public void ToBaseUnit_Feet_ReturnsOne()
        {
            double factor = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.FEET, 1.0);

            Assert.AreEqual(1.0, factor, 0.0001);
        }

        [TestMethod]
        public void ToBaseUnit_Inch_ReturnsOneByTwelve()
        {
            double factor = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.INCH, 1.0);

            Assert.AreEqual(1.0 / 12.0, factor, 0.0001);
        }

        [TestMethod]
        public void ToBaseUnit_Yard_ReturnsThree()
        {
            double factor = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.YARD, 1.0);

            Assert.AreEqual(3.0, factor, 0.0001);
        }

        [TestMethod]
        public void ToBaseUnit_Centimeter_ReturnsExpectedFactor()
        {
            double factor = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.CENTIMETER, 1.0);

            Assert.AreEqual(1.0 / 30.48, factor, 0.0001);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Feet_ReturnsSameValue()
        {
            double baseValue = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.FEET, 5.0);

            Assert.AreEqual(5.0, baseValue, 0.0001);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Inch_ReturnsFeetValue()
        {
            double baseValue = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.INCH, 24.0);

            Assert.AreEqual(2.0, baseValue, 0.0001);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Yard_ReturnsFeetValue()
        {
            double baseValue = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.YARD, 2.0);

            Assert.AreEqual(6.0, baseValue, 0.0001);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Centimeter_ReturnsFeetValue()
        {
            double baseValue = QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(LengthUnit.CENTIMETER, 30.48);

            Assert.AreEqual(1.0, baseValue, 0.0001);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Feet_ReturnsSameValue()
        {
            double value = QuantityMeasurementApp.Extensions.LengthUnitExtensions.FromBaseUnit(LengthUnit.FEET, 5.0);

            Assert.AreEqual(5.0, value, 0.0001);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Inch_ReturnsInchValue()
        {
            double value = QuantityMeasurementApp.Extensions.LengthUnitExtensions.FromBaseUnit(LengthUnit.INCH, 2.0);

            Assert.AreEqual(24.0, value, 0.0001);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Yard_ReturnsYardValue()
        {
            double value = QuantityMeasurementApp.Extensions.LengthUnitExtensions.FromBaseUnit(LengthUnit.YARD, 6.0);

            Assert.AreEqual(2.0, value, 0.0001);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Centimeter_ReturnsCentimeterValue()
        {
            double value = QuantityMeasurementApp.Extensions.LengthUnitExtensions.FromBaseUnit(LengthUnit.CENTIMETER, 1.0);

            Assert.AreEqual(30.48, value, 0.0001);
        }

        [TestMethod]
        public void GetUnitName_Feet_ReturnsFeet()
        {
            string unitName = QuantityMeasurementApp.Extensions.LengthUnitExtensions.GetUnitName(LengthUnit.FEET);

            Assert.AreEqual("FEET", unitName);
        }

        [TestMethod]
        public void GetUnitName_Inch_ReturnsInch()
        {
            string unitName = QuantityMeasurementApp.Extensions.LengthUnitExtensions.GetUnitName(LengthUnit.INCH);

            Assert.AreEqual("INCH", unitName);
        }

        [TestMethod]
        public void GetUnitName_Yard_ReturnsYard()
        {
            string unitName = QuantityMeasurementApp.Extensions.LengthUnitExtensions.GetUnitName(LengthUnit.YARD);

            Assert.AreEqual("YARD", unitName);
        }

        [TestMethod]
        public void GetUnitName_Centimeter_ReturnsCentimeter()
        {
            string unitName = QuantityMeasurementApp.Extensions.LengthUnitExtensions.GetUnitName(LengthUnit.CENTIMETER);

            Assert.AreEqual("CENTIMETER", unitName);
        }

        [TestMethod]
        public void InvalidLengthUnit_ToBaseUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() =>
                QuantityMeasurementApp.Extensions.LengthUnitExtensions.ToBaseUnit(invalidUnit, 1.0));
        }

        [TestMethod]
        public void InvalidLengthUnit_GetUnitName_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() =>
                QuantityMeasurementApp.Extensions.LengthUnitExtensions.GetUnitName(invalidUnit));
        }
    }
}