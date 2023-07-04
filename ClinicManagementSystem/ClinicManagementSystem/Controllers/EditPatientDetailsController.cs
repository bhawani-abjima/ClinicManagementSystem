
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
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
        public IActionResult Patientdetailseditoption(string patientEmail)
        {
            if (ModelState.IsValid)
            {
                var editportaldata = _editPatientDetailsRepository.PatientEditPortal(patientEmail);
                return View("~/Views/Home/EditPatientDetails.cshtml", editportaldata);
            }

            return RedirectToAction("AdminPortal");
        }

        [HttpPost]
        public IActionResult PatientdetailsUpdated(PatientModel patientupdate)
        {
            if (ModelState.IsValid)
            {
                _editPatientDetailsRepository.UpdatePatientDetails(patientupdate);
                TempData["AlertMessage"] = "<script>alert('Patient Details Updated Successfull !') </script >";
                return RedirectToAction("AdminPortal", "Home");
            }

            return RedirectToAction("Maintenance","Home");
        }




    }
}
