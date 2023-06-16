using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Linq.Expressions;

namespace ClinicManagementSystem.Controllers
{
    public class PatientRegistrationController : Controller
    {
        
        private readonly IPatientRegistrationRepository _patientRepository;
        public PatientRegistrationController(IPatientRegistrationRepository patientRepository)
        {
            _patientRepository = patientRepository;

        }
     


        [HttpPost]
        public async Task<IActionResult> PatientRegistration(PatientModel patientCredentials)

            {

            if (ModelState.IsValid)
            {
                var newpatient = await _patientRepository.PatientAsync(patientCredentials);
                
                if (newpatient == "RegistrationSuccess")
                {
                   
                    return RedirectToAction("PatientPortal");
                }
                else
                {
                    return RedirectToAction("AdminPortal", "Home");
                }
            }
            else
            {
                // return RedirectToAction("AdminPortal", "Home");
                //return View("PatientRegistration");
                 throw new Exception("Invalid model state.");

            }
                
        }


    }
}
