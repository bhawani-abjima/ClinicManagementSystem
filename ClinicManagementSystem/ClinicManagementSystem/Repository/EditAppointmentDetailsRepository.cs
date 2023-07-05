using ClinicManagementSystem.Connection;
using ClinicManagementSystem.Contracts;
using ClinicManagementSystem.Models;
using Dapper;
using System;
using System.Data;


namespace ClinicManagementSystem.Repository
{

    public class EditAppointmentDetailsRepository : IEditAppointmentDetailsRepository
    {   
        private readonly ConnectionContext _connectionContext;

        public EditAppointmentDetailsRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
            
        }
        public Appointment AppointmentEditPortal(int id)
        {
            try
            {
                using (var connection = _connectionContext.CreateConnection())
                {
                    var appointmentEditData = connection.QueryFirstOrDefault<Appointment>("GetAppointmentById",
                        new { @Id = id }, commandType: CommandType.StoredProcedure);

                    return appointmentEditData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAppointmentDetails(Appointment AppointmentUpdate)
        {
            using(var connection = _connectionContext.CreateConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id",AppointmentUpdate.AppointmentId);
                dynamicParameters.Add("@DoctorEmail", AppointmentUpdate.DoctorEmail);
                dynamicParameters.Add("@AppointmentDate", AppointmentUpdate.AppointmentDate);
                dynamicParameters.Add("@AppointmentTime", AppointmentUpdate.@AppointmentTime);
                dynamicParameters.Add("@PatientEmail", AppointmentUpdate.PatientEmail);
                dynamicParameters.Add("@AppointmentStatus", AppointmentUpdate.AppointmentStatus);

                connection.Execute("UpdateAppointment", dynamicParameters, commandType: CommandType.StoredProcedure);


            }
        }
    }
}