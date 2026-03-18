using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementServices
    {
        public Quantity<TUnit> Add<TUnit>(Quantity<TUnit> firstQuantity, Quantity<TUnit> secondQuantity)
            where TUnit : struct, Enum
        {
            return firstQuantity.Add(secondQuantity);
        }

        public Quantity<TUnit> Subtract<TUnit>(Quantity<TUnit> firstQuantity, Quantity<TUnit> secondQuantity)
            where TUnit : struct, Enum
        {
            return firstQuantity.Subtract(secondQuantity);
        }

        public double Divide<TUnit>(Quantity<TUnit> firstQuantity, Quantity<TUnit> secondQuantity)
            where TUnit : struct, Enum
        {
            return firstQuantity.Divide(secondQuantity);
        }

        public bool AreEqual<TUnit>(Quantity<TUnit> firstQuantity, Quantity<TUnit> secondQuantity)
            where TUnit : struct, Enum
        {
            return firstQuantity.Equals(secondQuantity);
        }

        public Quantity<TUnit> ConvertTo<TUnit>(Quantity<TUnit> quantity, TUnit targetUnit)
            where TUnit : struct, Enum
        {
            return quantity.ConvertTo(targetUnit);
        }

        public bool Compare<TUnit>(Quantity<TUnit> firstQuantity, Quantity<TUnit> secondQuantity)
            where TUnit : struct, Enum
        {
            return firstQuantity.Equals(secondQuantity);
        }
    }
}