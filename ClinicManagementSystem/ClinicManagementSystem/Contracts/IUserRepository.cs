using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IUserRepository
    {
        public  Task <string> AddAsync(UserModel user);
    }
}
