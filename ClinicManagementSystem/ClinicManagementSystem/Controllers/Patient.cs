using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class Patient : Controller
    {
        private readonly IPatient _patient;
        
        public Patient(IPatient patient)
        {
            _patient = patient;
        }
        [HttpPost]
        public async Task<IActionResult> PatientRegistration(PatientModel patientCredentials)

        {

            if (ModelState.IsValid)
            {
                var newpatient = await _patient.PatientAsync(patientCredentials);

                if (newpatient == "RegistrationSuccess")
                {

                    return RedirectToAction("SignUpUser", "User");
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

        [HttpPost]
        public async Task<IActionResult> PatientLoginPortal(PatientPortalModel newpatientdata)
        {
            if (ModelState.IsValid)
            {
                PatientModel portalData = await _patient.PatientPortalData(newpatientdata.PatientEmail);
                // BookAppointment appointmentData = await _patientportalRepository.PatientAppointmentPortalAsync(newpatient.PatientEmail);

                return View("~/Views/Patient/PatientPortal.cshtml", portalData);
            }

            return RedirectToAction("PatientPortal");
        }
        [HttpGet]
        public async Task<IActionResult> PatientAppointments(string Email)
        {
            try
            {
                var patientappointment = await _patient.PatientAppointmentData(Email);
                return View("~/Views/Patient/PatientAppointmentDetails.cshtml", patientappointment);

            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Patientdetailseditoption(string patientEmail)
        {
            if (ModelState.IsValid)
            {
                var editportaldata = await _patient.PatientEditPortal(patientEmail);
                return View("~/Views/Patient/EditPatientDetails.cshtml", editportaldata);
            }

            return RedirectToAction("AdminPortal");
        }

        [HttpPost]
        public IActionResult PatientdetailsUpdated(PatientModel patientupdate)
        {
            if (ModelState.IsValid)
            {
                _patient.UpdatePatientDetails(patientupdate);
                TempData["AlertMessage"] = "<script>alert('Patient Details Updated Successfull !') </script >";
                return RedirectToAction("LoginUser", "Login");
            }

            return RedirectToAction("Maintenance", "Home");
        }

    }
}
