using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class AppointmentRepo:IAppointment
    {
        private readonly ConnectionContext _connectionContext;

        public AppointmentRepo(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;

        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            using (var connection = _connectionContext.CreateConnection())
            {
                var AppointmentDetails =await connection.QueryAsync<Appointment>("sp_GetAllAppointments", commandType: CommandType.StoredProcedure);
                return AppointmentDetails;
            }
        }
        public async Task<string> AppointmentAsync(BookAppointment appointmentCredentials)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@DoctorEmail", appointmentCredentials.DoctorEmail);
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

        public async Task<Appointment> AppointmentEditPortal(int id)
        {
            try
            {
                using (var connection =  _connectionContext.CreateConnection())
                {
                    var appointmentEditData = await connection.QueryFirstOrDefaultAsync<Appointment>("GetAppointmentById",
                        new { @Id = id }, commandType: CommandType.StoredProcedure);

                    return appointmentEditData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAppointmentDetails(Appointment AppointmentUpdate)
        {
            using (var connection = _connectionContext.CreateConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", AppointmentUpdate.AppointmentId);
                dynamicParameters.Add("@DoctorEmail", AppointmentUpdate.DoctorEmail);
                dynamicParameters.Add("@AppointmentDate", AppointmentUpdate.AppointmentDate);
                dynamicParameters.Add("@AppointmentTime", AppointmentUpdate.@AppointmentTime);
                dynamicParameters.Add("@PatientEmail", AppointmentUpdate.PatientEmail);
                dynamicParameters.Add("@AppointmentStatus", AppointmentUpdate.AppointmentStatus);

                connection.Execute("UpdateAppointment", dynamicParameters, commandType: CommandType.StoredProcedure);


            }
        }

        
    }
}
