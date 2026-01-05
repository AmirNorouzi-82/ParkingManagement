namespace ParkingManagement.Application.DTOs
{
    public class CreateAdminDto
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}