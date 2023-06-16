using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IBookAppointmentRepository
    {
        List<DoctorModel> SelectedDate(DateTime selectedDateTime);
    }

}