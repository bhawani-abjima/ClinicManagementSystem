using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class PatientLoginRepository : IPatientLoginRepository
    {
        private readonly ConnectionContext _connectionContext;

        public PatientLoginRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<string> patientLoginAsync(PatientLoginModel patientloginCredentials)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientPhoneNo", patientloginCredentials.PhoneNo);
                    dynamicParameters.Add("@PatientEmail", patientloginCredentials.Email);
                    dynamicParameters.Add("@PatientLoginSuccess", DbType.Int32, direction: ParameterDirection.Output);

                    await _connectionString.ExecuteAsync("sp_checkPatientLogin", dynamicParameters, commandType: CommandType.StoredProcedure);

                    var patientloginSuccess = dynamicParameters.Get<int>("@PatientLoginSuccess");

                    if (patientloginSuccess == 1)
                    {
                        return "PatientLoginSuccess";

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


      
    