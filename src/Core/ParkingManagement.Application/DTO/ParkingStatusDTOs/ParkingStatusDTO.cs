namespace ParkingManagement.Application.DTOs
{
    public class ParkingStatusDto
    {
        public int TotalSpots { get; set; }
        public int AvailableSpots { get; set; }
        public int OccupiedSpots { get; set; }
        public int ReservedSpots { get; set; }
        public List<SpotDetailDto> SpotDetails { get; set; } = new List<SpotDetailDto>();
    }
}