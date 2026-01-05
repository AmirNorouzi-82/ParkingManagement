namespace ParkingManagement.Application.DTOs
{
    public class UpdateParkingSpotDto
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public string? Zone { get; set; }
        public string? Type { get; set; }
    }
}