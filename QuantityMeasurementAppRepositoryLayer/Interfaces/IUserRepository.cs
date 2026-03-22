using QuantityMeasurementAppModel.Entities;

namespace QuantityMeasurementAppRepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        bool RegisterUser(User user);
    }
}