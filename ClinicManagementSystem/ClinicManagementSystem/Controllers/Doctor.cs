using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class Doctor : Controller
    {
        private readonly IDoctor _doctor;
       

        public Doctor(IDoctor doctor)
        {
            _doctor = doctor;
        }

        [HttpPost]
        public async Task<IActionResult> DoctorLoginPortal(string RegistrationNo)
        {
            if (ModelState.IsValid)
            {
                var doctorData = await _doctor.GetDoctorDataAsync(RegistrationNo);
                var appointmentData = await _doctor.GetDoctorAppointmentsAsync(RegistrationNo);

                if (doctorData != null && appointmentData != null)
                {
                    var portalData = new DoctorPortalViewModel
                    {
                        Doctor = doctorData,
                        Appointments = appointmentData
                    };

                    return View("~/Views/Doctor/DoctorPortal.cshtml", portalData);
                }
                else
                {
                    // Handle case when doctor or appointments are not found
                    return View("~/Views/Doctor/DoctorNotFound.cshtml");
                }
            }

            return RedirectToAction("DoctorPortal");
        }


        [HttpPost]
        public async Task<IActionResult> DoctorRegistration(DoctorModel doctorCredentials)

        {

            if (ModelState.IsValid)
            {
                var newdoctor = await _doctor.DoctorRegisAsync(doctorCredentials);

                if (newdoctor == "RegistrationSuccess")
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
        public async Task<IActionResult> DoctorDetailsEditOption(string doctorEmail)
        {
            if (ModelState.IsValid)
            {
                var editPortalData = await _doctor.DoctorEditPortal(doctorEmail);
                return View("~/Views/Doctor/EditDoctorDetails.cshtml", editPortalData);
            }

            return RedirectToAction("AdminPortal");
        }

        [HttpPost]
        public IActionResult DoctorDetailsUpdated(DoctorModel doctorUpdate)
        {
            if (ModelState.IsValid)
            {
                _doctor.UpdateDoctorDetails(doctorUpdate);
                TempData["AlertMessage"] = "Doctor Details Updated Successfully!";
                return RedirectToAction("LoginUser", "Login");
            }

            return RedirectToAction("Maintenance", "Home");
        }
    }
}
