namespace ParkingManagement.Application.DTOs
{
    public class CreateVehicleDTO
    {
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
    }
}