using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Quantity Measurement Console =====");
            Console.WriteLine("Feet Equality Checker\n");

            QuantityMeasurementService measurementService = new QuantityMeasurementService();

            while (true)
            {
                Console.Write("Enter first feet value (type exit to stop): ");
                string? firstInput = Console.ReadLine();

                if (firstInput?.Trim().ToLower() == "exit")
                    break;

                Console.Write("Enter second feet value: ");
                string? secondInput = Console.ReadLine();

                if (secondInput?.Trim().ToLower() == "exit")
                    break;

                Feet? firstFeet = measurementService.ParseFeetInput(firstInput);
                Feet? secondFeet = measurementService.ParseFeetInput(secondInput);

                if (firstFeet == null || secondFeet == null)
                {
                    Console.WriteLine("Invalid input detected. Please try again.\n");
                    continue;
                }

                bool result = measurementService.CompareFeetEquality(firstFeet, secondFeet);

                Console.WriteLine("\nResult Summary");
                Console.WriteLine("-------------------------");
                Console.WriteLine($"First Value  : {firstFeet}");
                Console.WriteLine($"Second Value : {secondFeet}");
                Console.WriteLine($"Equality     : {(result ? "Equal" : "Not Equal")}\n");
            }

            Console.WriteLine("Application Closed.");
        }
    }
}