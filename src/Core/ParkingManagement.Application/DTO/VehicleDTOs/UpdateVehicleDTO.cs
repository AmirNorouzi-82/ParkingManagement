namespace ParkingManagement.Application.DTOs
{
    public class UpdateVehicleDTO
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? OwnerName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}