using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientPortalRepository
    {
       
        Task<BookAppointment>PatientAppointmentPortalAsync(string PatientEmail);
        Task<PatientModel> PatientPortalAsync(string PatientEmail);
      
    }
}