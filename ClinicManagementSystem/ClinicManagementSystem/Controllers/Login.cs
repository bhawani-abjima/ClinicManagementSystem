using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Controllers
{
    public class Login : Controller
    {
        private readonly ILogin _loginRepository;

        public Login(ILogin loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult LoginUser()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel loginCredentials)
        {
            if (ModelState.IsValid)
            {
                var result = await _loginRepository.LoginAsync(loginCredentials);

                if (result == "Login Sucessful ")
                {
                    string usertype = loginCredentials.UserType;
                    if (usertype == "Patient")
                    {
                        TempData["SuccessMessage"] = "Login Successful";
                        return RedirectToAction("PatientLoginPortal", "Home");
                    }
                    else if (usertype == "Doctor")
                    {

                        return RedirectToAction("DoctorLoginPortal", "Home");
                    }
                    else if (usertype == "Admin")
                    {

                        return RedirectToAction("AdminPortal", "Home");
                    }

                }


            }
            TempData["AlertMessage"] = "Invalid Credentials";
            return RedirectToAction("LoginUser", "Login");
            
        }
    }
}