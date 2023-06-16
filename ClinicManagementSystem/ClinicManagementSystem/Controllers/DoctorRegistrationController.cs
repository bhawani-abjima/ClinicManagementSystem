using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorRegistrationController : Controller
    {

        private readonly IDoctorRegistrationRepository _doctorRepository;

        public DoctorRegistrationController(IDoctorRegistrationRepository doctorRegistrationRepository)
        {
            _doctorRepository = doctorRegistrationRepository;
            
        }

        [HttpPost]
        public async Task<IActionResult> DoctorRegistration(DoctorModel doctorCredentials)

        {

            if (ModelState.IsValid)
            {
                var newdoctor = await _doctorRepository.DoctorPortalAsync(doctorCredentials);

                if (newdoctor == "RegistrationSuccess")
                {
                  
                    return RedirectToAction("AdminPortal", "Home");
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
