using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuantityMeasurementAppModel;
using QuantityMeasurementAppRepositoryLayer;

namespace QuantityMeasurementAppRepositoryLayer.Repositories
{
    public class QuantityMeasurementDbRepository : IQuantityMeasurementRepository
    {
        private readonly string connectionString;

        public QuantityMeasurementDbRepository()
        {
            connectionString = "Server=localhost,1433;Database=QuantityMeasurementDB;User Id=sa;Password=Sql@123456;TrustServerCertificate=True;";
        }

        public void Save(QuantityMeasurementEntity entity)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string query = @"
                INSERT INTO MeasurementRecords
                (
                    Id,
                    TimeStamp,
                    Operation,
                    Input1Value,
                    Input1Unit,
                    Input2Value,
                    Input2Unit,
                    OutputValue,
                    OutputUnit,
                    SuccessFlag,
                    ErrorMessage
                )
                VALUES
                (
                    @Id,
                    @TimeStamp,
                    @Operation,
                    @Input1Value,
                    @Input1Unit,
                    @Input2Value,
                    @Input2Unit,
                    @OutputValue,
                    @OutputUnit,
                    @SuccessFlag,
                    @ErrorMessage
                )";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", entity.Id ?? Guid.NewGuid().ToString());
            command.Parameters.AddWithValue("@TimeStamp", entity.CreatedAt == default ? DateTime.Now : entity.CreatedAt);
            command.Parameters.AddWithValue("@Operation", entity.OperationType);

            command.Parameters.AddWithValue("@Input1Value", (object?)entity.FirstValue ?? DBNull.Value);
            command.Parameters.AddWithValue("@Input1Unit", (object?)entity.FirstUnit ?? DBNull.Value);

            command.Parameters.AddWithValue("@Input2Value", (object?)entity.SecondValue ?? DBNull.Value);
            command.Parameters.AddWithValue("@Input2Unit", (object?)entity.SecondUnit ?? DBNull.Value);

            command.Parameters.AddWithValue("@OutputValue", (object?)entity.ResultValue ?? DBNull.Value);
            command.Parameters.AddWithValue("@OutputUnit", (object?)entity.ResultUnit ?? DBNull.Value);

            command.Parameters.AddWithValue("@SuccessFlag", entity.IsSuccessful);
            command.Parameters.AddWithValue("@ErrorMessage", (object?)entity.ErrorMessage ?? DBNull.Value);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<QuantityMeasurementEntity> GetAll()
        {
            List<QuantityMeasurementEntity> records = new List<QuantityMeasurementEntity>();

            using SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM MeasurementRecords ORDER BY TimeStamp DESC";

            using SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                QuantityMeasurementEntity entity = new QuantityMeasurementEntity
                {
                    Id = reader["Id"]?.ToString(),
                    CreatedAt = Convert.ToDateTime(reader["TimeStamp"]),
                    OperationType = Convert.ToInt32(reader["Operation"]),
                    FirstValue = reader["Input1Value"] == DBNull.Value ? null : Convert.ToDouble(reader["Input1Value"]),
                    FirstUnit = reader["Input1Unit"] == DBNull.Value ? null : reader["Input1Unit"].ToString(),
                    SecondValue = reader["Input2Value"] == DBNull.Value ? null : Convert.ToDouble(reader["Input2Value"]),
                    SecondUnit = reader["Input2Unit"] == DBNull.Value ? null : reader["Input2Unit"].ToString(),
                    ResultValue = reader["OutputValue"] == DBNull.Value ? null : Convert.ToDouble(reader["OutputValue"]),
                    ResultUnit = reader["OutputUnit"] == DBNull.Value ? null : reader["OutputUnit"].ToString(),
                    IsSuccessful = Convert.ToBoolean(reader["SuccessFlag"]),
                    ErrorMessage = reader["ErrorMessage"] == DBNull.Value ? null : reader["ErrorMessage"].ToString()
                };

                records.Add(entity);
            }

            return records;
        }

        public int GetCount()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT COUNT(*) FROM MeasurementRecords";

            using SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public void DeleteAll()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            string query = "DELETE FROM MeasurementRecords";

            using SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}