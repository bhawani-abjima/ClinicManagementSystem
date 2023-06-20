using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace ClinicManagementSystem.Controllers
{
    public class PatientPortalController : Controller
    {
        private readonly IPatientPortalRepository _patientportalRepository;

        public PatientPortalController(IPatientPortalRepository patientportalRepository)
        {
            _patientportalRepository = patientportalRepository;
        }

        
        [HttpPost]
        public async Task<IActionResult> PatientLoginPortal(PatientPortalModel newpatientdata)
        {
            if (ModelState.IsValid)
            {
                PatientModel portalData = await _patientportalRepository.PatientPortalData(newpatientdata.PatientEmail);
               // BookAppointment appointmentData = await _patientportalRepository.PatientAppointmentPortalAsync(newpatient.PatientEmail);

               return View("~/Views/Home/PatientPortal.cshtml", portalData);
            }

            return RedirectToAction("PatientPortal");
        }



    }
}
