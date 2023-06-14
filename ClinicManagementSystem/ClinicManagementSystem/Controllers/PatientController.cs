using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Linq.Expressions;

namespace ClinicManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
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
                   
                    return RedirectToAction("PatientLoginPortal");
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
