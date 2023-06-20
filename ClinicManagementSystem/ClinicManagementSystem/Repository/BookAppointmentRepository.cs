using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class BookAppointmentRepository : IBookAppointmentRepository
    {
        private readonly ConnectionContext _connectionContext;
        public BookAppointmentRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
            
        }
        public async  Task<string> AppointmentAsync(BookAppointment appointmentCredentials)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DoctorName", appointmentCredentials.DoctorName);
                    dynamicParameters.Add("@AppointmentDate", appointmentCredentials.AppointmentDate);
                    dynamicParameters.Add("@AppointmentTime", appointmentCredentials.AppointmentTime);
                    dynamicParameters.Add("@PatientEmail", appointmentCredentials.PatientEmail);
                   // dynamicParameters.Add("@AppointmentStatus", appointmentCredentials.AppointmentStatus);
                    dynamicParameters.Add("@Success", DbType.Int32, direction: ParameterDirection.Output);

                    await _connectionString.ExecuteAsync("sp_BookAppointment", dynamicParameters, commandType: CommandType.StoredProcedure);

                    var Success = dynamicParameters.Get<int>("@Success");

                    if (Success == 1)
                    {
                        return "Appointment Booked Sucessful";

                    }
                    else
                    {
                        return "Invalid credentials. Please sign up.";
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
