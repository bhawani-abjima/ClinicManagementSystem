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
    public class UserRepo : IUser
    {
        private readonly ConnectionContext _connectionContext;
        public UserRepo(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        async Task<string> IUser.AddAsync(UserModel user)
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
                    await _connectionString.ExecuteAsync("sp_create_Users", dynamicParameters, commandType: CommandType.StoredProcedure);
                    var signUpSuccess = dynamicParameters.Get<bool>("@SignUpSuccess");

                    if (signUpSuccess)
                    {
                        return "Registration Successful";
                    }
                    else
                    {
                        return "Already Registered";
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