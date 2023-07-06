using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface ILogin
    {
        Task<string> LoginAsync(LoginModel loginCredentials);
    }
}
