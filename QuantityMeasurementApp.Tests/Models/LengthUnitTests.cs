
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Extensions;
using System;

namespace QuantityMeasurementApp.Tests.Enums
{
    [TestClass]
    public class LengthUnitTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void GetConversionFactor_Feet_ReturnsOne()
        {
            double factor = LengthUnit.FEET.GetConversionFactor();

            Assert.AreEqual(1.0, factor, Precision);
        }

        [TestMethod]
        public void GetConversionFactor_Inch_ReturnsOneByTwelve()
        {
            double factor = LengthUnit.INCH.GetConversionFactor();

            Assert.AreEqual(1.0 / 12.0, factor, Precision);
        }

        [TestMethod]
        public void GetConversionFactor_Yard_ReturnsThree()
        {
            double factor = LengthUnit.YARD.GetConversionFactor();

            Assert.AreEqual(3.0, factor, Precision);
        }

        [TestMethod]
        public void GetConversionFactor_Centimeter_ReturnsExpectedValue()
        {
            double factor = LengthUnit.CENTIMETER.GetConversionFactor();

            Assert.AreEqual(1.0 / 30.48, factor, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_FeetValue_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.ToBaseUnit(5.0);

            Assert.AreEqual(5.0, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_InchValue_ReturnsFeetValue()
        {
            double result = LengthUnit.INCH.ToBaseUnit(12.0);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_YardValue_ReturnsFeetValue()
        {
            double result = LengthUnit.YARD.ToBaseUnit(1.0);

            Assert.AreEqual(3.0, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_CentimeterValue_ReturnsFeetValue()
        {
            double result = LengthUnit.CENTIMETER.ToBaseUnit(30.48);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_FeetValue_ReturnsSameValue()
        {
            double result = LengthUnit.FEET.FromBaseUnit(5.0);

            Assert.AreEqual(5.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToInch_ReturnsConvertedValue()
        {
            double result = LengthUnit.INCH.FromBaseUnit(1.0);

            Assert.AreEqual(12.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToYard_ReturnsConvertedValue()
        {
            double result = LengthUnit.YARD.FromBaseUnit(3.0);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToCentimeter_ReturnsConvertedValue()
        {
            double result = LengthUnit.CENTIMETER.FromBaseUnit(1.0);

            Assert.AreEqual(30.48, result, Precision);
        }

        [TestMethod]
        public void GetUnitName_Feet_ReturnsFeet()
        {
            string unitName = LengthUnit.FEET.GetUnitName();

            Assert.AreEqual("FEET", unitName);
        }

        [TestMethod]
        public void GetUnitName_Inch_ReturnsInch()
        {
            string unitName = LengthUnit.INCH.GetUnitName();

            Assert.AreEqual("INCH", unitName);
        }

        [TestMethod]
        public void GetUnitName_Yard_ReturnsYard()
        {
            string unitName = LengthUnit.YARD.GetUnitName();

            Assert.AreEqual("YARD", unitName);
        }

        [TestMethod]
        public void GetUnitName_Centimeter_ReturnsCentimeter()
        {
            string unitName = LengthUnit.CENTIMETER.GetUnitName();

            Assert.AreEqual("CENTIMETER", unitName);
        }

        [TestMethod]
        public void InvalidLengthUnit_GetConversionFactor_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.GetConversionFactor());
        }

        [TestMethod]
        public void InvalidLengthUnit_ToBaseUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.ToBaseUnit(10.0));
        }

        [TestMethod]
        public void InvalidLengthUnit_FromBaseUnit_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.FromBaseUnit(10.0));
        }

        [TestMethod]
        public void InvalidLengthUnit_GetUnitName_ThrowsException()
        {
            LengthUnit invalidUnit = (LengthUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.GetUnitName());
        }
    }
}