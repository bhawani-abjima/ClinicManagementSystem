using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IDoctor
    {

        Task<DoctorModel> DoctorPortalAsync(string DoctorEmail);

        public Task<string> DoctorRegisAsync(DoctorModel doctorCredentials);
        Task<DoctorModel> DoctorEditPortal(string doctorEmail);
        void UpdateDoctorDetails(DoctorModel doctorUpdate);
 
    }
}
