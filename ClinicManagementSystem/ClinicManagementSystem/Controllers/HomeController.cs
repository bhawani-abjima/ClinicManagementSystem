﻿using ClinicManagementSystem.Contracts;
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
        private readonly ILoginRepository _loginRepository;
        
        public HomeController(ILogger<HomeController> logger, ILoginRepository loginRepository)
        {
            _logger = logger;
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUpUser()
        {
            return View();
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        public IActionResult PatientRegistration()
        {
            return View();
        }
        public IActionResult PatientLoginPortal()
        {
            return View();
        }
           


        public IActionResult DoctorLoginPortal()
        {
            return View();
        }
        public IActionResult DoctorRegistration()
        {
            return View();
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
