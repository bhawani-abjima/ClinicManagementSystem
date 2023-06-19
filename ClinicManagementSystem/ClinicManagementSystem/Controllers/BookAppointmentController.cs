using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class BookAppointmentController : Controller
    {
        private readonly IBookAppointmentRepository _bookAppointmentRepository;

        public BookAppointmentController(IBookAppointmentRepository bookAppointmentRepository)
        {
            _bookAppointmentRepository = bookAppointmentRepository;
            
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(BookAppointment AppointmentCredentials)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookAppointmentRepository.AppointmentAsync(AppointmentCredentials);

                if (result == "Appointment Booked Sucessful")
                {
                    return View("~/Views/Home/PatientLoginPortal.cshtml");

                }
            }
            return View("~/Views/Home/AvailableDoctorDetails.cshtml");

        }
    }
}
