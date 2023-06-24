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
                    //var dynamicParameters = new DynamicParameters();
                    //dynamicParameters.Add("@DoctorEmail", DoctorEmail);


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
    }
}
