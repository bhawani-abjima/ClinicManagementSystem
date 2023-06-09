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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClinicManagementSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ConnectionContext _connectionContext;
        public UserRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        async Task<string>  IUserRepository.AddAsync(UserModel user)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();

                    dynamicParameters.Add("@UserName", user.UserName, DbType.String);
                    dynamicParameters.Add("@UserEmail", user.UserEmail, DbType.String);
                    dynamicParameters.Add("@Password", user.Password, DbType.String);
                    dynamicParameters.Add("@UserType", user.UserType, DbType.String);
                    dynamicParameters.Add("@SignUpSuccess", 1, DbType.Boolean, direction: ParameterDirection.Output);
                    int SignUpSucess = await _connectionString.ExecuteScalarAsync<int>("sp_create_Users", dynamicParameters, commandType: CommandType.StoredProcedure);
                    //var SignUpSucess = dynamicParameters.Get<bool>("@SignUpSuccess");
                    
                    if (SignUpSucess == 0)
                    {
                        return "User Registered";
                    }
                    else
                    {
                        return "Already Registred";
                    }
                    
                }
            }
            catch(Exception ex) {
                throw ex;
            }
        
        }
    }
}
