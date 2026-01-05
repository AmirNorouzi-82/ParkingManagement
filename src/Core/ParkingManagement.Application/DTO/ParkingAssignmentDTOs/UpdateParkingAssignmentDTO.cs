namespace ParkingManagement.Application.DTOs
{
    public class UpdateParkingAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int? ParkingSpotId { get; set; }
        public string Notes { get; set; }
    }
}