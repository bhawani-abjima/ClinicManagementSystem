using System.Threading.Tasks;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IPatientLoginRepository
    {
        Task<PatientModel> PatientLoginAsync(string email);
    }
}