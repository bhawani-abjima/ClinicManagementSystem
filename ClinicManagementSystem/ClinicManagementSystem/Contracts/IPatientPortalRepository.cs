using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientPortalRepository
    {
        Task<PatientModel> PatientPortalAsync(string PatientEmail);
       // Task<PatientModel> PatientPortalAsync(PatientPortalModel newpatient);
    }
}