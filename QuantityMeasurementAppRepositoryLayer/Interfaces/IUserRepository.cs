using QuantityMeasurementAppModel.Entities;

namespace QuantityMeasurementAppRepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        User AddUser(User user);
    }
}