using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IDoctorRegistrationRepository
    {
        public Task<string> DoctorPortalAsync(DoctorModel doctorCredentials);
    }
}
