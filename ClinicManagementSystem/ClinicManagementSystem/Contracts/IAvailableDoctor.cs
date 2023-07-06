using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IAvailableDoctor
    {
        Task<List<DoctorModel>> BookAppointmentAsync();

    }
}
