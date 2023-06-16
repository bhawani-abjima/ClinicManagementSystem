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
        public async Task<DoctorModel> DoctorPortalAsync(string RegistrationNo)
        {

            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@RegistrationNo", RegistrationNo);
               

                    DoctorModel doctorData = await connection.QueryFirstOrDefaultAsync<DoctorModel>("sp_checkdoctorLogin", dynamicParameters, commandType: CommandType.StoredProcedure);

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
