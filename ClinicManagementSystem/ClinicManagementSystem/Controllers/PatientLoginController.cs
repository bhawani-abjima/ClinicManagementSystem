using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientLoginController : Controller
    {
        private readonly IPatientLoginRepository _patientLoginRepository;
        public PatientLoginController(IPatientLoginRepository patientLoginRepository)
        {
            _patientLoginRepository = patientLoginRepository;
            
        }

        public async Task<string> PatientLoginPortal(PatientLoginModel newpatient)
        {
            if(ModelState.IsValid)
            {
                var portaldata = await _patientLoginRepository.patientLoginAsync(newpatient);
                
                if(portaldata == "PatientLoginSuccess") 
                {
                    return "Patient portal under maintence";
                }
                else
                {
                    return "loading....error....";
                }
            }
            else
            { throw new Exception("Invalid model state."); 
            }
        }

    }
}
