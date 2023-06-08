using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IUserRepository
    {
        public  Task <Boolean> AddAsync(UserModel user);
    }
}
