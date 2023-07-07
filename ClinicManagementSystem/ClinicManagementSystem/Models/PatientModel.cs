using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class PatientModel
    {


        public string? PatientFirstName { get; set; }
        public string? PatientLastName { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public long PhoneNo { get; set; }

        public string? Email { get; set; }


        public string? MartialStatus { get; set; }

        public DateTime DateOfBirth { get; set; }


        public string? City { get; set; }

        
        public string? State { get; set; }

        public string? Address { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string? DiseaseBrief { get; set; }


    }
}

