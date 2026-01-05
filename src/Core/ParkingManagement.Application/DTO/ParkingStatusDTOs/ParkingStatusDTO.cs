namespace ParkingManagement.Application.DTOs
{
    public class ParkingStatusDTO
    {
        public int TotalSpots { get; set; }
        public int AvailableSpots { get; set; }
        public int OccupiedSpots { get; set; }
        public int ReservedSpots { get; set; }
        public List<SpotDetailDTO> SpotDetails { get; set; } = new List<SpotDetailDTO>();
    }
}