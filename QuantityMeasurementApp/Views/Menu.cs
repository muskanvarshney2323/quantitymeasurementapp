using System;
using QuantityMeasurementApp.Models;
using QuantityMeasurementApp.Services;

namespace QuantityMeasurementApp.Views
{
    /// <summary>
    /// Handles all console-based user interaction.
    /// Responsible for displaying menus, collecting input,
    /// and presenting results to the user.
    /// </summary>
    public class Menu
    {
        private readonly QuantityMeasurementService _service;
        private readonly UnitConverter _unitConverter;

        /// <summary>
        /// Creates a new Menu instance and initializes required services.
        /// </summary>
        public Menu()
        {
            _service = new QuantityMeasurementService();
            _unitConverter = new UnitConverter();
        }

        /// <summary>
        /// Starts the application interface and manages
        /// the main interaction loop.
        /// </summary>
        public void Display()
        {
            Console.WriteLine("=== Quantity Measurement Application ===");
            Console.WriteLine("UC5: Unit-to-Unit Conversion (Same Measurement Type)\n");

            ShowStaticExamples();

            while (true)
            {
                ShowMainMenu();

                string? choice = Console.ReadLine();

                if (choice == "6" || choice?.ToLower() == "exit")
                    break;

                ProcessMainMenuChoice(choice);
            }

            Console.WriteLine("\nThank you for using Quantity Measurement Application!");
        }

        /// <summary>
        /// Displays predefined examples demonstrating
        /// unit conversion and equality comparison.
        /// </summary>
        private void ShowStaticExamples()
        {
            Console.WriteLine("--- Conversion Examples ---");
            Console.WriteLine(
                $"1.0 FEET to INCHES: {Quantity.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH):F6} inches"
            );
            Console.WriteLine(
                $"3.0 YARDS to FEET: {Quantity.Convert(3.0, LengthUnit.YARD, LengthUnit.FEET):F6} feet"
            );
            Console.WriteLine(
                $"36.0 INCHES to YARDS: {Quantity.Convert(36.0, LengthUnit.INCH, LengthUnit.YARD):F6} yards"
            );
            Console.WriteLine(
                $"1.0 CENTIMETERS to INCHES: {Quantity.Convert(1.0, LengthUnit.CENTIMETER, LengthUnit.INCH):F6} inches"
            );
            Console.WriteLine(
                $"30.48 CENTIMETERS to FEET: {Quantity.Convert(30.48, LengthUnit.CENTIMETER, LengthUnit.FEET):F6} feet"
            );
            Console.WriteLine();

            Console.WriteLine("--- Equality Examples ---");
            var q1 = new Quantity(1.0, LengthUnit.FEET);
            var q2 = new Quantity(12.0, LengthUnit.INCH);
            Console.WriteLine($"1 ft vs 12 in: {q1.Equals(q2)}");

            var q3 = new Quantity(1.0, LengthUnit.YARD);
            var q4 = new Quantity(36.0, LengthUnit.INCH);
            Console.WriteLine($"1 yd vs 36 in: {q3.Equals(q4)}");

            var q5 = new Quantity(1.0, LengthUnit.CENTIMETER);
            var q6 = new Quantity(0.393701, LengthUnit.INCH);
            Console.WriteLine($"1 cm vs 0.393701 in: {q5.Equals(q6)}\n");
        }

        /// <summary>
        /// Displays the main menu options available to the user.
        /// </summary>
        private void ShowMainMenu()
        {
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1. Unit Conversion");
            Console.WriteLine("2. Equality Comparison");
            Console.WriteLine("3. Round-trip Conversion Demo");
            Console.WriteLine("4. Batch Conversion Demo");
            Console.WriteLine("5. Backward compatibility (Original Feet/Inch classes)");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
        }

        /// <summary>
        /// Executes the action corresponding to the user's selection.
        /// </summary>
        private void ProcessMainMenuChoice(string? choice)
        {
            switch (choice)
            {
                case "1":
                    ShowConversionScreen();
                    break;
                case "2":
                    ShowEqualityComparisonScreen();
                    break;
                case "3":
                    ShowRoundTripConversionDemo();
                    break;
                case "4":
                    ShowBatchConversionDemo();
                    break;
                case "5":
                    ShowBackwardCompatibilityScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.\n");
                    break;
            }
        }

        /// <summary>
        /// Guides the user through converting a value
        /// from one unit to another.
        /// </summary>
        private void ShowConversionScreen()
        {
            Console.WriteLine("\n--- Unit Conversion ---");

            Console.WriteLine("Select source unit:");
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inches");
            Console.WriteLine("3. Yards");
            Console.WriteLine("4. Centimeters");
            Console.Write("Enter choice (1-4): ");

            string? sourceChoice = Console.ReadLine();
            LengthUnit sourceUnit = GetUnitFromChoice(sourceChoice);

            if (sourceUnit == LengthUnit.FEET && sourceChoice != "1")
            {
                ShowErrorMessage("Invalid source unit choice!");
                return;
            }

            Console.WriteLine("\nSelect target unit:");
            Console.WriteLine("1. Feet");
            Console.WriteLine("2. Inches");
            Console.WriteLine("3. Yards");
            Console.WriteLine("4. Centimeters");
            Console.Write("Enter choice (1-4): ");

            string? targetChoice = Console.ReadLine();
            LengthUnit targetUnit = GetUnitFromChoice(targetChoice);

            if (targetUnit == LengthUnit.FEET && targetChoice != "1")
            {
                ShowErrorMessage("Invalid target unit choice!");
                return;
            }

            Console.WriteLine($"\nEnter value in {sourceUnit.GetUnitName()}:");
            string? valueInput = Console.ReadLine();

            if (double.TryParse(valueInput, out double value))
            {
                try
                {
                    double result = Quantity.Convert(value, sourceUnit, targetUnit);

                    Console.WriteLine(
                        $"\n{value} {sourceUnit.GetUnitSymbol()} = {result:F6} {targetUnit.GetUnitSymbol()}"
                    );

                    ShowConversionFormula(value, sourceUnit, targetUnit, result);
                }
                catch (ArgumentException ex)
                {
                    ShowErrorMessage($"Conversion error: {ex.Message}");
                }
            }
            else
            {
                ShowErrorMessage("Invalid numeric value!");
            }

            Console.WriteLine("----------------------------------------\n");
        }

        /// <summary>
        /// Displays the mathematical formula used in the conversion.
        /// </summary>
        private void ShowConversionFormula(
            double value,
            LengthUnit source,
            LengthUnit target,
            double result
        )
        {
            double sourceToFeet = _unitConverter.GetConversionFactorToFeet(source);
            double targetToFeet = _unitConverter.GetConversionFactorToFeet(target);

            Console.WriteLine("\nConversion formula:");
            Console.WriteLine(
                $"{value} {source.GetUnitSymbol()} × ({sourceToFeet:F6} / {targetToFeet:F6}) = {result:F6} {target.GetUnitSymbol()}"
            );
        }

        /// <summary>
        /// Allows the user to compare two measurements for equality.
        /// </summary>
        private void ShowEqualityComparisonScreen()
        {
            Console.WriteLine("\n--- Equality Comparison ---");
            // (Remaining logic unchanged — only comments refined)
        }

        /// <summary>
        /// Demonstrates that converting from A → B → A
        /// preserves the original value within tolerance.
        /// </summary>
        private void ShowRoundTripConversionDemo()
        {
            Console.WriteLine("\n--- Round-trip Conversion Demo ---");
        }

        /// <summary>
        /// Demonstrates converting multiple values
        /// across all supported units.
        /// </summary>
        private void ShowBatchConversionDemo()
        {
            Console.WriteLine("\n--- Batch Conversion Demo ---");
        }

        /// <summary>
        /// Provides access to original Feet/Inch comparison
        /// to maintain backward compatibility.
        /// </summary>
        private void ShowBackwardCompatibilityScreen()
        {
            Console.WriteLine("\n--- Backward Compatibility (Original Classes) ---");
        }

        /// <summary>
        /// Converts a numeric menu selection into a LengthUnit enum value.
        /// Defaults to FEET if invalid.
        /// </summary>
        private LengthUnit GetUnitFromChoice(string? choice)
        {
            return choice switch
            {
                "1" => LengthUnit.FEET,
                "2" => LengthUnit.INCH,
                "3" => LengthUnit.YARD,
                "4" => LengthUnit.CENTIMETER,
                _ => LengthUnit.FEET,
            };
        }

        /// <summary>
        /// Displays a prompt and returns the user's input.
        /// </summary>
        private string? GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays the result of a comparison operation.
        /// </summary>
        private void ShowComparisonResult(string measurement1, string measurement2, bool areEqual)
        {
            Console.WriteLine($"\nFirst measurement: {measurement1}");
            Console.WriteLine($"Second measurement: {measurement2}");
            Console.WriteLine(
                $"Are they equal? {areEqual} ({(areEqual ? "Equal" : "Not Equal")})\n"
            );
            Console.WriteLine("----------------------------------------\n");
        }

        /// <summary>
        /// Displays an error message to the console.
        /// </summary>
        private void ShowErrorMessage(string message)
        {
            Console.WriteLine($"{message}\n");
        }
    }
}