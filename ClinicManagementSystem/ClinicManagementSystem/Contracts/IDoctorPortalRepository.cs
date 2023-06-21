using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IDoctorPortalRepository
    {
        DoctorModel DoctorPortalAsync(string DoctorEmail);
    }
}
