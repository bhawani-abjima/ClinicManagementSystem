using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class PatientLoginRepository : IPatientLoginRepository
    {
        private readonly ConnectionContext _connectionContext;

        public PatientLoginRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

    
        public async Task<PatientModel> PatientLoginAsync(string email)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientEmail",email);

                    var patientData = await connection.QueryFirstOrDefaultAsync<PatientModel>("sp_checkPatientLogin", dynamicParameters, commandType: CommandType.StoredProcedure);

                    return patientData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
