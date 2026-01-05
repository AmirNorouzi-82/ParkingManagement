namespace ParkingManagement.Application.DTOs
{
    public class ParkingAssignmentRequestDto
    {
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string OwnerName { get; set; }
        public int? ParkingSpotId { get; set; }
        public string Notes { get; set; }
    }
}