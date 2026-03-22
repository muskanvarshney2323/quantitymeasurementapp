using Microsoft.Extensions.Configuration;
using QuantityMeasurementAppModel.Entities;
using QuantityMeasurementAppRepositoryLayer.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace QuantityMeasurementAppRepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public User? GetUserByEmail(string email)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand("sp_GetUserByEmail", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = reader["Id"].ToString() ?? "",
                    Name = reader["Name"].ToString() ?? "",
                    Email = reader["Email"].ToString() ?? "",
                    PasswordHash = reader["PasswordHash"].ToString() ?? "",
                    IsGoogleUser = Convert.ToBoolean(reader["IsGoogleUser"]),
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                };
            }

            return null;
        }

        public bool RegisterUser(User user)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand("sp_RegisterUser", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@IsGoogleUser", user.IsGoogleUser);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

            connection.Open();

            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}