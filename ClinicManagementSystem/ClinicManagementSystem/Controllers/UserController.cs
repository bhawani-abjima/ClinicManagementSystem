
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static ClinicManagementSystem.Contracts.IUserRepository;

namespace ClinicManagementSystem.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost ,ActionName("SignUpUser")]
        public async Task <string> SignUpUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var result =await _userRepository.AddAsync(user);
                return result;
                
            }
            else { throw new Exception("Invalid model state."); }

         }
       

    }
}
