using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Domain
{
    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public AdminInfo Admin { get; set; }

        public class AdminInfo
        {
            public int Id { get; set; }
            public string Username { get;set; }
            public string Email { get; set; }
            public string FullName { get; set; }
        }
    }
}
