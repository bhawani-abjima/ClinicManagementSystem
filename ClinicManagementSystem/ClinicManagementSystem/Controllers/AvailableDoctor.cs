using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class AvailableDoctor : Controller
    {
        private readonly IAvailableDoctor _bookAppointmentRepository;


        public AvailableDoctor(IAvailableDoctor bookAppointmentRepository)
        {
            _bookAppointmentRepository = bookAppointmentRepository;
            
        }
        [HttpGet]
        public async Task<IActionResult> AvailableDoctorList()
        {
            try
            {
                List<DoctorModel> appointmentData = await _bookAppointmentRepository.BookAppointmentAsync();
                return View("~/Views/AvailableDoctor/AvailableDoctorDetails.cshtml", appointmentData);
            }
            catch (Exception)
            {
                // Handle the exception 
                return RedirectToAction("Index");
            }
        }





    }
}
