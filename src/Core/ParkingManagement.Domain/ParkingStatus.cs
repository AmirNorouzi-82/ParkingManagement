namespace ParkingManagement.Domain
{
    public class ParkingStatus
    {
        public int TotalSpots { get; set; }
        public int AvailableSpots { get; set; }
        public int OccupiedSpots { get; set; }
        public int ReservedSpots { get; set; }
        public List<SpotDetail> SpotDetails { get; set; } = new List<SpotDetail>();

        public class SpotDetail
        {
            public int SpotId { get; set; }
            public string SpotNumber { get; set; }
            public string Zone { get; set; }
            public string Type { get; set; }
            public bool IsAvailable { get; set; }
            public bool IsReserved { get; set; }
            public string OccupiedByPlate { get; set; }
            public DateTime? OccupiedSince { get; set; }
        }
    }
}
