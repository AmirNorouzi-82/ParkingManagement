namespace ParkingManagement.Application.DTOs
{
    public class ParkingLogDTO
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ParkingSpotId { get; set; }
        public int? AdminId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? Cost { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}