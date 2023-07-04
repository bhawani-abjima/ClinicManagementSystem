using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class EditDoctorDetailsController : Controller
    {
        private readonly IEditDoctorDetailsRepository _editDoctorDetailsRepository;

        public EditDoctorDetailsController(IEditDoctorDetailsRepository editDoctorDetailsRepository)
        {
            _editDoctorDetailsRepository = editDoctorDetailsRepository;
        }

        [HttpPost]
        public IActionResult DoctorDetailsEditOption(string doctorEmail)
        {
            if (ModelState.IsValid)
            {
                var editPortalData = _editDoctorDetailsRepository.DoctorEditPortal(doctorEmail);
                return View("~/Views/Home/EditDoctorDetails.cshtml", editPortalData);
            }

            return RedirectToAction("AdminPortal");
        }

        [HttpPost]
        public IActionResult DoctorDetailsUpdated(DoctorModel doctorUpdate)
        {
            if (ModelState.IsValid)
            {
                _editDoctorDetailsRepository.UpdateDoctorDetails(doctorUpdate);
                TempData["AlertMessage"] = "<script>alert('Doctor Details Updated Successfully!')</script>";
                return RedirectToAction("AdminPortal", "Home");
            }

            return RedirectToAction("Maintenance", "Home");
        }
    }
}
