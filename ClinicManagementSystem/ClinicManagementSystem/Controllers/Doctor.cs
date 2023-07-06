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
        public async Task<IActionResult> DoctorLoginPortal(string DoctorEmail)
        {
            if (ModelState.IsValid)
            {
                var portalData = await _doctor.DoctorPortalAsync(DoctorEmail);
                return View("~/Views/Doctor/DoctorPortal.cshtml", portalData);
                ////var doctorModel = portalData.FirstOrDefault();
                // if (doctorModel != null)
                // {
                //     return View("~/Views/Home/DoctorPortal.cshtml", doctorModel);
                // }

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
                TempData["AlertMessage"] = "<script>alert('Doctor Details Updated Successfully!')</script>";
                return RedirectToAction("AdminPortal", "Home");
            }

            return RedirectToAction("Maintenance", "Home");
        }
    }
}
