using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Controllers
{
    public class EditAppointmentDetailsController : Controller
    {
        private readonly IEditAppointmentDetailsRepository _editAppointmentDetailsRepository;

        public EditAppointmentDetailsController(IEditAppointmentDetailsRepository editAppointmentDetailsRepository)
        {
            _editAppointmentDetailsRepository = editAppointmentDetailsRepository;
        }
        [HttpPost]
        public IActionResult AppointmentDetailsEditOption(string id)
        {
            if (ModelState.IsValid)
            {
                var editPortalData = _editAppointmentDetailsRepository.AppointmentEditPortal(id);
                return View("~/Views/Home/EditAppointmentDetails.cshtml", editPortalData);
            }

            return RedirectToAction("AdminPortal");
        }
        [HttpPost]
        public IActionResult AppointmentDetailsUpdated(Appointment Update)
        {
            if (ModelState.IsValid)
            {
                _editAppointmentDetailsRepository.UpdateAppointmentDetails(Update);
                TempData["AlertMessage"] = "<script>alert('Appointment Details Updated Successfully!')</script>";
                return RedirectToAction("AdminPortal", "Home");
            }

            return RedirectToAction("Maintenance", "Home");
        }

    }
}
