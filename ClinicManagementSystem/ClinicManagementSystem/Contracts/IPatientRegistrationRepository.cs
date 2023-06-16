using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientRegistrationRepository
    {
        public Task<string> PatientAsync(PatientModel PatientCredentials);
        
    }
}
