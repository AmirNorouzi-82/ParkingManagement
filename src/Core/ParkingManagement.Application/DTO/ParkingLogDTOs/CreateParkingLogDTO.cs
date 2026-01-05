namespace ParkingManagement.Application.DTOs
{
    public class CreateParkingLogDTO
    {
        public int VehicleId { get; set; }
        public int ParkingSpotId { get; set; }
        public int? AdminId { get; set; }
        public string Notes { get; set; }
    }
}