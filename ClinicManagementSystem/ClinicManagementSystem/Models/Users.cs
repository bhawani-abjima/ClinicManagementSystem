using Microsoft.Win32;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace ClinicManagementSystem.Models
{
    public class Users
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? UserEmail { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? UserType { get; set; }


        public void SignUp()
        {
            string connectionString = "DbString";
            // Created a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a new SqlCommand using the stored procedure name and connection
                using (SqlCommand command = new SqlCommand("sp_create_User", connection))
                {
                    // Set the command type as stored procedure
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the input parameters to the command
                    command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
                    command.Parameters.Add("@UserEmail", SqlDbType.VarChar, 100).Value = UserEmail;
                    command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
                    command.Parameters.Add("@UserType",SqlDbType.VarChar,50).Value= UserType;

                    try
                    {
                        // Openening the database connection
                        connection.Open();

                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Handling any SQL errors as needed
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
    