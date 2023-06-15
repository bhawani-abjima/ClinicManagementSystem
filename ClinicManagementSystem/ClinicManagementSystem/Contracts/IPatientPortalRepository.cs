using System.Threading.Tasks;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientPortalRepository
    {
        Task<PatientModel> PatientLoginAsync(string email);
    }
}