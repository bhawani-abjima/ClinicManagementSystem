using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    public class PatientLoginController : Controller
    {
        private readonly IPatientLoginRepository _patientLoginRepository;

        public PatientLoginController(IPatientLoginRepository patientLoginRepository)
        {
            _patientLoginRepository = patientLoginRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> PatientLoginPortal(PatientLoginModel newpatient)
        {
            if (ModelState.IsValid)
            {
                PatientModel portalData = await _patientLoginRepository.PatientLoginAsync(newpatient.Email);
                return View("~/Views/Home/PatientPortal.cshtml", portalData);
                //if (portalData != null)
                //{
                //    return RedirectToAction("PatientPortal", portalData);
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid email");
                //}
            }
            return RedirectToAction("PatientLoginPortal");
        }

       
    }
}
