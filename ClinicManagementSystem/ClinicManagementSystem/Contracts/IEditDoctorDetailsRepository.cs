using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IEditDoctorDetailsRepository
    {
        DoctorModel DoctorEditPortal(string doctorEmail);
        void UpdateDoctorDetails(DoctorModel doctorUpdate);
    }
}
