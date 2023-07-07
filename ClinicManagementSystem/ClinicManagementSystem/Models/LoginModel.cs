using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class LoginModel
    {
       
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
