namespace ParkingManagement.Application.DTOs
{
    public class UpdateParkingAssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int? ParkingSpotId { get; set; }
        public string Notes { get; set; }
    }
}