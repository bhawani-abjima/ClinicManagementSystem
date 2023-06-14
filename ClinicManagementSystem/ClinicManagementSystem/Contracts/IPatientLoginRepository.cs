using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientLoginRepository
    {
        Task<string> patientLoginAsync(PatientLoginModel patientloginCredentials);
    }
}
