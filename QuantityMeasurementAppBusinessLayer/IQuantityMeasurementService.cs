using QuantityMeasurementAppModel;

namespace QuantityMeasurementAppBusinessLayer
{
    public interface IQuantityMeasurementService
    {
        QuantityDTO Add(QuantityDTO firstQuantity, QuantityDTO secondQuantity);
        bool Compare(QuantityDTO firstQuantity, QuantityDTO secondQuantity);
        QuantityDTO Subtract(QuantityDTO firstQuantity, QuantityDTO secondQuantity);
        double Divide(QuantityDTO firstQuantity, QuantityDTO secondQuantity);
    }
}
