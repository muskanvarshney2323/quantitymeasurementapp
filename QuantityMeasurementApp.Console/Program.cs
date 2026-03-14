using QuantityMeasurementApp.Console.Controllers;
using QuantityMeasurementApp.Console.Menu;
using QuantityMeasurementAppBusinessLayer;
using QuantityMeasurementAppRepositoryLayer;

IQuantityMeasurementRepository repository = new QuantityMeasurementCacheRepository();
IQuantityMeasurementService service = new QuantityMeasurementServiceImpl(repository);

QuantitiesController controller = new QuantitiesController(service);

MainMenu menu = new MainMenu(controller);
menu.Start();