using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Core.ParkingManagement.Domain
{
    public class ParkingSpot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string SpotNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Zone { get; set; } // مثلاً: A, B, C

        public SpotType Type { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsReserved { get; set; } = false;

        public DateTime? LastOccupiedTime { get; set; }

        public DateTime? LastVacatedTime { get; set; }

        public enum SpotType
        {
            Regular,
            VIP,
            Disabled,
            Electric
        }
    }
}
