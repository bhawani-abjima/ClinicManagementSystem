using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatient
    {

        public Task<string> PatientAsync(PatientModel PatientCredentials);

        Task<PatientModel> PatientPortalData(string PatientEmail);

        Task<IEnumerable<Appointment>> PatientAppointmentData(string Email);

        Task<PatientModel> PatientEditPortal(string PatientEmail);

        void UpdatePatientDetails(PatientModel patient);
    }

}
