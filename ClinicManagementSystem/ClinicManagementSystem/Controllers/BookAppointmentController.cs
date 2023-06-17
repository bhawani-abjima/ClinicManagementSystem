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
        [HttpGet]
        public async Task<IActionResult> BookAppointmentInput()
        {
            try
            {
                List<DoctorModel> appointmentData = await _bookAppointmentRepository.BookAppointmentAsync();
                return View("~/Views/Home/AvailableDoctorDetails.cshtml", appointmentData);
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                return RedirectToAction("BookAppointment");
            }
        }





    }
}
