using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class PatientModel
    {

        [Required(ErrorMessage = " First Name is required.")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Patient First Name must start with a capital letter.")]
        public string PatientFirstName { get; set; }


        [Required(ErrorMessage = " Last Name is required.")]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Patient Last Name must start with a capital letter.")]
        public string PatientLastName { get; set; }


        [Required(ErrorMessage = " Age is required.")]
        public int Age { get; set; }


        [Required(ErrorMessage = " Gender is required.")]
        public string Gender { get; set; }


        [Required(ErrorMessage = " PhoneNo is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "PhoneNo must be a 10-digit number.")]
        public long PhoneNo { get; set; }


        [Required(ErrorMessage = " Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }




        [Required(ErrorMessage = " MartialStatus is required.")]
        public string MartialStatus { get; set; }


        [Required(ErrorMessage = "Date of Birth is required.")]
        //[DataType(DataType.Date)]
        //[Display(Name = "Date of Birth")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "1940-01-01", "9999-12-31", ErrorMessage = "Date of Birth must be between 1940 and the current date.")]
        public DateTime DateOfBirth { get; set; }





        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }


        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }



        [Required(ErrorMessage = " Address is required.")]
        public string Address { get; set; }



        [Required(ErrorMessage = " Height is required.")]
        public float Height { get; set; }



        [Required(ErrorMessage = " Weight is required.")]
        public float Weight { get; set; }

        [Required(ErrorMessage = " DiseaseBrief is required.")]
        public string DiseaseBrief { get; set; }

       // public string RegistrationSuccess { get; set; }
    }
}

