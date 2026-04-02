using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementAppModel.Entities;
using System;

namespace QuantityMeasurementApp.Tests.Models
{
    [TestClass]
    public class QuantityTemperatureTests
    {
        private const double Precision = 0.01;

        [TestMethod]
        public void Equality_ZeroCelsius_AndThirtyTwoFahrenheit_ReturnsTrue()
        {
            var celsius = new Quantity<TemperatureScale>(0, TemperatureScale.CELSIUS);
            var fahrenheit = new Quantity<TemperatureScale>(32, TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(celsius, fahrenheit);
        }

        [TestMethod]
        public void Equality_HundredCelsius_AndTwoHundredTwelveFahrenheit_ReturnsTrue()
        {
            var celsius = new Quantity<TemperatureScale>(100, TemperatureScale.CELSIUS);
            var fahrenheit = new Quantity<TemperatureScale>(212, TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(celsius, fahrenheit);
        }

        [TestMethod]
        public void Equality_ZeroCelsius_AndTwoSeventyThreePointFifteenKelvin_ReturnsTrue()
        {
            var celsius = new Quantity<TemperatureScale>(0, TemperatureScale.CELSIUS);
            var kelvin = new Quantity<TemperatureScale>(273.15, TemperatureScale.KELVIN);

            Assert.AreEqual(celsius, kelvin);
        }

        [TestMethod]
        public void Equality_MinusFortyCelsius_AndMinusFortyFahrenheit_ReturnsTrue()
        {
            var celsius = new Quantity<TemperatureScale>(-40, TemperatureScale.CELSIUS);
            var fahrenheit = new Quantity<TemperatureScale>(-40, TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(celsius, fahrenheit);
        }

        [TestMethod]
        public void ConvertTo_CelsiusToFahrenheit_ReturnsCorrectResult()
        {
            var celsius = new Quantity<TemperatureScale>(100, TemperatureScale.CELSIUS);

            Quantity<TemperatureScale> converted =
                celsius.ConvertTo(TemperatureScale.FAHRENHEIT);

            Assert.AreEqual(212, converted.Value, Precision);
            Assert.AreEqual(TemperatureScale.FAHRENHEIT, converted.Unit);
        }

        [TestMethod]
        public void ConvertTo_FahrenheitToCelsius_ReturnsCorrectResult()
        {
            var fahrenheit = new Quantity<TemperatureScale>(32, TemperatureScale.FAHRENHEIT);

            Quantity<TemperatureScale> converted =
                fahrenheit.ConvertTo(TemperatureScale.CELSIUS);

            Assert.AreEqual(0, converted.Value, Precision);
            Assert.AreEqual(TemperatureScale.CELSIUS, converted.Unit);
        }

        [TestMethod]
        public void ConvertTo_KelvinToCelsius_ReturnsCorrectResult()
        {
            var kelvin = new Quantity<TemperatureScale>(273.15, TemperatureScale.KELVIN);

            Quantity<TemperatureScale> converted =
                kelvin.ConvertTo(TemperatureScale.CELSIUS);

            Assert.AreEqual(0, converted.Value, Precision);
            Assert.AreEqual(TemperatureScale.CELSIUS, converted.Unit);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_Temperature_ThrowsInvalidOperationException()
        {
            var first = new Quantity<TemperatureScale>(10, TemperatureScale.CELSIUS);
            var second = new Quantity<TemperatureScale>(20, TemperatureScale.CELSIUS);

            first.Add(second);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Subtract_Temperature_ThrowsInvalidOperationException()
        {
            var first = new Quantity<TemperatureScale>(30, TemperatureScale.CELSIUS);
            var second = new Quantity<TemperatureScale>(10, TemperatureScale.CELSIUS);

            first.Subtract(second);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_Temperature_ThrowsInvalidOperationException()
        {
            var first = new Quantity<TemperatureScale>(30, TemperatureScale.CELSIUS);
            var second = new Quantity<TemperatureScale>(10, TemperatureScale.CELSIUS);

            first.Divide(second);
        }
    }
}