using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using QuantityMeasurementApp.Common;

namespace QuantityMeasurementApp.Models
{
    public class Quantity<U> where U : struct, Enum
    {
        private readonly double _value;
        private readonly U _unit;
        private const double Precision = 0.0001;

        public Quantity(double value, U unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("Invalid value provided.");
            }

            if (!Enum.IsDefined(typeof(U), unit))
            {
                throw new ArgumentException("Invalid unit provided.");
            }

            _value = value;
            _unit = unit;
        }

        public double Value => _value;
        public U Unit => _unit;

        private static double ConvertToBase(U currentUnit, double currentValue)
        {
            MethodInfo method = FindExtensionMethod(typeof(U), "ToBaseUnit");
            object? result = method.Invoke(null, new object[] { currentUnit, currentValue });
            return Convert.ToDouble(result);
        }

        private static double ConvertFromBase(U targetUnit, double baseValue)
        {
            MethodInfo method = FindExtensionMethod(typeof(U), "FromBaseUnit");
            object? result = method.Invoke(null, new object[] { targetUnit, baseValue });
            return Convert.ToDouble(result);
        }

        private static MethodInfo FindExtensionMethod(Type unitType, string methodName)
        {
            Assembly assembly = typeof(Quantity<U>).Assembly;

            MethodInfo? method = assembly
                .GetTypes()
                .Where(type => type.IsSealed && type.IsAbstract)
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Static))
                .FirstOrDefault(methodInfo =>
                {
                    if (methodInfo.Name != methodName)
                    {
                        return false;
                    }

                    if (!methodInfo.IsDefined(typeof(ExtensionAttribute), false))
                    {
                        return false;
                    }

                    ParameterInfo[] parameters = methodInfo.GetParameters();

                    return parameters.Length == 2 &&
                           parameters[0].ParameterType == unitType &&
                           parameters[1].ParameterType == typeof(double);
                });

            if (method == null)
            {
                throw new ArgumentException(
                    $"Conversion method '{methodName}' not found for unit type '{unitType.Name}'.");
            }

            return method;
        }

        private static void ValidateArithmeticSupport(U unit, string operation)
        {
            if (typeof(U) == typeof(TemperatureScale))
            {
                TemperatureScale temperatureUnit = (TemperatureScale)(object)unit;
                temperatureUnit.ValidateOperationSupport(operation);
            }
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (!Enum.IsDefined(typeof(U), targetUnit))
            {
                throw new ArgumentException("Invalid unit provided.");
            }

            double baseValue = ConvertToBase(_unit, _value);
            double convertedValue = ConvertFromBase(targetUnit, baseValue);

            return new Quantity<U>(Math.Round(convertedValue, 5), targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            if (other == null)
            {
                throw new ArgumentException("Operand cannot be null");
            }

            ValidateArithmeticSupport(_unit, "addition");

            double firstBaseValue = ConvertToBase(_unit, _value);
            double secondBaseValue = ConvertToBase(other._unit, other._value);

            double resultBaseValue = firstBaseValue + secondBaseValue;
            double resultValue = ConvertFromBase(_unit, resultBaseValue);

            return new Quantity<U>(Math.Round(resultValue, 2), _unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentException("Operand cannot be null");
            }

            if (!Enum.IsDefined(typeof(U), targetUnit))
            {
                throw new ArgumentException("Invalid unit provided.");
            }

            ValidateArithmeticSupport(_unit, "addition");

            double firstBaseValue = ConvertToBase(_unit, _value);
            double secondBaseValue = ConvertToBase(other._unit, other._value);

            double resultBaseValue = firstBaseValue + secondBaseValue;
            double resultValue = ConvertFromBase(targetUnit, resultBaseValue);

            return new Quantity<U>(Math.Round(resultValue, 2), targetUnit);
        }

        public Quantity<U> Subtract(Quantity<U> other)
        {
            if (other == null)
            {
                throw new ArgumentException("Operand cannot be null");
            }

            ValidateArithmeticSupport(_unit, "subtraction");

            double firstBaseValue = ConvertToBase(_unit, _value);
            double secondBaseValue = ConvertToBase(other._unit, other._value);

            double resultBaseValue = firstBaseValue - secondBaseValue;
            double resultValue = ConvertFromBase(_unit, resultBaseValue);

            return new Quantity<U>(Math.Round(resultValue, 5), _unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
            {
                throw new ArgumentException("Operand cannot be null");
            }

            if (!Enum.IsDefined(typeof(U), targetUnit))
            {
                throw new ArgumentException("Invalid unit provided.");
            }

            ValidateArithmeticSupport(_unit, "subtraction");

            double firstBaseValue = ConvertToBase(_unit, _value);
            double secondBaseValue = ConvertToBase(other._unit, other._value);

            double resultBaseValue = firstBaseValue - secondBaseValue;
            double resultValue = ConvertFromBase(targetUnit, resultBaseValue);

            return new Quantity<U>(Math.Round(resultValue, 2), targetUnit);
        }

        public double Divide(Quantity<U> other)
        {
            if (other == null)
            {
                throw new ArgumentException("Operand cannot be null");
            }

            ValidateArithmeticSupport(_unit, "division");

            double dividend = ConvertToBase(_unit, _value);
            double divisor = ConvertToBase(other._unit, other._value);

            if (Math.Abs(divisor) < Precision)
            {
                throw new ArithmeticException("Cannot divide by zero");
            }

            return Math.Round(dividend / divisor, 5);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Quantity<U>))
            {
                return false;
            }

            Quantity<U> other = (Quantity<U>)obj;

            double firstBaseValue = ConvertToBase(_unit, _value);
            double secondBaseValue = ConvertToBase(other._unit, other._value);

            return Math.Abs(firstBaseValue - secondBaseValue) < Precision;
        }

        public override int GetHashCode()
        {
            double baseValue = ConvertToBase(_unit, _value);
            return Math.Round(baseValue, 4).GetHashCode();
        }
    }
}