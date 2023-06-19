using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> PatientLoginPortal(PatientPortalModel newpatient)
        {
            if (ModelState.IsValid)
            {
                PatientModel portalData = await _patientportalRepository.PatientPortalAsync(newpatient.PatientEmail);
                List<BookAppointment> appointmentData = await _patientportalRepository.PatientAppointmentPortalAsync(newpatient);

                PatientPortalViewModel viewModel = new PatientPortalViewModel
                {
                    PortalData = portalData,
                    AppointmentData = appointmentData
                };

                return View("~/Views/Home/PatientPortal.cshtml", viewModel);
            }

            return RedirectToAction("PatientPortal");
        }



    }
}
