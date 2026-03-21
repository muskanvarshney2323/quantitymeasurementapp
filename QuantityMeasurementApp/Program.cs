using System;
using QuantityMeasurementApp.Views;

namespace QuantityMeasurementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("=== Quantity Measurement Application ===");
            System.Console.WriteLine("UC13: Centralized Arithmetic Logic to Enforce DRY\n");

            Menu menu = new Menu();
            menu.Show();
        }
    }
}