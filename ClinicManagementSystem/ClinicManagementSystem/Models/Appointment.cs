using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PatientEmail { get; set; }
        public string AppointmentStatus { get; set; }
       
    }
}
