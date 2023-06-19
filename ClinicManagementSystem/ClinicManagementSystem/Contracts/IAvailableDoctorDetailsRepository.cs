using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IAvailableDoctorDetailsRepository
    {
        Task<List<DoctorModel>> BookAppointmentAsync();

    }
}
