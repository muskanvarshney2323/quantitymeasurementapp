using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppRepositoryLayer.Interfaces;
using QuantityMeasurementAppRepositoryLayer.Repositories;

namespace QuantityMeasurementApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQuantityMeasurementRepository repository = new QuantityMeasurementDatabaseRepository(null);
            IQuantityMeasurementService service = new QuantityMeasurementService(repository);

            QuantityMeasurementController controller = new QuantityMeasurementController(service);
            AppMenu menu = new AppMenu(controller);

            menu.ShowMenu();
        }
    }
}