using QuantityMeasurementApp.Enums;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementServices
    {
        public Quantity<TUnit> Add<TUnit>(double firstValue, TUnit firstUnit, double secondValue, TUnit secondUnit)
            where TUnit : struct, System.Enum
        {
            var first = new Quantity<TUnit>(firstValue, firstUnit);
            var second = new Quantity<TUnit>(secondValue, secondUnit);
            return first.Add(second);
        }

        public Quantity<TUnit> Add<TUnit>(double firstValue, TUnit firstUnit, double secondValue, TUnit secondUnit, TUnit targetUnit)
            where TUnit : struct, System.Enum
        {
            var first = new Quantity<TUnit>(firstValue, firstUnit);
            var second = new Quantity<TUnit>(secondValue, secondUnit);
            return first.Add(second, targetUnit);
        }

        public Quantity<TUnit> Subtract<TUnit>(double firstValue, TUnit firstUnit, double secondValue, TUnit secondUnit)
            where TUnit : struct, System.Enum
        {
            var first = new Quantity<TUnit>(firstValue, firstUnit);
            var second = new Quantity<TUnit>(secondValue, secondUnit);
            return first.Subtract(second);
        }

        public Quantity<TUnit> Subtract<TUnit>(double firstValue, TUnit firstUnit, double secondValue, TUnit secondUnit, TUnit targetUnit)
            where TUnit : struct, System.Enum
        {
            var first = new Quantity<TUnit>(firstValue, firstUnit);
            var second = new Quantity<TUnit>(secondValue, secondUnit);
            return first.Subtract(second, targetUnit);
        }

        public double Divide<TUnit>(double firstValue, TUnit firstUnit, double secondValue, TUnit secondUnit)
            where TUnit : struct, System.Enum
        {
            var first = new Quantity<TUnit>(firstValue, firstUnit);
            var second = new Quantity<TUnit>(secondValue, secondUnit);
            return first.Divide(second);
        }
    }
}