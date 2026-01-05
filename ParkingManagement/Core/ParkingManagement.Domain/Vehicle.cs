using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.ParkingManagement.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ICollection<ParkingLog> ParkingLogs { get; set; }
    }
}
