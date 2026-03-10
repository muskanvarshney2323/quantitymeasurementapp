using System;
using Models = QuantityMeasurementApp.Models;
using DomainUnits = QuantityMeasurementApp.Domain.Units;
using QuantityMeasurementApp.Core.Exceptions;

namespace QuantityMeasurementApp.Domain.Quantities
{
    public class Quantity
    {
        private readonly Models.Quantity _inner;

        public Quantity(double value, DomainUnits.LengthUnit unit)
        {
            // Validate value and unit at the domain boundary so domain tests receive domain-specific exceptions
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new InvalidValueException($"Value must be a valid finite number. Received: {value}");

            if (!Enum.IsDefined(typeof(Models.LengthUnit), (Models.LengthUnit)unit))
                throw new InvalidUnitException($"Unsupported unit: {unit}");

            _inner = new Models.Quantity(value, (Models.LengthUnit)unit);
        }

        internal Quantity(Models.Quantity inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public double Value => _inner.Value;

        public DomainUnits.LengthUnit Unit => (DomainUnits.LengthUnit)_inner.Unit;

        public Quantity ConvertTo(DomainUnits.LengthUnit targetUnit)
        {
            try
            {
                var converted = _inner.ConvertTo((Models.LengthUnit)targetUnit);
                return new Quantity(converted);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message?.Contains("Unsupported unit") == true)
                    throw new InvalidUnitException(ex.Message, ex);
                throw;
            }
        }

        public double ConvertToDouble(DomainUnits.LengthUnit targetUnit)
        {
            try
            {
                return _inner.ConvertTo((Models.LengthUnit)targetUnit).Value;
            }
            catch (ArgumentException ex)
            {
                if (ex.Message?.Contains("Unsupported unit") == true)
                    throw new InvalidUnitException(ex.Message, ex);
                throw;
            }
        }

        public static double Convert(double value, DomainUnits.LengthUnit sourceUnit, DomainUnits.LengthUnit targetUnit)
        {
            return Models.Quantity.Convert(value, (Models.LengthUnit)sourceUnit, (Models.LengthUnit)targetUnit);
        }

        public Quantity Add(Quantity other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            try
            {
                var resultInner = _inner.Add(other._inner);
                return new Quantity(resultInner);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message?.Contains("Unsupported unit") == true)
                    throw new InvalidUnitException(ex.Message, ex);
                throw;
            }
        }

        public Quantity Add(Quantity other, DomainUnits.LengthUnit resultUnit)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            try
            {
                var resultInner = _inner.Add(other._inner, (Models.LengthUnit)resultUnit);
                return new Quantity(resultInner);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message?.Contains("Unsupported unit") == true)
                    throw new InvalidUnitException(ex.Message, ex);
                throw;
            }
        }

        public static Quantity Add(Quantity first, Quantity second, DomainUnits.LengthUnit resultUnit)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            try
            {
                var inner = Models.Quantity.Add(first._inner, second._inner, (Models.LengthUnit)resultUnit);
                return new Quantity(inner);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message?.Contains("Unsupported unit") == true)
                    throw new InvalidUnitException(ex.Message, ex);
                throw;
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not Quantity other) return false;
            return _inner.Equals(other._inner);
        }

        public override int GetHashCode() => _inner.GetHashCode();

        public override string ToString() => _inner.ToString();
    }
}
