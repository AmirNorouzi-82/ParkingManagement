namespace ParkingManagement.API.Models
{
    public class AuthResponse
    {
        public string Token { get; set; } = "";
        public DateTime Expiration { get; set; }
        public object Admin { get; set; } = new();
    }
}
