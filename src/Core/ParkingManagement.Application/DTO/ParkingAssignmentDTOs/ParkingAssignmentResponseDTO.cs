namespace ParkingManagement.Application.DTOs
{
    public class ParkingAssignmentResponseDTO
    {
        public int AssignmentId { get; set; }
        public string PlateNumber { get; set; }
        public string SpotNumber { get; set; }
        public DateTime AssignedAt { get; set; }
        public string OwnerName { get; set; }
    }
}