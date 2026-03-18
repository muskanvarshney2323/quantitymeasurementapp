using System;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Services
{
    public class QuantityMeasurementServices<TUnit> where TUnit : Enum
    {
        public Quantity<TUnit> Add(Quantity<TUnit> first, Quantity<TUnit> second)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Add(second);
        }

        public Quantity<TUnit> Add(Quantity<TUnit> first, Quantity<TUnit> second, TUnit targetUnit)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Add(second, targetUnit);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> first, Quantity<TUnit> second)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Subtract(second);
        }

        public Quantity<TUnit> Subtract(Quantity<TUnit> first, Quantity<TUnit> second, TUnit targetUnit)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Subtract(second, targetUnit);
        }

        public double Divide(Quantity<TUnit> first, Quantity<TUnit> second)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Divide(second);
        }

        public bool AreEqual(Quantity<TUnit> first, Quantity<TUnit> second)
        {
            if (first == null || second == null)
                throw new ArgumentException("Quantities cannot be null");

            return first.Equals(second);
        }
    }
}