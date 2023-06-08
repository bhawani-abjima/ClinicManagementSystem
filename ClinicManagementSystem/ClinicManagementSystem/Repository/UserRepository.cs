using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ConnectionContext _connectionContext;
        public UserRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        async Task<Boolean>  IUserRepository.AddAsync(UserModel user)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    int newmethod = 0;
                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("@UserName", user.UserName);
                    dynamicParameters.Add("@UserEmail", user.UserEmail);
                    dynamicParameters.Add("@Password", user.Password);
                  //  dynamicParameters.Add("@Status", 1, DbType.Int16, direction: ParameterDirection.Output);
                    var status =await _connectionString.ExecuteScalarAsync<Boolean>("sp_create_Users", dynamicParameters, commandType: CommandType.StoredProcedure);
                  //  var status = dynamicParameters.Get<Boolean>("@Status");
                    return status;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
