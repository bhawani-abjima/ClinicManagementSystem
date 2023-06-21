using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ClinicManagementSystem.Models
{
    public class BookAppointment
    {
        public String? DoctorEmail { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; }

        public String? PatientEmail { get; set; }


    }
}
