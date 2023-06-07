using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserRepository _userRepository;

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public IActionResult CreateUser(UserModelClass user)
    {
        try
        {
            _userRepository.CreateUser(user);
            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
