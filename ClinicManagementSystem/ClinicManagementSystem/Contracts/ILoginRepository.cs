using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface ILoginRepository
    {
        Task<string> LoginAsync(LoginModel loginCredentials);
    }
}
