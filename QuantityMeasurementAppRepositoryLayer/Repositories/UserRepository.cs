using QuantityMeasurementAppModel.Entities;
using QuantityMeasurementAppRepositoryLayer.Interfaces;

namespace QuantityMeasurementAppRepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User? GetUserByEmail(string email)
        {
            return null;
        }

        public User AddUser(User user)
        {
            user.UserId = 1;
            return user;
        }
    }
}