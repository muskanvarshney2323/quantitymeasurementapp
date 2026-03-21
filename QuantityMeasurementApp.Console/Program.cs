using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer.Interfaces;
using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppRepositoryLayer;
using QuantityMeasurementAppRepositoryLayer.Repositories;

namespace QuantityMeasurementApp.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IQuantityMeasurementRepository repository = new QuantityMeasurementCacheRepository();
            IQuantityMeasurementService service = new QuantityMeasurementServiceImpl(repository);
            QuantityMeasurementController controller = new QuantityMeasurementController(service);

            AppMenu menu = new AppMenu(controller);
            menu.Show();
        }
    }
}