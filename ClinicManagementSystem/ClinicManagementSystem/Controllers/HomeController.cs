using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ClinicManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogin _loginRepository;
        
        public HomeController(ILogger<HomeController> logger, ILogin loginRepository)
        {
            _logger = logger;
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Maintenance()
        {
            return View();
        }

        public IActionResult LoginUser()
        {
            return View();
        }
        public IActionResult PatientRegistration()
        {
            return View("~/Views/Patient/PatientRegistration.cshtml");
        }
        public IActionResult PatientLoginPortal()
        {
            return View("~/Views/Patient/PatientLoginPortal.cshtml");
        }
        public IActionResult EditPatientDetails()
        {
            return View();
        }


        public IActionResult DoctorLoginPortal()
        {
            return View("~/Views/Doctor/DoctorLoginPortal.cshtml");
        }
        public IActionResult DoctorRegistration()
        {
            return View("~/Views/Doctor/DoctorRegistration.cshtml");
        }

        public IActionResult AdminPortal()
        {
           
            return View();
        }


        //public IActionResult BookAppointmentInput()
        //{
        //    return View();
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
