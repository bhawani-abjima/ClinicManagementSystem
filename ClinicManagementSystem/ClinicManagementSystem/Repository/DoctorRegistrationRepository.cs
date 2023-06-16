using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class DoctorRegistrationRepository : IDoctorRegistrationRepository
    {
        private readonly ConnectionContext _connectionContext;
        public DoctorRegistrationRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        

        public async Task<string> DoctorPortalAsync(DoctorModel doctorCredentials)
        {

            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {

                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@RegistrationNo", doctorCredentials.RegistrationNo);
                    dynamicParameters.Add("@DoctorFirstName", doctorCredentials.DoctorFirstName);
                    dynamicParameters.Add("@DoctorLastName", doctorCredentials.DoctorLastName);
                    dynamicParameters.Add("@Email", doctorCredentials.Email);
                    dynamicParameters.Add("@Specialities", doctorCredentials.Specialities);
                    dynamicParameters.Add("@Experience", doctorCredentials.Experience);
                    dynamicParameters.Add("@Education", doctorCredentials.Education);
                    dynamicParameters.Add("@Fees", doctorCredentials.Fees);

                    // dynamicParameters.Add("@ApplicationDetails", patientCredentials.ApplicationDetails);
                    dynamicParameters.Add("@RegistrationSuccess", 1, DbType.Int32, direction: ParameterDirection.Output);

                    await _connectionString.ExecuteAsync("sp_doctor_profile", dynamicParameters, commandType: CommandType.StoredProcedure);
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
