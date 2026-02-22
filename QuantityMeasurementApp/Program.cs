using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp
{
    // Program class acts as the starting point of the application
    // Responsible for handling console-based user interaction
    class Program
    {
        // Application execution begins from here
        static void Main(string[] args)
        {
            // Print application title and use case info
            Console.WriteLine("=== Quantity Measurement Application ===");
            Console.WriteLine("UC1: Feet Measurement Equality\n");

            // Instantiate service class for measurement operations
            var service = new QuantityMeasurementService();

            // Loop runs continuously until user chooses to exit
            while (true)
            {
                // Ask user to enter the first feet value
                Console.WriteLine("Enter first measurement in feet (or 'exit' to quit):");
                string? input1 = Console.ReadLine();

                // Exit condition check
                if (input1?.ToLower() == "exit")
                    break;

                // Ask user to enter the second feet value
                Console.WriteLine("Enter second measurement in feet:");
                string? input2 = Console.ReadLine();

                // Exit condition check
                if (input2?.ToLower() == "exit")
                    break;

                // Convert string inputs into Feet objects
                Feet? feet1 = service.ParseFeetInput(input1);
                Feet? feet2 = service.ParseFeetInput(input2);

                // Ensure both inputs are valid numbers
                if (feet1 is null || feet2 is null)
                {
                    Console.WriteLine("Invalid input! Please enter valid numeric values.\n");
                    continue; // Restart loop for fresh input
                }

                // Perform equality comparison
                bool areEqual = service.CompareFeetEquality(feet1, feet2);

                // Show comparison outcome
                Console.WriteLine($"\nFirst measurement: {feet1}");
                Console.WriteLine($"Second measurement: {feet2}");
                Console.WriteLine(
                    $"Are they equal? {areEqual} ({(areEqual ? "Equal" : "Not Equal")})\n"
                );
                Console.WriteLine("----------------------------------------\n");
            }

            // Message displayed when application terminates
            Console.WriteLine("Thank you for using Quantity Measurement Application!");
        }
    }
}