using ParkingManagement.Domain.Enums;

namespace ParkingManagement.Application.DTOs
{
    public class ParkingSpotDTO
    {
        public int Id { get; set; }
        public string SpotNumber { get; set; }
        public string Zone { get; set; }
        public SpotType Type { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public DateTime? LastOccupiedTime { get; set; }
        public DateTime? LastVacatedTime { get; set; }
    }
}