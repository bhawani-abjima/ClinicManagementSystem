
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static ClinicManagementSystem.Contracts.ILoginRepository;

namespace ClinicManagementSystem.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        

        public async Task<IActionResult> SignUpUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.AddAsync(user);
                if (result == "Registration Successful")
                {
                    return RedirectToAction("LoginUser", "Home");
                }
            }
            return RedirectToAction("Index", "Home");

        }


    }
}
