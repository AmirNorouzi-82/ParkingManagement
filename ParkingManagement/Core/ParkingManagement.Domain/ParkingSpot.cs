using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.ParkingManagement.Domain
{
    public class ParkingSpot
    {
        public int Id { get; set; }
        public string SpotNumber { get; set; }
        public string Zone { get; set; } // example : A, B, C
        public SpotType Type { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool IsReserved { get; set; } = false;
        public DateTime? LastOccupiedTime { get; set; }
        public DateTime? LastVacatedTime { get; set; }


        // Navigation property
        public virtual ICollection<ParkingLog> ParkingLogs { get; set; }

        public enum SpotType
        {
            Regular,
            VIP,
            Disabled,
            Electric
        }
    }
}
