using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer;
using QuantityMeasurementAppRepositoryLayer;
using QuantityMeasurementAppRepositoryLayer.Repositories;

namespace QuantityMeasurementApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQuantityMeasurementRepository repository = new QuantityMeasurementDbRepository();
            IQuantityMeasurementService service = new QuantityMeasurementService(repository);

            QuantityMeasurementController controller = new QuantityMeasurementController(service);
            AppMenu menu = new AppMenu(controller);

            menu.ShowMenu();
        }
    }
}