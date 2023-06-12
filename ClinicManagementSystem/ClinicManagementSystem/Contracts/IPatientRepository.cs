using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientRepository
    {
        Task<string> PatientAsync(PatientModel PatientCredentials);
    }
}
