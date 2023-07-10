using ClinicManagementSystem.Models;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Contracts
{
    public interface IDoctor
    {
        //Task<DoctorModel> DoctorPortalAsync(string RegistrationNo);
        Task<string> DoctorRegisAsync(DoctorModel doctorCredentials);
        Task<DoctorModel> DoctorEditPortal(string DoctorEmail);
        void UpdateDoctorDetails(DoctorModel doctorUpdate);
        Task<DoctorModel> GetDoctorDataAsync(string RegistrationNo);
        Task<List<Appointment>> GetDoctorAppointmentsAsync(string RegistrationNo);
    }
}
