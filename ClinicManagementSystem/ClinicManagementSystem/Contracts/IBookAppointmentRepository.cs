using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IBookAppointmentRepository
    {
        Task<string> AppointmentAsync(BookAppointment appointmentCredentials);
    }
}
