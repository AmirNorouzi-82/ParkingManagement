namespace ParkingManagement.Application.DTOs
{
    public class UpdateParkingLogDto
    {
        public int Id { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? Cost { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}