namespace ParkingManagement.Application.DTOs.Auth
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public AdminInfoDto Admin { get; set; }
    }

    public class AdminInfoDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}