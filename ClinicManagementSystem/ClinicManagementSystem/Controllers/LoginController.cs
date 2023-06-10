using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
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
                            return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception and display an appropriate error message
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
