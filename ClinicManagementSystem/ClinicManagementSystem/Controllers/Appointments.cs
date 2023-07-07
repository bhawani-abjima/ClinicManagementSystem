using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class Appointments : Controller
    {
        private readonly IAppointment _appointment;
       

        public Appointments(IAppointment appointment)
        {
            _appointment = appointment;

        }

        public async Task<IActionResult> GetAllAppointments()
        {
            var result = await _appointment.GetAllAppointments();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> BookAppointmentInput(BookAppointment AppointmentCredentials)
        {
            if (ModelState.IsValid)
            {
                var result = await _appointment.AppointmentAsync(AppointmentCredentials);

                if (result == "Appointment Booked Sucessful")
                {
                   
                    return View("~/Views/Patient/PatientLoginPortal.cshtml");

                }
            }
            return View("~/Views/AvailableDoctor/AvailableDoctorDetails.cshtml");

        }
        [HttpGet]
        public async Task<IActionResult> AppointmentDetailsEditOption(int id)
        {
            if (ModelState.IsValid)
            {
                var editPortalData = await _appointment.AppointmentEditPortal(id);
                return View("~/Views/EditAppointmentDetails/AppointmentDetailsEditOption.cshtml", editPortalData);
            }

            return RedirectToAction("AdminPortal");
        }
        [HttpPost]
        public IActionResult AppointmentDetailsUpdated(Appointment Update)
        {
            if (ModelState.IsValid)
            {
                _appointment.UpdateAppointmentDetails(Update);
                TempData["AlertMessage"] = "<script>alert('Appointment Details Updated Successfully!')</script>";
                return RedirectToAction("AdminPortal", "Home");
            }

            return RedirectToAction("Maintenance", "Home");
        }
    }
}
