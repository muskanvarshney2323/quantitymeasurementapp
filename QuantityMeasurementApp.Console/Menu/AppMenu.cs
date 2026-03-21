using System;
using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementAppModel.DTOs;

namespace QuantityMeasurementApp.Console.Menu
{
    public class AppMenu
    {
        private readonly QuantityMeasurementController _controller;

        public AppMenu(QuantityMeasurementController controller)
        {
            _controller = controller;
        }

        public void ShowMenu()
        {
            while (true)
            {
                System.Console.WriteLine("\n=== Quantity Measurement Menu ===");
                System.Console.WriteLine("1. Add");
                System.Console.WriteLine("2. Subtract");
                System.Console.WriteLine("3. Divide");
                System.Console.WriteLine("4. Convert");
                System.Console.WriteLine("5. Compare");
                System.Console.WriteLine("6. Exit");
                System.Console.Write("Enter your choice: ");

                if (!int.TryParse(System.Console.ReadLine(), out int operationChoice))
                {
                    System.Console.WriteLine("Invalid input.");
                    continue;
                }

                if (operationChoice == 6)
                {
                    System.Console.WriteLine("Exiting application...");
                    break;
                }

                try
                {
                    switch (operationChoice)
                    {
                        case 1:
                            HandleAdd();
                            break;
                        case 2:
                            HandleSubtract();
                            break;
                        case 3:
                            HandleDivide();
                            break;
                        case 4:
                            HandleConvert();
                            break;
                        case 5:
                            HandleCompare();
                            break;
                        default:
                            System.Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void HandleAdd()
        {
            System.Console.WriteLine("\n--- Add Operation ---");
            QuantityDTO q1 = ReadQuantity("first");
            QuantityDTO q2 = ReadQuantity("second");

            QuantityDTO result = _controller.Add(q1, q2);
            System.Console.WriteLine($"Result: {result.Value} {result.Unit}");
        }

        private void HandleSubtract()
        {
            System.Console.WriteLine("\n--- Subtract Operation ---");
            QuantityDTO q1 = ReadQuantity("first");
            QuantityDTO q2 = ReadQuantity("second");

            QuantityDTO result = _controller.Subtract(q1, q2);
            System.Console.WriteLine($"Result: {result.Value} {result.Unit}");
        }

        private void HandleDivide()
        {
            System.Console.WriteLine("\n--- Divide Operation ---");
            QuantityDTO q1 = ReadQuantity("first");
            QuantityDTO q2 = ReadQuantity("second");

            double result = _controller.Divide(q1, q2);
            System.Console.WriteLine($"Result: {result}");
        }

        private void HandleConvert()
        {
            System.Console.WriteLine("\n--- Convert Operation ---");
            QuantityDTO source = ReadQuantity("source");

            System.Console.Write("Enter target unit: ");
            string targetUnit = System.Console.ReadLine() ?? "";

            QuantityDTO result = _controller.Convert(source, targetUnit);
            System.Console.WriteLine($"Converted Result: {result.Value} {result.Unit}");
        }

        private void HandleCompare()
        {
            System.Console.WriteLine("\n--- Compare Operation ---");
            QuantityDTO q1 = ReadQuantity("first");
            QuantityDTO q2 = ReadQuantity("second");

            bool isEqual = _controller.Compare(q1, q2);
            System.Console.WriteLine($"Are both quantities equal? {isEqual}");
        }

        private QuantityDTO ReadQuantity(string label)
        {
            System.Console.WriteLine($"\nSelect {label} measurement type:");
            System.Console.WriteLine("1. Length");
            System.Console.WriteLine("2. Weight");
            System.Console.WriteLine("3. Volume");
            System.Console.WriteLine("4. Temperature");
            System.Console.Write("Enter choice: ");

            int typeChoice = int.Parse(System.Console.ReadLine()!);

            System.Console.Write($"Enter {label} value: ");
            double value = double.Parse(System.Console.ReadLine()!);

            string unit = GetUnit(typeChoice, label);

            return new QuantityDTO
            {
                Value = value,
                Unit = unit
            };
        }

        private string GetUnit(int typeChoice, string label)
        {
            switch (typeChoice)
            {
                case 1:
                    System.Console.WriteLine($"\nSelect {label} Length Unit:");
                    System.Console.WriteLine("1. FEET");
                    System.Console.WriteLine("2. INCH");
                    System.Console.WriteLine("3. YARD");
                    System.Console.WriteLine("4. CENTIMETER");
                    System.Console.Write("Enter choice: ");
                    return System.Console.ReadLine() switch
                    {
                        "1" => "FEET",
                        "2" => "INCH",
                        "3" => "YARD",
                        "4" => "CENTIMETER",
                        _ => throw new Exception("Invalid length unit")
                    };

                case 2:
                    System.Console.WriteLine($"\nSelect {label} Weight Unit:");
                    System.Console.WriteLine("1. KILOGRAM");
                    System.Console.WriteLine("2. GRAM");
                    System.Console.WriteLine("3. TONNE");
                    System.Console.Write("Enter choice: ");
                    return System.Console.ReadLine() switch
                    {
                        "1" => "KILOGRAM",
                        "2" => "GRAM",
                        "3" => "TONNE",
                        _ => throw new Exception("Invalid weight unit")
                    };

                case 3:
                    System.Console.WriteLine($"\nSelect {label} Volume Unit:");
                    System.Console.WriteLine("1. LITRE");
                    System.Console.WriteLine("2. MILLILITRE");
                    System.Console.WriteLine("3. GALLON");
                    System.Console.Write("Enter choice: ");
                    return System.Console.ReadLine() switch
                    {
                        "1" => "LITRE",
                        "2" => "MILLILITRE",
                        "3" => "GALLON",
                        _ => throw new Exception("Invalid volume unit")
                    };

                case 4:
                    System.Console.WriteLine($"\nSelect {label} Temperature Unit:");
                    System.Console.WriteLine("1. CELSIUS");
                    System.Console.WriteLine("2. FAHRENHEIT");
                    System.Console.WriteLine("3. KELVIN");
                    System.Console.Write("Enter choice: ");
                    return System.Console.ReadLine() switch
                    {
                        "1" => "CELSIUS",
                        "2" => "FAHRENHEIT",
                        "3" => "KELVIN",
                        _ => throw new Exception("Invalid temperature unit")
                    };

                default:
                    throw new Exception("Invalid measurement type");
            }
        }
    }
}