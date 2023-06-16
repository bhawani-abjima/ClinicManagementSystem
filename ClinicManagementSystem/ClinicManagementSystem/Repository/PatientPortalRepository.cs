﻿using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Repository
{
    public class PatientPortalRepository : IPatientPortalRepository
    {
        private readonly ConnectionContext _connectionContext;

        public PatientPortalRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<PatientModel> PatientPortalAsync(string PatientEmail)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@PatientEmail", PatientEmail);
                  //  dynamicParameters.Add("@PatientEmail", PatientPhoneNo);

                    PatientModel patientData = await connection.QueryFirstOrDefaultAsync<PatientModel>("sp_checkPatientLogin", dynamicParameters, commandType: CommandType.StoredProcedure);

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
