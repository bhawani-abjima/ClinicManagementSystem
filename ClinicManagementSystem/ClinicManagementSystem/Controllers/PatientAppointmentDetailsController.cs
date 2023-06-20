using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientAppointmentDetailsController : Controller
    {
        private readonly IPatientAppointmentDetails _patientAppointmentDetails;

        public PatientAppointmentDetailsController(IPatientAppointmentDetails patientAppointmentDetails)
        {
            _patientAppointmentDetails = patientAppointmentDetails;
            
        }

        [HttpGet]
        public  IActionResult PatientAppoinements(string Email)
        {
            try
            {
                var patientappointment = _patientAppointmentDetails.PatientAppointmentData(Email);
                return View("~/Views/Home/PatientAppointmentDetails.cshtml", patientappointment);
                       
            }
            catch (Exception)
            {
                // Handle the exception or log the error
                return RedirectToAction("Index");
            }
        }
    }
}
