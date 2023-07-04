using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class EditDoctorDetailsRepository : IEditDoctorDetailsRepository
    {
        private readonly ConnectionContext _connectionContext;

        public EditDoctorDetailsRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public DoctorModel DoctorEditPortal(string doctorEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var doctorEditData = connection.QueryFirstOrDefault<DoctorModel>("sp_GetDoctorDataForEdit",
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
                dynamicParameters.Add("@DoctorFirstName", doctorUpdate.DoctorFirstName);
                dynamicParameters.Add("@DoctorLastName", doctorUpdate.DoctorLastName);
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
