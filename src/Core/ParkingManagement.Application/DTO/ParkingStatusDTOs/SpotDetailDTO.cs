namespace ParkingManagement.Application.DTOs
{
    public class SpotDetailDto
    {
        public int SpotId { get; set; }
        public string SpotNumber { get; set; }
        public string Zone { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public string OccupiedByPlate { get; set; }
        public DateTime? OccupiedSince { get; set; }
    }
}