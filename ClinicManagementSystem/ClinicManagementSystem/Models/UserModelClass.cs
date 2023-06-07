namespace ClinicManagementSystem.Models
{
    public class UserModelClass
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? UserEmail { get;  set; }
        public string UserType { get; set; }
    }
}
