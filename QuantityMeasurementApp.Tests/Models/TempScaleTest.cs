using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Entities;
using System;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class TemperatureScaleTests
    {
        private const double Precision = 0.01;

        [TestMethod]
        public void ToBaseUnit_Celsius_ReturnsSameValue()
        {
            double result = TemperatureScale.CELSIUS.ToBaseUnit(100);

            Assert.AreEqual(100, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_Fahrenheit_ReturnsCelsiusValue()
        {
            double result = TemperatureScale.FAHRENHEIT.ToBaseUnit(212);

            Assert.AreEqual(100, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_Kelvin_ReturnsCelsiusValue()
        {
            double result = TemperatureScale.KELVIN.ToBaseUnit(273.15);

            Assert.AreEqual(0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_Celsius_ReturnsSameValue()
        {
            double result = TemperatureScale.CELSIUS.FromBaseUnit(25);

            Assert.AreEqual(25, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_Fahrenheit_ReturnsConvertedValue()
        {
            double result = TemperatureScale.FAHRENHEIT.FromBaseUnit(100);

            Assert.AreEqual(212, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_Kelvin_ReturnsConvertedValue()
        {
            double result = TemperatureScale.KELVIN.FromBaseUnit(0);

            Assert.AreEqual(273.15, result, Precision);
        }

        [TestMethod]
        public void GetUnitName_Celsius_ReturnsCorrectName()
        {
            string result = TemperatureScale.CELSIUS.GetUnitName();

            Assert.AreEqual("Celsius", result);
        }

        [TestMethod]
        public void SupportsArithmetic_Temperature_ReturnsFalse()
        {
            bool result = TemperatureScale.CELSIUS.SupportsArithmetic();

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValidateOperationSupport_Addition_ThrowsException()
        {
            TemperatureScale.CELSIUS.ValidateOperationSupport("addition");
        }
    }
}