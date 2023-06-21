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
        public IActionResult DoctorLoginPortal(string DoctorEmail)
        {   
            if (ModelState.IsValid)
            {
               var portalData = _doctorportalrepository.DoctorPortalAsync(DoctorEmail);
                return View("~/Views/Home/DoctorPortal.cshtml", portalData);
                ////var doctorModel = portalData.FirstOrDefault();
                // if (doctorModel != null)
                // {
                //     return View("~/Views/Home/DoctorPortal.cshtml", doctorModel);
                // }

            }
            return RedirectToAction("DoctorPortal");
        }
    }
}
