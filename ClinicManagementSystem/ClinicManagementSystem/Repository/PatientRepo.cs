using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class PatientRepo :IPatient
    {

        private readonly ConnectionContext _connectionContext;
        public PatientRepo(ConnectionContext connectionContext)
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

        public async Task<PatientModel> PatientPortalData(string PatientEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientEmail", PatientEmail);
                    //  dynamicParameters.Add("@PatientEmail", PatientPhoneNo);

                    PatientModel appointments = await connection.QueryFirstOrDefaultAsync<PatientModel>("GetPatientDataByEmail", dynamicParameters, commandType: CommandType.StoredProcedure);

                    return appointments;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<BookAppointment>> PatientAppointmentData(string Email)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientEmail", Email);

                    var appointmentData = await connection.QueryAsync<BookAppointment>("GetPatientAppointmentByEmail", dynamicParameters, commandType: CommandType.StoredProcedure);

                    return appointmentData.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PatientModel> PatientEditPortal(string PatientEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var PatientEditData = await connection.QueryFirstOrDefaultAsync<PatientModel>("sp_GetPatientDataForEdit",
                        new { PatientEmail = PatientEmail }, commandType: CommandType.StoredProcedure);

                    return PatientEditData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePatientDetails(PatientModel patientupdate)
        {
            using (var connection = _connectionContext.CreateConnection())
            {
                var dynamicParameters = new DynamicParameters();


                dynamicParameters.Add("@PatientFirstName", patientupdate.PatientFirstName);
                dynamicParameters.Add("@PatientLastName", patientupdate.PatientLastName);
                dynamicParameters.Add("@Age", patientupdate.Age);
                dynamicParameters.Add("@Gender", patientupdate.Gender);
                dynamicParameters.Add("@PhoneNo", patientupdate.PhoneNo);
                dynamicParameters.Add("@PatientEmail", patientupdate.Email);
                dynamicParameters.Add("@MartialStatus", patientupdate.MartialStatus);
                dynamicParameters.Add("@DateOfBirth", patientupdate.DateOfBirth);
                dynamicParameters.Add("@City", patientupdate.City);
                dynamicParameters.Add("@State", patientupdate.State);
                dynamicParameters.Add("@Address", patientupdate.Address);
                dynamicParameters.Add("@Height", patientupdate.Height);
                dynamicParameters.Add("@Weight", patientupdate.Weight);
                dynamicParameters.Add("@DiseaseBrief", patientupdate.DiseaseBrief);
                connection.Execute("UpdatePatientDetails", dynamicParameters, commandType: CommandType.StoredProcedure);
            }

        }



    }
}
