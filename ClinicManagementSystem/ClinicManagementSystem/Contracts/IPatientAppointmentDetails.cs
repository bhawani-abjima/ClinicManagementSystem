using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientAppointmentDetails

    {
        IEnumerable<BookAppointment> PatientAppointmentData(string Email);
        //Task<BookAppointment> PatientAppointmentData();
    }
}
