using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IEditAppointmentDetailsRepository
    {

        Appointment AppointmentEditPortal(string doctorEmail);
        void UpdateAppointmentDetails(Appointment AppointmentUpdate);
    }
}
