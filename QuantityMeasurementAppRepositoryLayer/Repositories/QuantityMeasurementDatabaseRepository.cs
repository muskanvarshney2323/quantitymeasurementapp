using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModel.DTOs;
using QuantityMeasurementAppRepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace QuantityMeasurementAppRepositoryLayer.Repositories
{
    public class QuantityMeasurementDatabaseRepository : IQuantityMeasurementRepository
    {
        private readonly string _connectionString;

        public QuantityMeasurementDatabaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new Exception("DefaultConnection not found in appsettings.json");
        }

        public bool Compare(QuantityMeasurementAppModel.DTOs.CompareRequestDto request)
        {
           
            return false;
        }

        public double Add(QuantityMeasurementAppModel.DTOs.AddRequestDto request)
        {
            
            return 0;
        }

        public double Convert(QuantityMeasurementAppModel.DTOs.ConvertRequestDto request)
        {

            return 0;
        }

        public List<string> GetHistory()
        {
            List<string> history = new List<string>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT OutputText FROM MeasurementRecords ORDER BY Timestamp DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                history.Add(reader["OutputText"]?.ToString() ?? string.Empty);
            }

            return history;
        }

        public int GetCount()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            string query = "SELECT COUNT(*) FROM MeasurementRecords";

            using SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            return System.Convert.ToInt32(command.ExecuteScalar());
        }
        public double Subtract(AddRequestDto request)
        {
            return request.Value1 - request.Value2;
        }

        public double Divide(CompareRequestDto request)
        {
            if (request.Value2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return request.Value1 / request.Value2;
        }
    }
}