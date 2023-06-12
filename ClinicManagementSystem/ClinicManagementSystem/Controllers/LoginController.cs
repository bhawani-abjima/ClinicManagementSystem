using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
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
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                var result = await _loginRepository.LoginAsync(loginCredentials);

                if (result == "Login Sucessful ")
                {
                    string usertype = loginCredentials.L_UserType;
                    if (usertype == "Patient")
                    {

                        return RedirectToAction("PatientPortal", "Home");
                    }
                    else if (usertype == "Doctor")
                    {

                        return RedirectToAction("DoctorPortal", "Home");
                    }
                    else if (usertype == "Admin")
                    {

                        return RedirectToAction("AdminPortal", "Home");
                    }

                }


            }
            return View();

        }
    }
}