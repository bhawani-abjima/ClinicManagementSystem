using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorPortalController : Controller
    {
        private readonly IDoctorPortalRepository _doctorportalrepository;
        public DoctorPortalController(IDoctorPortalRepository doctorPortalRepository)
        {
            _doctorportalrepository=doctorPortalRepository;
        }

        [HttpPost]
        public async Task<IActionResult> DoctorLoginPortal(DoctorPortalModel newdoctor)
        {
            if (ModelState.IsValid)
            {
               DoctorModel portalData = await _doctorportalrepository.DoctorPortalAsync(newdoctor.RegistrationNo);
                return View("~/Views/Home/DoctorPortal.cshtml", portalData);
               
            }
            return RedirectToAction("DoctorPortal");
        }
    }
}
