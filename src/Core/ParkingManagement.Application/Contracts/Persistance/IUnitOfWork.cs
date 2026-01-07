namespace ParkingManagement.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository AdminRepository { get; }
        IParkingLogRepository ParkingLogRepository { get; }
        IParkingSpotRepository ParkingSpotRepository { get; }
        IVehicleRepository VehicleRepository { get; }

        Task<int> SaveChangesAsync();
    }
}