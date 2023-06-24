using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IEditPatientDetailsRepository
    {

        PatientModel PatientEditPortal(string PatientEmail);
    }
}
