using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IDoctorPortalRepository
    {
        Task<DoctorModel> DoctorPortalAsync(string RegistrationNo);
    }
}
