using ClinicManagementSystem.Models;
using Microsoft.Extensions.DependencyInjection;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using static ClinicManagementSystem.Models.UserModelClass;

public class UserRepository
{
    private readonly string connectionString;

    public UserRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CreateUser(UserModelClass user)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var parameters = new
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                UserEmail = user.UserEmail,
                UserType = user.UserType
            };

            connection.Execute("sp_create_Users", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

