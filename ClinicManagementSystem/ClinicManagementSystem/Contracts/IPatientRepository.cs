using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientRepository
    {
        public Task<string> PatientAsync(PatientModel PatientCredentials);
        
    }
}
