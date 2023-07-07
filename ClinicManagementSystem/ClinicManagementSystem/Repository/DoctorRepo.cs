using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class DoctorRepo :IDoctor
    {

        private readonly ConnectionContext _connectionContext;

        public DoctorRepo(ConnectionContext connectionContext)
        {

            _connectionContext = connectionContext;
        }
      
        public async Task<DoctorModel> DoctorPortalAsync(string DoctorEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    //var dynamicParameters = new DynamicParameters();
                    //dynamicParameters.Add("@DoctorEmail", DoctorEmail);


                    var doctorData = await connection.QueryFirstOrDefaultAsync<DoctorModel>("sp_GetDoctorAndAppointmentData",
                        new { DoctorEmail = DoctorEmail }, commandType: CommandType.StoredProcedure);

                    return doctorData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DoctorRegisAsync(DoctorModel doctorCredentials)
        {

            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {

                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@RegistrationNo", doctorCredentials.RegistrationNo);
                    dynamicParameters.Add("@DoctorFirstName", doctorCredentials.DoctorName);
              
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

        public async Task<DoctorModel> DoctorEditPortal(string doctorEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var doctorEditData = await connection.QueryFirstOrDefaultAsync<DoctorModel>("sp_GetDoctorDataForEdit",
                        new { DoctorEmail = doctorEmail }, commandType: CommandType.StoredProcedure);

                    return doctorEditData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDoctorDetails(DoctorModel doctorUpdate)
        {
            using (var connection = _connectionContext.CreateConnection())
            {
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@RegistrationNo", doctorUpdate.RegistrationNo);
                dynamicParameters.Add("@DoctorName", doctorUpdate.DoctorName);
             
                dynamicParameters.Add("@Email", doctorUpdate.Email);
                dynamicParameters.Add("@Specialities", doctorUpdate.Specialities);
                dynamicParameters.Add("@Experience", doctorUpdate.Experience);
                dynamicParameters.Add("@Education", doctorUpdate.Education);
                dynamicParameters.Add("@Fees", doctorUpdate.Fees);

                connection.Execute("UpdateDoctorDetails", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        
    }
}
