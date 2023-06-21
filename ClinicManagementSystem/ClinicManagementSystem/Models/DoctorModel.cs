using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class DoctorModel
    {
        //public string DoctorId { get; set; }
        public string? RegistrationNo { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public string? Email { get; set; }
        public string? Specialities { get; set; }
        public string? Experience { get; set; }
        public string? Education { get; set; }

        public string? Fees { get; set; }

        //using appointment details

        public string? PatientEmail { get; set;}


        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }

        public String? DiseaseBrief { get; set; }

    }
}
