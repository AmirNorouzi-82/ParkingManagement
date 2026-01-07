using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Domain;
using ParkingManagement.Persistance.Contexts;

namespace ParkingManagement.Persistance.Repositories
{
    public class ParkingSpotRepository : GenericRepository<ParkingSpot>,IParkingSpotRepository
    {
        private readonly ParkingDbContext _context;
        public ParkingSpotRepository(ParkingDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
