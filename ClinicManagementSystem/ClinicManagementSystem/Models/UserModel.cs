using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class UserModel
    {

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? UserEmail { get; set; }


        [Required]
        public string? UserType { get; set; }
        //public DateTime AddedOn { get; internal set; }
    }
  
}
