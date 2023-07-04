using System;
using System.Threading.Tasks;
using ClinicManagementSystem.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        //public IEnumerable<IActionResult> GetAllAppointments()
        //{
        //    try
        //    {
        //        var appointments =_appointmentRepository.GetAllAppointments();
        //        return View("AppointmentDetails", appointments);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any exceptions or errors
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        public IActionResult GetAllAppointments()
        {
            var result = _appointmentRepository.GetAllAppointments();
            return View(result);
        }

    }
}
