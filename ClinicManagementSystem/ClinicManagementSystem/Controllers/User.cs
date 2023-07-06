
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static ClinicManagementSystem.Contracts.ILogin;

namespace ClinicManagementSystem.Controllers
{
    public class User : Controller
    {

        private readonly IUser _userRepository;
        public User(IUser userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult SignUpUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.AddAsync(user);
                if (result == "Registration Successful")
                {
                    return RedirectToAction("LoginUser", "Login");
                }
            }
            return RedirectToAction("Index", "Home");

        }


    }
}
