using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Extensions;
using System;

namespace QuantityMeasurementApp.Tests.Enums
{
    [TestClass]
    public class WeightUnitTests
    {
        private const double Precision = 0.0001;

        [TestMethod]
        public void GetConversionFactor_Gram_ReturnsOne()
        {
            double factor = WeightUnit.GRAM.GetConversionFactor();

            Assert.AreEqual(1.0, factor, Precision);
        }

        [TestMethod]
        public void GetConversionFactor_Kilogram_ReturnsThousand()
        {
            double factor = WeightUnit.KILOGRAM.GetConversionFactor();

            Assert.AreEqual(1000.0, factor, Precision);
        }

        [TestMethod]
        public void GetConversionFactor_Tonne_ReturnsMillion()
        {
            double factor = WeightUnit.TONNE.GetConversionFactor();

            Assert.AreEqual(1000000.0, factor, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_GramValue_ReturnsSameValue()
        {
            double result = WeightUnit.GRAM.ToBaseUnit(500.0);

            Assert.AreEqual(500.0, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_KilogramValue_ReturnsGramValue()
        {
            double result = WeightUnit.KILOGRAM.ToBaseUnit(1.0);

            Assert.AreEqual(1000.0, result, Precision);
        }

        [TestMethod]
        public void ToBaseUnit_TonneValue_ReturnsGramValue()
        {
            double result = WeightUnit.TONNE.ToBaseUnit(1.0);

            Assert.AreEqual(1000000.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToGram_ReturnsSameValue()
        {
            double result = WeightUnit.GRAM.FromBaseUnit(250.0);

            Assert.AreEqual(250.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToKilogram_ReturnsConvertedValue()
        {
            double result = WeightUnit.KILOGRAM.FromBaseUnit(1000.0);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void FromBaseUnit_ToTonne_ReturnsConvertedValue()
        {
            double result = WeightUnit.TONNE.FromBaseUnit(1000000.0);

            Assert.AreEqual(1.0, result, Precision);
        }

        [TestMethod]
        public void GetUnitName_Gram_ReturnsGram()
        {
            string unitName = WeightUnit.GRAM.GetUnitName();

            Assert.AreEqual("GRAM", unitName);
        }

        [TestMethod]
        public void GetUnitName_Kilogram_ReturnsKilogram()
        {
            string unitName = WeightUnit.KILOGRAM.GetUnitName();

            Assert.AreEqual("KILOGRAM", unitName);
        }

        [TestMethod]
        public void GetUnitName_Tonne_ReturnsTonne()
        {
            string unitName = WeightUnit.TONNE.GetUnitName();

            Assert.AreEqual("TONNE", unitName);
        }

        [TestMethod]
        public void InvalidWeightUnit_GetConversionFactor_ThrowsException()
        {
            WeightUnit invalidUnit = (WeightUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.GetConversionFactor());
        }

        [TestMethod]
        public void InvalidWeightUnit_ToBaseUnit_ThrowsException()
        {
            WeightUnit invalidUnit = (WeightUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.ToBaseUnit(10.0));
        }

        [TestMethod]
        public void InvalidWeightUnit_FromBaseUnit_ThrowsException()
        {
            WeightUnit invalidUnit = (WeightUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.FromBaseUnit(10.0));
        }

        [TestMethod]
        public void InvalidWeightUnit_GetUnitName_ThrowsException()
        {
            WeightUnit invalidUnit = (WeightUnit)999;

            Assert.ThrowsException<ArgumentException>(() => invalidUnit.GetUnitName());
        }
    }
}