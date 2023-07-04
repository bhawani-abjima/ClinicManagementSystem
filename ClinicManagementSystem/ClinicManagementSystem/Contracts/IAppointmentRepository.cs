using System.Collections.Generic;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.Contracts
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
    }
}
