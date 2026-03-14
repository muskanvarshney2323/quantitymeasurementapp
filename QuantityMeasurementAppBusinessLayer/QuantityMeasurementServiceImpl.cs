using QuantityMeasurementAppModel;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppBusinessLayer
{
    public class QuantityMeasurementServiceImpl : IQuantityMeasurementService
    {
        private readonly IQuantityMeasurementRepository repository;

        public QuantityMeasurementServiceImpl(IQuantityMeasurementRepository repository)
        {
            this.repository = repository;
        }

        public QuantityDTO Add(QuantityDTO firstQuantity, QuantityDTO secondQuantity)
        {
            double secondValueConverted = ConvertToUnit(secondQuantity, firstQuantity.Unit);

            double result = firstQuantity.Value + secondValueConverted;

            return new QuantityDTO(result, firstQuantity.Unit);
        }

        public bool Compare(QuantityDTO firstQuantity, QuantityDTO secondQuantity)
        {
            double secondValueConverted = ConvertToUnit(secondQuantity, firstQuantity.Unit);

            return firstQuantity.Value == secondValueConverted;
        }

        public QuantityDTO Subtract(QuantityDTO firstQuantity, QuantityDTO secondQuantity)
        {
            double secondValueConverted = ConvertToUnit(secondQuantity, firstQuantity.Unit);

            double result = firstQuantity.Value - secondValueConverted;

            return new QuantityDTO(result, firstQuantity.Unit);
        }

        public double Divide(QuantityDTO firstQuantity, QuantityDTO secondQuantity)
        {
            double secondValueConverted = ConvertToUnit(secondQuantity, firstQuantity.Unit);

            return firstQuantity.Value / secondValueConverted;
        }

        private double ConvertToUnit(QuantityDTO quantity, string targetUnit)
        {
            string from = quantity.Unit.ToUpper();
            string to = targetUnit.ToUpper();

            from = from.Trim().ToUpper();
            to = to.Trim().ToUpper();

            if (from == to)
                return quantity.Value;
            else if (from == "INCH" && to == "FEET")
                return quantity.Value / 12;

            else if (from == "FEET" && to == "INCH")
                return quantity.Value * 12;
            else if (from == "CM" && to == "INCH")
                return quantity.Value / 2.54;

            else if (from == "INCH" && to == "CM")
                return quantity.Value * 2.54;
            else if (from == "FEET" && to == "CM")
                return quantity.Value * 30.48;

            else if (from == "CM" && to == "FEET")
                return quantity.Value / 30.48;
            else if (from == "YARD" && to == "FEET")
                return quantity.Value * 3;

            else if (from == "FEET" && to == "YARD")
                return quantity.Value / 3;
            else if (from == "YARD" && to == "INCH")
                return quantity.Value * 36;

            else if (from == "INCH" && to == "YARD")
                return quantity.Value / 36;
            else if (from == "YARD" && to == "CM")
                return quantity.Value * 91.44;

            else if (from == "CM" && to == "YARD")
                return quantity.Value / 91.44;

            return quantity.Value;
        }
    }
}