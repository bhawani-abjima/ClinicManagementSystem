using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
                _patientRepository = patientRepository;
            
        }


        public async Task<string> PatientPortal(PatientModel patientCredentials)
        {
            if (ModelState.IsValid)
            {
                var newpatient = await _patientRepository.PatientAsync(patientCredentials);
                return newpatient;

            }
            else { throw new Exception("Invalid model state."); }


        }
    }
}
