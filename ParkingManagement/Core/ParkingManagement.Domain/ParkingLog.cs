using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.ParkingManagement.Domain
{
    public class ParkingLog
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ParkingSpotId { get; set; }
        public int? AdminId { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.Now;
        public DateTime? ExitTime { get; set; }
        public decimal? Cost { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string Notes { get; set; }


        // Navigation properties
        public virtual Vehicle Vehicle { get; set; }
        public virtual ParkingSpot ParkingSpot { get; set; }
        public virtual Admin Admin { get; set; }


        public enum PaymentStatus
        {
            Pending,
            Paid,
            Free,
            Cancelled
        }
    }
}
