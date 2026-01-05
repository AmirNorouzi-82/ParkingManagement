namespace ParkingManagement.Application.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}