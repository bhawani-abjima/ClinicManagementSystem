using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class AvailableDoctorDetailsController : Controller
    {
        private readonly IAvailableDoctorDetailsRepository _bookAppointmentRepository;


        public AvailableDoctorDetailsController(IAvailableDoctorDetailsRepository bookAppointmentRepository)
        {
            _bookAppointmentRepository = bookAppointmentRepository;
            
        }
        [HttpGet]
        public async Task<IActionResult> AvailableDoctor()
        {
            try
            {
                List<DoctorModel> appointmentData = await _bookAppointmentRepository.BookAppointmentAsync();
                return View("~/Views/Home/AvailableDoctorDetails.cshtml", appointmentData);
            }
            catch (Exception)
            {
                // Handle the exception 
                return RedirectToAction("Index");
            }
        }





    }
}
