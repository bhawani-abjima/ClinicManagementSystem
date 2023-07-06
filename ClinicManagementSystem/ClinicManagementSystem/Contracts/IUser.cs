using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IUser
    {
        Task <string> AddAsync(UserModel user);
      
    }
}
