using QuantityMeasurementApp.Enums;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        // ===================== LENGTH METHODS =====================

        public bool AreLengthsEqual(double value1, LengthUnit unit1, double value2, LengthUnit unit2)
        {
            Quantity first = new Quantity(value1, unit1);
            Quantity second = new Quantity(value2, unit2);

            return first.Equals(second);
        }

        public double ConvertLength(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            return Quantity.Convert(value, sourceUnit, targetUnit);
        }

        public Quantity AddLengths(double value1, LengthUnit unit1, double value2, LengthUnit unit2)
        {
            Quantity first = new Quantity(value1, unit1);
            Quantity second = new Quantity(value2, unit2);

            return first.Add(second);
        }

        public Quantity AddLengths(
            double value1,
            LengthUnit unit1,
            double value2,
            LengthUnit unit2,
            LengthUnit targetUnit)
        {
            Quantity first = new Quantity(value1, unit1);
            Quantity second = new Quantity(value2, unit2);

            return first.Add(second, targetUnit);
        }

        // ===================== WEIGHT METHODS =====================

        public bool AreWeightsEqual(double value1, WeightUnit unit1, double value2, WeightUnit unit2)
        {
            QuantityWeight first = new QuantityWeight(value1, unit1);
            QuantityWeight second = new QuantityWeight(value2, unit2);

            return first.Equals(second);
        }

        public double ConvertWeight(double value, WeightUnit sourceUnit, WeightUnit targetUnit)
        {
            QuantityWeight quantity = new QuantityWeight(value, sourceUnit);
            QuantityWeight convertedQuantity = quantity.ConvertTo(targetUnit);

            return convertedQuantity.Value;
        }

        public QuantityWeight AddWeights(double value1, WeightUnit unit1, double value2, WeightUnit unit2)
        {
            QuantityWeight first = new QuantityWeight(value1, unit1);
            QuantityWeight second = new QuantityWeight(value2, unit2);

            return first.Add(second);
        }

        public QuantityWeight AddWeights(
            double value1,
            WeightUnit unit1,
            double value2,
            WeightUnit unit2,
            WeightUnit targetUnit)
        {
            QuantityWeight first = new QuantityWeight(value1, unit1);
            QuantityWeight second = new QuantityWeight(value2, unit2);

            return first.Add(second, targetUnit);
        }
    }
}