using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace ClinicManagementSystem.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly ConnectionContext _connectionContext;

        public AppointmentRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
            
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            using (var connection = _connectionContext.CreateConnection())
            {
                var AppointmentDetails = connection.Query<Appointment>("sp_GetAllAppointments", commandType: CommandType.StoredProcedure);
                return AppointmentDetails;
            }
        }
    }    
        
    
}
