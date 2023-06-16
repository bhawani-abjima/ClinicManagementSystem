using System.Numerics;

namespace ClinicManagementSystem.Models
{
    public class BookAppointment
    {            
        public List<DoctorModel> Doctordetails { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
