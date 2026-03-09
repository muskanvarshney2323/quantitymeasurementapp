using System;

namespace QuantityMeasurementApp.Core.Exceptions
{
    public class InvalidUnitException : ArgumentException
    {
        public InvalidUnitException() : base("Invalid unit provided.") { }
        public InvalidUnitException(string message) : base(message) { }
        public InvalidUnitException(string message, Exception inner) : base(message, inner) { }
    }
}
