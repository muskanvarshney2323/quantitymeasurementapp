using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class LengthUnitTests
    {
        private const double Tolerance = 0.000001;

        [TestMethod]
        public void ToFeetFactor_FeetUnit_ReturnsOne()
        {
            double factor = LengthUnit.FEET.ToFeetFactor();
            Assert.AreEqual(1.0, factor, Tolerance);
        }

        [TestMethod]
        public void ToFeetFactor_InchUnit_ReturnsOneTwelfth()
        {
            double factor = LengthUnit.INCH.ToFeetFactor();
            Assert.AreEqual(1.0 / 12.0, factor, Tolerance);
        }

        [TestMethod]
        public void ToFeetFactor_YardUnit_ReturnsThree()
        {
            double factor = LengthUnit.YARD.ToFeetFactor();
            Assert.AreEqual(3.0, factor, Tolerance);
        }

        [TestMethod]
        public void ToFeetFactor_CentimeterUnit_ReturnsCorrectValue()
        {
            double factor = LengthUnit.CENTIMETER.ToFeetFactor();
            Assert.AreEqual(1.0 / 30.48, factor, Tolerance);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Feet_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.ConvertToBaseUnit(5.0);
            Assert.AreEqual(5.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Inch_ReturnsFeetValue()
        {
            double result = LengthUnit.INCH.ConvertToBaseUnit(12.0);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Yard_ReturnsFeetValue()
        {
            double result = LengthUnit.YARD.ConvertToBaseUnit(1.0);
            Assert.AreEqual(3.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertToBaseUnit_Centimeter_ReturnsFeetValue()
        {
            double result = LengthUnit.CENTIMETER.ConvertToBaseUnit(30.48);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Feet_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.ConvertFromBaseUnit(2.0);
            Assert.AreEqual(2.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Inch_ReturnsInchValue()
        {
            double result = LengthUnit.INCH.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(12.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Yard_ReturnsYardValue()
        {
            double result = LengthUnit.YARD.ConvertFromBaseUnit(3.0);
            Assert.AreEqual(1.0, result, Tolerance);
        }

        [TestMethod]
        public void ConvertFromBaseUnit_Centimeter_ReturnsCentimeterValue()
        {
            double result = LengthUnit.CENTIMETER.ConvertFromBaseUnit(1.0);
            Assert.AreEqual(30.48, result, Tolerance);
        }

        [TestMethod]
        public void GetSymbol_FeetUnit_ReturnsFt()
        {
            string symbol = LengthUnit.FEET.GetSymbol();
            Assert.AreEqual("ft", symbol);
        }

        [TestMethod]
        public void GetSymbol_InchUnit_ReturnsIn()
        {
            string symbol = LengthUnit.INCH.GetSymbol();
            Assert.AreEqual("in", symbol);
        }

        [TestMethod]
        public void GetSymbol_YardUnit_ReturnsYd()
        {
            string symbol = LengthUnit.YARD.GetSymbol();
            Assert.AreEqual("yd", symbol);
        }

        [TestMethod]
        public void GetSymbol_CentimeterUnit_ReturnsCm()
        {
            string symbol = LengthUnit.CENTIMETER.GetSymbol();
            Assert.AreEqual("cm", symbol);
        }

        [TestMethod]
        public void GetUnitName_FeetUnit_ReturnsFeet()
        {
            string name = LengthUnit.FEET.GetUnitName();
            Assert.AreEqual("feet", name);
        }

        [TestMethod]
        public void GetUnitName_InchUnit_ReturnsInches()
        {
            string name = LengthUnit.INCH.GetUnitName();
            Assert.AreEqual("inches", name);
        }

        [TestMethod]
        public void GetUnitName_YardUnit_ReturnsYards()
        {
            string name = LengthUnit.YARD.GetUnitName();
            Assert.AreEqual("yards", name);
        }

        [TestMethod]
        public void GetUnitName_CentimeterUnit_ReturnsCentimeters()
        {
            string name = LengthUnit.CENTIMETER.GetUnitName();
            Assert.AreEqual("centimeters", name);
        }

        [TestMethod]
        public void ToFeetFactor_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.ToFeetFactor());
        }

        [TestMethod]
        public void ConvertToBaseUnit_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.ConvertToBaseUnit(10.0));
        }

        [TestMethod]
        public void ConvertFromBaseUnit_InvalidUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)99;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.ConvertFromBaseUnit(10.0));
        }
    }
}