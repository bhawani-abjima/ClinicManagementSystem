using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class EditPatientDetailsController : Controller
    {
        private readonly IEditPatientDetailsRepository _editPatientDetailsRepository;

        public EditPatientDetailsController(IEditPatientDetailsRepository editPatientDetailsRepository)
        {

            _editPatientDetailsRepository = editPatientDetailsRepository;
            
        }

      
        [HttpPost]
        public IActionResult Patientdetailseditoption(string PatientEmail)
        {
            if (ModelState.IsValid)
            {
                var editportaldata = _editPatientDetailsRepository.PatientEditPortal(PatientEmail);
                return View("~/Views/Home/DoctorPortal.cshtml", editportaldata);
                ////var doctorModel = portalData.FirstOrDefault();
                // if (doctorModel != null)
                // {
                //     return View("~/Views/Home/DoctorPortal.cshtml", doctorModel);
                // }

            }
            return RedirectToAction("DoctorPortal");
        }

      
    

    }
}
