using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IBookAppointmentRepository
    {
        Task<List<DoctorModel>> BookAppointmentAsync();

    }
}
