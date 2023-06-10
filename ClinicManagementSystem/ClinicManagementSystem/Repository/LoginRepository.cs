using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ConnectionContext _connectionContext;
        public LoginRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<string> LoginAsync(LoginModel loginCredentials)
        {
            try
            {
                using (var _connectionString = _connectionContext.CreateConnection())
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@L_UserName", loginCredentials.L_UserName, DbType.String);
                    dynamicParameters.Add("@L_UserEmail", loginCredentials.L_UserEmail, DbType.String);
                    dynamicParameters.Add("@L_Password", loginCredentials.L_Password, DbType.String);
                    dynamicParameters.Add("@L_LoginSuccess", DbType.Int32, direction: ParameterDirection.Output);

                    await _connectionString.ExecuteAsync("sp_Login_User", dynamicParameters, commandType: CommandType.StoredProcedure);

                    var loginSuccess = dynamicParameters.Get<int>("@L_LoginSuccess");

                    if (loginSuccess == 1)
                    {
                        return "Login Successful";
                    }
                    else
                    {
                        return "Invalid credentials. Please sign up.";
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
