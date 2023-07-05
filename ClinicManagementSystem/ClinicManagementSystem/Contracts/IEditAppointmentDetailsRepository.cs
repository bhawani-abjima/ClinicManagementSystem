using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IEditAppointmentDetailsRepository
    {

        Appointment AppointmentEditPortal(int id);
        void UpdateAppointmentDetails(Appointment AppointmentUpdate);
    }
}
