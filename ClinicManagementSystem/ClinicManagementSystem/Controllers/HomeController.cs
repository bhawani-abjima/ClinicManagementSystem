﻿using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
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
        


        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userType = await _loginRepository.LoginAsync(loginCredentials);

                    switch (userType)
                    {
                        case "Patient":
                            return RedirectToAction("PatientPortal", "Patient");
                        case "Doctor":
                            return RedirectToAction("DoctorPortal", "Doctor");
                        case "Admin":
                            return RedirectToAction("AdminPortal", "Admin");
                        default:
                            return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception and display an appropriate error message
                    _logger.LogError(ex, "An error occurred during login.");
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

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
