using System;

namespace ClinicManagementSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string DoctorEmail { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string PatientEmail { get; set; }
        public string AppointmentStatus { get; set; }
       
    }
}
