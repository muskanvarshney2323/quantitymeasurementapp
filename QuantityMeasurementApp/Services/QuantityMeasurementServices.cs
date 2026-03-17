using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementService
    {
        public bool AreEqual<TUnit>(Quantity<TUnit> first, Quantity<TUnit> second) where TUnit : struct, System.Enum
        {
            return first.Equals(second);
        }

        public Quantity<TUnit> Convert<TUnit>(Quantity<TUnit> quantity, TUnit targetUnit) where TUnit : struct, System.Enum
        {
            return quantity.ConvertTo(targetUnit);
        }

        public Quantity<TUnit> Add<TUnit>(Quantity<TUnit> first, Quantity<TUnit> second) where TUnit : struct, System.Enum
        {
            return first.Add(second);
        }

        public Quantity<TUnit> Add<TUnit>(Quantity<TUnit> first, Quantity<TUnit> second, TUnit targetUnit) where TUnit : struct, System.Enum
        {
            return first.Add(second, targetUnit);
        }
    }
}