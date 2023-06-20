using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using Newtonsoft.Json.Linq;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class PatientAppointmentDetailsRepository : IPatientAppointmentDetails
    {
        private readonly ConnectionContext _connectionContext;

        public PatientAppointmentDetailsRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }


        public IEnumerable<BookAppointment> PatientAppointmentData(string Email)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientEmail", Email);

                    var appointmentData = connection.Query<BookAppointment>("GetPatientAppointmentByEmail", dynamicParameters, commandType: CommandType.StoredProcedure);

                    return appointmentData.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
