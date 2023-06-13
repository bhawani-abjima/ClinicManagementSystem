using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using ClinicManagementSystem.Connection;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ConnectionContext _connectionContext;
        public PatientRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

       
        public async Task<string> PatientAsync(PatientModel patientCredentials)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {

                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientFirstName", patientCredentials.PatientFirstName);
                    dynamicParameters.Add("@PatientLastName", patientCredentials.PatientLastName);
                    dynamicParameters.Add("@Age", patientCredentials.Age);
                    dynamicParameters.Add("@Gender", patientCredentials.Gender);
                    dynamicParameters.Add("@PhoneNo", patientCredentials.PhoneNo);
                    dynamicParameters.Add("@Email", patientCredentials.Email);
                    dynamicParameters.Add("@MartialStatus", patientCredentials.MartialStatus);
                    dynamicParameters.Add("@DateOfBirth", patientCredentials.DateOfBirth);
                    dynamicParameters.Add("@City", patientCredentials.City);
                    dynamicParameters.Add("@State", patientCredentials.State);
                    dynamicParameters.Add("@Address", patientCredentials.Address);
                    dynamicParameters.Add("@Height", patientCredentials.Height);
                    dynamicParameters.Add("@Weight", patientCredentials.Weight);
                    // dynamicParameters.Add("@DiseaseType", patientCredentials.DiseaseType);
                    dynamicParameters.Add("@DiseaseBrief", patientCredentials.DiseaseBrief);
                    // dynamicParameters.Add("@ApplicationDetails", patientCredentials.ApplicationDetails);
                    dynamicParameters.Add("@RegistrationSuccess", 1, DbType.Int32, direction: ParameterDirection.Output);

                    await _connectionString.ExecuteAsync("sp_profile_patient", dynamicParameters, commandType: CommandType.StoredProcedure);
                    var RegistrationSuccess = dynamicParameters.Get<int>("@RegistrationSuccess");

                    if (RegistrationSuccess == 1)
                    {
                        return "RegistrationSuccess";

                    }
                    else
                    {
                        return "Invalid credentials. Please register.";
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
