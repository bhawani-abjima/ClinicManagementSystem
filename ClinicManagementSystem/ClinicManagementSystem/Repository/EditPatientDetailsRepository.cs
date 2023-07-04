using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class EditPatientDetailsRepository : IEditPatientDetailsRepository
    {
        private readonly ConnectionContext _connectionContext;

        public EditPatientDetailsRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;

        }


        public PatientModel PatientEditPortal(string PatientEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var PatientEditData = connection.QueryFirstOrDefault<PatientModel>("sp_GetPatientDataForEdit",
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
