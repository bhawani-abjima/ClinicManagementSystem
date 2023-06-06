using ClinicManagementSystem.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult SignUp(Users user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Call the stored procedure
                    SignUpUser(user);

                    // Redirect to a success page or perform any other desired action
                    return RedirectToAction("SignUpSuccess");
                }
                catch (Exception ex)
                {
                    // Handle any errors that occurred during signup
                    ModelState.AddModelError("", "An error occurred during signup.");

                }
            }

            return View(user);
        }


        private void SignUpUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection("DbString"))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@Password", user.Password);
                parameters.Add("@UserType", user.UserType);

                connection.Execute("SignUpUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
