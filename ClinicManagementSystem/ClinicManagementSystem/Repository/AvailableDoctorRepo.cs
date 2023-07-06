using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class AvailableDoctorRepo : IAvailableDoctor
    {
        private readonly ConnectionContext _connectionContext;


        public AvailableDoctorRepo(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;

        }

        public async Task<List<DoctorModel>> BookAppointmentAsync()
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var appointmentData = await connection.QueryAsync<DoctorModel>("sp_getAvailableDoctors", commandType: CommandType.StoredProcedure);
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
