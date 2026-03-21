using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppModel.Requests;

namespace QuantityMeasurementApp.Console.Menu
{
    public class AppMenu
    {
        private readonly QuantityMeasurementController _controller;

        public AppMenu(QuantityMeasurementController controller)
        {
            _controller = controller;
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("===== Quantity Measurement Menu =====");
                System.Console.WriteLine("1. Add Quantity");
                System.Console.WriteLine("2. View All Quantities");
                System.Console.WriteLine("3. Get Quantity By Id");
                System.Console.WriteLine("4. Update Quantity");
                System.Console.WriteLine("5. Delete Quantity");
                System.Console.WriteLine("6. Exit");
                System.Console.Write("Enter your choice: ");

                bool isValidChoice = int.TryParse(System.Console.ReadLine(), out int choice);

                if (!isValidChoice)
                {
                    System.Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddQuantityFlow();
                        break;

                    case 2:
                        _controller.GetAllQuantities();
                        break;

                    case 3:
                        GetQuantityByIdFlow();
                        break;

                    case 4:
                        UpdateQuantityFlow();
                        break;

                    case 5:
                        DeleteQuantityFlow();
                        break;

                    case 6:
                        System.Console.WriteLine("Thank you for using the application!");
                        exit = true;
                        break;

                    default:
                        System.Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            System.Console.WriteLine("\nApplication closed successfully.");
        }

        private void AddQuantityFlow()
        {
            System.Console.Write("Enter unit: ");
            string? unit = System.Console.ReadLine();

            System.Console.Write("Enter value: ");
            bool isValueValid = double.TryParse(System.Console.ReadLine(), out double value);

            if (!isValueValid)
            {
                System.Console.WriteLine("Invalid value.");
                return;
            }

            QuantityRequest request = new QuantityRequest
            {
                UnitType = unit,
                Value = value
            };

            _controller.AddQuantity(request);
        }

        private void GetQuantityByIdFlow()
        {
            System.Console.Write("Enter quantity id: ");
            bool isIdValid = int.TryParse(System.Console.ReadLine(), out int id);

            if (!isIdValid)
            {
                System.Console.WriteLine("Invalid id.");
                return;
            }

            _controller.GetQuantityById(id);
        }

        private void UpdateQuantityFlow()
        {
            System.Console.Write("Enter quantity id: ");
            bool isIdValid = int.TryParse(System.Console.ReadLine(), out int id);

            if (!isIdValid)
            {
                System.Console.WriteLine("Invalid id.");
                return;
            }

            System.Console.Write("Enter unit: ");
            string? unit = System.Console.ReadLine();

            System.Console.Write("Enter value: ");
            bool isValueValid = double.TryParse(System.Console.ReadLine(), out double value);

            if (!isValueValid)
            {
                System.Console.WriteLine("Invalid value.");
                return;
            }

            QuantityDTO quantityDto = new QuantityDTO
            {
                Id = id,
                Unit = unit,
                Value = value
            };

            _controller.UpdateQuantity(quantityDto);
        }

        private void DeleteQuantityFlow()
        {
            System.Console.Write("Enter quantity id: ");
            bool isIdValid = int.TryParse(System.Console.ReadLine(), out int id);

            if (!isIdValid)
            {
                System.Console.WriteLine("Invalid id.");
                return;
            }

            _controller.DeleteQuantity(id);
        }
    }
}