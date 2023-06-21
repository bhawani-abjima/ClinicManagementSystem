using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class DoctorPortalRepository : IDoctorPortalRepository
    {
        private readonly ConnectionContext _connectionContext;

        public DoctorPortalRepository(ConnectionContext connectionContext)
        {
            
            _connectionContext = connectionContext;
        }
       

        public DoctorModel DoctorPortalAsync(string DoctorEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    //var dynamicParameters = new DynamicParameters();
                    //dynamicParameters.Add("@DoctorEmail", DoctorEmail);


                    var doctorData = connection.QueryFirstOrDefault<DoctorModel>("sp_GetDoctorAndAppointmentData",
                        new{DoctorEmail = DoctorEmail}, commandType: CommandType.StoredProcedure);

                    return doctorData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
