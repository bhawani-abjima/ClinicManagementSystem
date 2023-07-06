using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();

        Task<string> AppointmentAsync(BookAppointment appointmentCredentials);

        Task<Appointment> AppointmentEditPortal(int id);
        void UpdateAppointmentDetails(Appointment AppointmentUpdate);


    }
}
