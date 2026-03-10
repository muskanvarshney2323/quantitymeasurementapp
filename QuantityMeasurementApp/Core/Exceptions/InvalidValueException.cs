using System;

namespace QuantityMeasurementApp.Core.Exceptions
{
    public class InvalidValueException : ArgumentException
    {
        public InvalidValueException() : base("Invalid numeric value provided.") { }
        public InvalidValueException(string message) : base(message) { }
        public InvalidValueException(string message, Exception inner) : base(message, inner) { }
    }
}
