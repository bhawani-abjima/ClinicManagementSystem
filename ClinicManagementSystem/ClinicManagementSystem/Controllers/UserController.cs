using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public  Task<Boolean> SignUpUser(UserModel user)
        {
  
            var result = _userRepository.AddAsync(user);
            return result;
        }
    }
}
