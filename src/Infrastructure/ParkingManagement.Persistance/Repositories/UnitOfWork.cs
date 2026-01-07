using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Persistance.Contexts;

namespace ParkingManagement.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingDbContext _context;

        public IAdminRepository AdminRepository { get; }
        public IParkingLogRepository ParkingLogRepository { get; }
        public IParkingSpotRepository ParkingSpotRepository { get; }
        public IVehicleRepository VehicleRepository { get; }

        public UnitOfWork(
            ParkingDbContext context,
            IAdminRepository adminRepository,
            IParkingLogRepository parkingLogRepository,
            IParkingSpotRepository parkingSpotRepository,
            IVehicleRepository vehicleRepository)
        {
            _context = context;
            AdminRepository = adminRepository;
            ParkingLogRepository = parkingLogRepository;
            ParkingSpotRepository = parkingSpotRepository;
            VehicleRepository = vehicleRepository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}