using ParkingManagement.Domain.Enums;

namespace ParkingManagement.Application.DTOs
{
    public class CreateParkingSpotDTO
    {
        public string SpotNumber { get; set; }
        public string Zone { get; set; }
        public SpotType Type { get; set; }
    }
}